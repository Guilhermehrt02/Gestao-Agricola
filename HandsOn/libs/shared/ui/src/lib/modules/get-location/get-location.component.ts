/* eslint-disable @angular-eslint/prefer-inject */
import {
  Component,
  ElementRef,
  EventEmitter,
  Output,
  AfterViewInit,
  ViewChild,
  inject,
  OnChanges,
  Input,
  SimpleChanges,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { Geolocation } from '@capacitor/geolocation';
import { ButtonComponent } from '../../components/button/button.component';
import { GoogleMapsService, LocationShapeData, MapLocation } from '@farm/core';
import { Router } from '@angular/router';

@Component({
  selector: 'lib-get-location',
  standalone: true,
  imports: [CommonModule, ButtonComponent],
  templateUrl: './get-location.component.html',
  styleUrls: ['./get-location.component.css'],
})
export class GetLocationComponent implements AfterViewInit, OnChanges {
  private activeInfoWindow: google.maps.InfoWindow | null = null;
  @Input() editable = true;
  @Input() creatable = true;
  @Input() clearAllDrawings = true;
  @Input() setPositionFromParent?: { latitude: number; longitude: number };
  @Input() setFocusFromParent?: LocationShapeData;
  @Input() setShapesFromParent?: LocationShapeData[];


  @ViewChild('mapContainer', { static: false }) mapElementRef!: ElementRef;

  @Output() locationDetected = new EventEmitter<{
    latitude: number;
    longitude: number;
  }>();

  @Output() shapesDrawn = new EventEmitter<any[]>();
  @Output() setFocusByDrawing = new EventEmitter<google.maps.Marker | google.maps.Polygon>();
  
  constructor(
      private router: Router,
    ) {}

  private readonly googleMapsService = inject(GoogleMapsService);

  map!: google.maps.Map;
  marker!: google.maps.Marker;

  loading = false;
  error: string | null = null;

  drawnShapes: Array<{
    mapObject: google.maps.Polygon | google.maps.Marker;
    type: string;
    label: string;
    id: string;
  }> = [];

  private drawingManager!: google.maps.drawing.DrawingManager | null;
  private highlightedPolygon: google.maps.Polygon | null = null;

  async ngAfterViewInit(): Promise<void> {
    await this.googleMapsService.loadGoogleMaps();

    const coords = await this.getInitialCoordinates();
    this.initMap(coords.latitude, coords.longitude);

    if (this.setShapesFromParent && this.setShapesFromParent.length > 0) {
      this.loadShapes(this.setShapesFromParent);
    }
  }

  async getInitialCoordinates(): Promise<{
    latitude: number;
    longitude: number;
  }> {
    try {
      const position = await Geolocation.getCurrentPosition();
      return {
        latitude: position.coords.latitude,
        longitude: position.coords.longitude,
      };
    } catch {
      return { latitude: -23.5505, longitude: -46.6333 };
    }
  }

  initMap(lat: number, lng: number): void {
    const mapEl = this.mapElementRef.nativeElement;
    const center = new google.maps.LatLng(lat, lng);

    this.map = new google.maps.Map(mapEl, {
      center,
      zoom: 15,
      mapTypeId: google.maps.MapTypeId.SATELLITE,
    });

    this.map.addListener('click', () => {
      if (this.activeInfoWindow) {
        this.activeInfoWindow.close();
        this.activeInfoWindow = null;
      }
    });

    if(!this.creatable) return;

    const drawingManager = new google.maps.drawing.DrawingManager({
      drawingMode: null,
      drawingControl: true,
      drawingControlOptions: {
        position: google.maps.ControlPosition.TOP_CENTER,
        drawingModes: [
          google.maps.drawing.OverlayType.MARKER,
          google.maps.drawing.OverlayType.POLYGON,
        ],
      },
      polygonOptions: {
        fillColor: '#FF0000',
        fillOpacity: 0.35,
        strokeWeight: 2,
        editable: true,
        draggable: false,
      },
    });

    drawingManager.setMap(this.map);

    const addShapeToList = (
      shapeObj: google.maps.Polygon | google.maps.Marker,
      type: string,
      label: string,
    ) => {
      this.drawnShapes.push({ mapObject: shapeObj, type, label, id: this.generateId() });
      this.emitCurrentShapes();
    };

    function getPolygonCenter(
      polygon: google.maps.Polygon,
    ): google.maps.LatLng {
      const bounds = new google.maps.LatLngBounds();
      polygon.getPath().forEach((latLng) => bounds.extend(latLng));
      return bounds.getCenter();
    }

    // POLYGON
    google.maps.event.addListener(
      drawingManager,
      'polygoncomplete',
      (polygon: google.maps.Polygon) => {
        const label =
          prompt('Nome do polígono:', 'Polígono sem nome') ||
          'Polígono sem nome';

        addShapeToList(polygon, 'polygon', label);
        this.fitMapToShapes();

        const centroid = getPolygonCenter(polygon);
        const location: MapLocation = {
          label,
        };
        const content = this.createInfoWindowContent(location, () => {
          polygon.setMap(null);
          this.removeShape(polygon);
        });

        const infoWindow = new google.maps.InfoWindow({
          content,
          position: centroid,
        });

        polygon.addListener('click', (e: google.maps.MapMouseEvent) => {
        if (this.activeInfoWindow) {
          this.activeInfoWindow.close();
        }
        infoWindow.setPosition(e.latLng);
        infoWindow.open(this.map);
        this.activeInfoWindow = infoWindow;
      });


        infoWindow.close();

        polygon.getPath().addListener('set_at', () => this.emitCurrentShapes());
        polygon
          .getPath()
          .addListener('insert_at', () => this.emitCurrentShapes());
        polygon
          .getPath()
          .addListener('remove_at', () => this.emitCurrentShapes());
      },
    );

    // MARKER
    google.maps.event.addListener(
      drawingManager,
      'markercomplete',
      (marker: google.maps.Marker) => {
        if (this.marker) this.marker.setMap(null);
        this.marker = marker;
        this.marker.setDraggable(true);

        const label =
          prompt('Nome do local ou ponto:', 'Ponto sem nome') ||
          'Ponto sem nome';

        addShapeToList(marker, 'marker', label);
        this.fitMapToShapes();

        const location: MapLocation = {
          label,
        };

        const content = this.createInfoWindowContent(location, () => {
          marker.setMap(null);
          this.removeShape(marker);
        });

        const infoWindow = new google.maps.InfoWindow({
          content,
        });

        marker.addListener('click', () => {
          if (this.activeInfoWindow) {
            this.activeInfoWindow.close();
          }
          infoWindow.open(this.map, marker);
          this.activeInfoWindow = infoWindow;
        });

        marker.addListener('dragend', () => {
          this.emitCurrentShapes();
          const pos = marker.getPosition();
          if (pos) this.emitCoords(pos.lat(), pos.lng());
        });
      },
    );
  }

  private createInfoWindowContent(
    location: MapLocation,
    onDelete: () => void
  ): HTMLElement {
    const { label, info } = location;

    const content = document.createElement('div');
    content.style.backgroundColor = 'white';
    content.style.color = 'black';
    content.style.padding = '10px';
    content.style.borderRadius = '8px';
    content.style.border = '1px solid #ccc';
    content.style.fontSize = '13px';
    content.style.maxWidth = '240px';
    content.style.boxShadow = '0 2px 6px rgba(0,0,0,0.2)';
    content.style.display = 'flex';
    content.style.flexDirection = 'column';
    content.style.gap = '6px';

    const title = document.createElement('h4');
    title.textContent = label || 'Diagnóstico';
    title.style.margin = '0';
    title.style.fontSize = '15px';
    title.style.fontWeight = '600';
    title.style.color = '#1a4d2e';
    content.appendChild(title);

    if (info) {
      const infoList = document.createElement('div');
      infoList.style.display = 'flex';
      infoList.style.flexDirection = 'column';
      infoList.style.gap = '2px';

      const addLine = (label: string, value?: string | Date) => {
        if (!value) return;
        const line = document.createElement('div');
        line.innerHTML = `<strong>${label}:</strong> ${value}`;
        infoList.appendChild(line);
      };

      addLine('Doença', info.name);
      addLine('Fazenda', info.farmName);
      addLine('Talhão', info.plotName);
      addLine('Colheita', info.harvestName);
      addLine('Status', info.status);
      addLine('Data', info.date ? new Date(info.date).toLocaleDateString() : undefined);

      content.appendChild(infoList);
    }

    const footer = document.createElement('div');
    footer.style.display = 'flex';
    footer.style.justifyContent = 'space-between';
    footer.style.alignItems = 'center';
    footer.style.marginTop = '8px';
    footer.style.gap = '6px';

    if (info?.status === 'Processed' && info.id) {
      const viewBtn = document.createElement('button');
      viewBtn.textContent = 'Ver diagnóstico';
      viewBtn.style.backgroundColor = '#166534';
      viewBtn.style.color = 'white';
      viewBtn.style.border = 'none';
      viewBtn.style.borderRadius = '4px';
      viewBtn.style.padding = '4px 8px';
      viewBtn.style.fontSize = '12px';
      viewBtn.style.cursor = 'pointer';
      viewBtn.onclick = () =>
        this.navigateToViewDiagnosis(info.id || '');
      footer.appendChild(viewBtn);
    }

    if (this.editable) {
      const deleteBtn = document.createElement('button');
      deleteBtn.textContent = 'Excluir';
      deleteBtn.style.backgroundColor = '#b91c1c';
      deleteBtn.style.color = 'white';
      deleteBtn.style.border = 'none';
      deleteBtn.style.borderRadius = '4px';
      deleteBtn.style.padding = '4px 8px';
      deleteBtn.style.fontSize = '12px';
      deleteBtn.style.cursor = 'pointer';
      deleteBtn.onclick = onDelete;
      footer.appendChild(deleteBtn);
    }

    if (footer.children.length > 0) content.appendChild(footer);

    return content;
  }

  private removeShape(shapeObj: google.maps.Polygon | google.maps.Marker) {
    this.drawnShapes = this.drawnShapes.filter((s) => s.mapObject !== shapeObj);
    this.emitCurrentShapes();
  }

  emitCoords(lat: number, lng: number): void {
    this.locationDetected.emit({ latitude: lat, longitude: lng });
  }

  async detectLocation(): Promise<void> {
    this.loading = true;
    this.error = null;

    try {
      const coords = await this.getInitialCoordinates();

      this.map.setCenter(
        new google.maps.LatLng(coords.latitude, coords.longitude),
      );
    } catch (err) {
      this.error = 'Não foi possível obter sua localização.';
      console.error(err);
    } finally {
      this.loading = false;
    }
  }

  clearDrawings(): void {
    this.drawnShapes.forEach(({ mapObject }) => {
      mapObject.setMap(null);
    });
    this.drawnShapes = [];
    this.emitCurrentShapes();
  }

  private lastShapes: LocationShapeData[] | null = null;
  private lastFocus: LocationShapeData | null = null;

  ngOnChanges(changes: SimpleChanges): void {
    if (
      changes['setShapesFromParent'] &&
      this.setShapesFromParent &&
      this.map
    ) {
      const isDifferent =
        JSON.stringify(this.lastShapes) !==
        JSON.stringify(this.setShapesFromParent);
      if (isDifferent) {
        this.lastShapes = this.setShapesFromParent;
        this.clearDrawings();
        this.loadShapes(this.setShapesFromParent);
      }
    }

    if (
      changes['setFocusFromParent'] &&
      this.setFocusFromParent &&
      this.map
    ){
      const isDifferent =
        JSON.stringify(this.lastFocus) !==
        JSON.stringify(this.setFocusFromParent);
      if (isDifferent) {
        this.lastFocus = this.setFocusFromParent;
        this.setFocus(this.setFocusFromParent);
      }
    }

    if (changes['creatable'] && this.map) {
      this.clearHighlight();
      
      if (this.creatable) this.createDrawingManager();
      else this.destroyDrawingManager();
    }
  }

  loadShapes(shapes: any[]) {
    shapes.forEach((shape) => {
      if (!shape.id) {
        shape.id = this.generateId();
      }

      if (shape.type === 'polygon') {
        const path = shape.coordinates.map(
          (coord: any) => new google.maps.LatLng(coord.lat, coord.lng),
        );

        const polygon = new google.maps.Polygon({
          paths: path,
          fillColor: shape.color || '#FF0000',
          fillOpacity: 0.35,
          strokeWeight: 2,
          editable: this.editable,
          draggable: false,
          map: this.map,
        });

        this.drawnShapes.push({
          mapObject: polygon,
          type: 'polygon',
          label: shape.label,
          id: shape.id,
        });

        const centroid = this.getPolygonCenter(polygon);

        const content = this.createInfoWindowContent(shape, () => {
          polygon.setMap(null);
          this.removeShape(polygon);
        });

        const infoWindow = new google.maps.InfoWindow({
          content,
          position: centroid,
        });

        polygon.addListener('mouseover', (e: google.maps.MapMouseEvent) => {
          if (this.activeInfoWindow) {
            this.activeInfoWindow.close();
          }
          
          infoWindow.setPosition(e.latLng);
          infoWindow.open(this.map);
          this.activeInfoWindow = infoWindow;
        });

        polygon.addListener('mouseout', () => {
          if (this.activeInfoWindow === infoWindow) {
            infoWindow.close();
            this.activeInfoWindow = null;
          }
        });

        polygon.addListener('click', () => {
          this.clearHighlight();

          this.setFocus(shape);

          this.setFocusByDrawing.emit(shape);
        });
        
        polygon.getPath().addListener('set_at', () => this.emitCurrentShapes());

        polygon
          .getPath()
          .addListener('insert_at', () => this.emitCurrentShapes());

        polygon
          .getPath()
          .addListener('remove_at', () => this.emitCurrentShapes());
      } else if (shape.type === 'marker') {
        const pos = new google.maps.LatLng(
          shape.coordinates[0].lat,
          shape.coordinates[0].lng,
        );

        const marker = new google.maps.Marker({
          position: pos,
          draggable: false,
          map: this.map,
        });

        this.drawnShapes.push({
          mapObject: marker,
          type: 'marker',
          label: shape.label,
          id: shape.id,
        });

        const content = this.createInfoWindowContent(shape.label, () => {
          marker.setMap(null);
          this.removeShape(marker);
        });

        const infoWindow = new google.maps.InfoWindow({
          content,
        });

        marker.addListener('mouseover', () => {
          if (this.activeInfoWindow) {
            this.activeInfoWindow.close();
          }

          infoWindow.open(this.map, marker);

          this.activeInfoWindow = infoWindow;
        });

        marker.addListener('mouseout', () => {
          if (this.activeInfoWindow === infoWindow) {
            infoWindow.close();
            this.activeInfoWindow = null;
          }
        });

        marker.addListener('dragend', () => {
          this.emitCurrentShapes();

          const pos = marker.getPosition();
          if (pos) {
            this.emitCoords(pos.lat(), pos.lng());
          }
        });
      }
    });

    this.map.addListener('click', (e: google.maps.MapMouseEvent) => {
      this.clearHighlight();
    });

    this.emitCurrentShapes();
    this.fitMapToShapes();
  }

  public placeOrMoveMarker(lat: number, lng: number, emit = false) {
    const position = new google.maps.LatLng(lat, lng);

    if (this.marker) {
      this.marker.setPosition(position);
    } else {
      this.marker = new google.maps.Marker({
        position,
        map: this.map,
        draggable: false,
      });

      this.marker.addListener('dragend', () => {
        const pos = this.marker.getPosition();
        if (pos) {
          this.emitCoords(pos.lat(), pos.lng());
        }
      });
    }

    this.map.setCenter(position);
    if (emit) {
      this.emitCoords(lat, lng);
    }
  }

  private emitCurrentShapes() {
    const serializedShapes: LocationShapeData[] = this.drawnShapes
      .map(({ mapObject, type, label }) => {
        if (type === 'polygon' && mapObject instanceof google.maps.Polygon) {
          const path = mapObject.getPath().getArray();
          const coords = path.map((latLng) => ({
            lat: latLng.lat(),
            lng: latLng.lng(),
          }));
          return { type, label, coordinates: coords };
        }
        if (type === 'marker' && mapObject instanceof google.maps.Marker) {
          const pos = mapObject.getPosition();
          return pos
            ? { type, label, coordinates: [{ lat: pos.lat(), lng: pos.lng() }] }
            : null;
        }
        return null;
      })
      .filter((s) => s !== null) as LocationShapeData[];

    this.shapesDrawn.emit(serializedShapes);
  }

  private getPolygonCenter(polygon: google.maps.Polygon): google.maps.LatLng {
    const bounds = new google.maps.LatLngBounds();
    polygon.getPath().forEach((latLng) => bounds.extend(latLng));
    return bounds.getCenter();
  }

  private fitMapToShapes(): void {
    if (this.drawnShapes.length === 0) return;

    const bounds = new google.maps.LatLngBounds();

    this.drawnShapes.forEach(({ mapObject, type }) => {
      if (type === 'marker' && mapObject instanceof google.maps.Marker) {
        const pos = mapObject.getPosition();
        if (pos) bounds.extend(pos);
      }
      if (type === 'polygon' && mapObject instanceof google.maps.Polygon) {
        mapObject.getPath().forEach((latLng) => bounds.extend(latLng));
      }
    });

    if (this.drawnShapes.length === 1) {
      this.map.setCenter(bounds.getCenter());

      this.map.setZoom(15);
    } else {
      this.map.fitBounds(bounds);
    }
  }

  navigateToViewDiagnosis(id: string): void {
    this.router.navigate([`/app/diagnoses/diagnosis/${id}/result`]);
  }

  setFocus(shape: LocationShapeData) {
    const drawing = this.findDrawingByShape(shape);
    if (!drawing) return;

    if (shape.type === 'polygon' && drawing instanceof google.maps.Polygon) {
      const bounds = new google.maps.LatLngBounds();
      shape.coordinates.forEach(coord =>
        bounds.extend(new google.maps.LatLng(coord.lat, coord.lng))
      );

      this.clearHighlight();

      this.highlightedPolygon = new google.maps.Polygon({
        paths: drawing.getPath(),
        strokeColor: '#00FF7F',      
        strokeOpacity: 1,
        strokeWeight: 4,             
        fillOpacity: 0,              
        zIndex: 9999,                
        map: this.map,
      });

      this.map.fitBounds(bounds);
    } else if (shape.type === 'marker') {
      const position = new google.maps.LatLng(shape.coordinates[0].lat, shape.coordinates[0].lng);
      this.map.setCenter(position);
      this.map.setZoom(17);
    }
  }


  private createDrawingManager() {
    if(!this.creatable || !this.map) return;

    const drawingManager = new google.maps.drawing.DrawingManager({
      drawingMode: null,
      drawingControl: true,
      drawingControlOptions: {
        position: google.maps.ControlPosition.TOP_CENTER,
        drawingModes: [
          google.maps.drawing.OverlayType.MARKER,
          google.maps.drawing.OverlayType.POLYGON,
        ],
      },
      polygonOptions: {
        fillColor: '#FF0000',
        fillOpacity: 0.35,
        strokeWeight: 2,
        editable: false,
        draggable: false,
      },
    });

    this.drawingManager = drawingManager;

    drawingManager.setMap(this.map);

    const addShapeToList = (
      shapeObj: google.maps.Polygon | google.maps.Marker,
      type: string,
      label: string,
    ) => {
      this.drawnShapes.push({ mapObject: shapeObj, type, label, id: this.generateId() });
      this.emitCurrentShapes();
    };

    function getPolygonCenter(
      polygon: google.maps.Polygon,
    ): google.maps.LatLng {
      const bounds = new google.maps.LatLngBounds();
      polygon.getPath().forEach((latLng) => bounds.extend(latLng));
      return bounds.getCenter();
    }

    // POLYGON
    google.maps.event.addListener(
      drawingManager,
      'polygoncomplete',
      (polygon: google.maps.Polygon) => {
        const label =
          prompt('Nome do polígono:', 'Polígono sem nome') ||
          'Polígono sem nome';

        addShapeToList(polygon, 'polygon', label);
        this.fitMapToShapes();

        const centroid = getPolygonCenter(polygon);
        const location: MapLocation = {
          label,
        };
        const content = this.createInfoWindowContent(location, () => {
          polygon.setMap(null);
          this.removeShape(polygon);
        });

        const infoWindow = new google.maps.InfoWindow({
          content,
          position: centroid,
        });

        polygon.addListener('mouseover', (e: google.maps.MapMouseEvent) => {
          if (this.activeInfoWindow) {
            this.activeInfoWindow.close();
          }
          infoWindow.setPosition(e.latLng);
          infoWindow.open(this.map);
          this.activeInfoWindow = infoWindow;
        });

        polygon.addListener('mouseout', () => {
          if (this.activeInfoWindow === infoWindow) {
            infoWindow.close();
            this.activeInfoWindow = null;
          }
        });

        this.creatable = false;
        this.destroyDrawingManager();

        polygon.getPath().addListener('set_at', () => this.emitCurrentShapes());
        polygon
          .getPath()
          .addListener('insert_at', () => this.emitCurrentShapes());
        polygon
          .getPath()
          .addListener('remove_at', () => this.emitCurrentShapes());
      },
    );

    // MARKER
    google.maps.event.addListener(
      drawingManager,
      'markercomplete',
      (marker: google.maps.Marker) => {
        if (this.marker) this.marker.setMap(null);
        this.marker = marker;
        this.marker.setDraggable(true);

        const label =
          prompt('Nome do local ou ponto:', 'Ponto sem nome') ||
          'Ponto sem nome';

        addShapeToList(marker, 'marker', label);
        this.fitMapToShapes();

        const location: MapLocation = {
          label,
        };

        const content = this.createInfoWindowContent(location, () => {
          marker.setMap(null);
          this.removeShape(marker);
        });

        const infoWindow = new google.maps.InfoWindow({
          content,
        });

        marker.addListener('mouseover', () => {
          if (this.activeInfoWindow) {
            this.activeInfoWindow.close();
          }
          infoWindow.open(this.map, marker);
          this.activeInfoWindow = infoWindow;
        });

        marker.addListener('mouseout', () => {
          if (this.activeInfoWindow === infoWindow) {
            infoWindow.close();
            this.activeInfoWindow = null;
          }
        });

        

        marker.addListener('dragend', () => {
          this.emitCurrentShapes();
          const pos = marker.getPosition();
          if (pos) this.emitCoords(pos.lat(), pos.lng());
        });

        this.creatable = false;
        this.destroyDrawingManager();
      },
    );
  }

  private destroyDrawingManager() {
    if(!this.map || !this.drawingManager) return;

    this.drawingManager.setMap(null);
    this.drawingManager = null;
  }

  private clearHighlight() {
    if (this.highlightedPolygon) {
      this.highlightedPolygon.setMap(null);
      this.highlightedPolygon = null;
    }
  }

  generateId(): string {
    return Math.random().toString(36).substring(2, 10) + Date.now().toString(36);
  }

  findDrawingByShape(shape: LocationShapeData): google.maps.Polygon | google.maps.Marker | null {
    return this.drawnShapes.find((s) => s.id === shape.id)?.mapObject || null;
  }
}