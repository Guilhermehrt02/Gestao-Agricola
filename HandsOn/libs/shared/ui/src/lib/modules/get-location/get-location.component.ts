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
import { GoogleMapsService, LocationShapeData } from '@farm/core';

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
  @Input() setPositionFromParent?: { latitude: number; longitude: number };
  @Input() setShapesFromParent?: LocationShapeData[];

  @ViewChild('mapContainer', { static: false }) mapElementRef!: ElementRef;

  @Output() locationDetected = new EventEmitter<{
    latitude: number;
    longitude: number;
  }>();

  @Output() shapesDrawn = new EventEmitter<any[]>();

  private readonly googleMapsService = inject(GoogleMapsService);

  map!: google.maps.Map;
  marker!: google.maps.Marker;

  loading = false;
  error: string | null = null;

  drawnShapes: Array<{
    mapObject: google.maps.Polygon | google.maps.Marker;
    type: string;
    label: string;
  }> = [];

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

    if(!this.editable) return;

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
        draggable: true,
      },
    });

    drawingManager.setMap(this.map);

    const addShapeToList = (
      shapeObj: google.maps.Polygon | google.maps.Marker,
      type: string,
      label: string,
    ) => {
      this.drawnShapes.push({ mapObject: shapeObj, type, label });
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

        const content = this.createInfoWindowContent(label, () => {
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

        const content = this.createInfoWindowContent(label, () => {
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
    label: string,
    onDelete: () => void,
  ): HTMLElement {
    const content = document.createElement('div');
    content.style.backgroundColor = 'white';
    content.style.color = 'black';
    content.style.padding = '8px';
    content.style.borderRadius = '4px';
    content.style.border = '1px solid #ccc';
    content.style.fontSize = '14px';
    content.style.display = 'flex';
    content.style.justifyContent = 'space-between';
    content.style.alignItems = 'center';
    content.style.gap = '8px';
    content.style.maxWidth = '200px';

    const title = document.createElement('span');
    title.textContent = label;
    title.style.flex = '1';
    content.appendChild(title);

    if(this.editable){
      const closeBtn = document.createElement('button');
      closeBtn.textContent = '❌';
      closeBtn.style.cursor = 'pointer';
      closeBtn.style.backgroundColor = 'transparent';
      closeBtn.style.border = '1px solid #ccc';
      closeBtn.style.borderRadius = '4px';
      closeBtn.style.fontSize = '16px';
      closeBtn.style.padding = '0 6px';
      closeBtn.style.color = 'black';

      closeBtn.onclick = onDelete;
      content.appendChild(closeBtn);
    }

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
  }

  loadShapes(shapes: LocationShapeData[]) {
    shapes.forEach((shape) => {
      if (shape.type === 'polygon') {
        const path = shape.coordinates.map(
          (coord) => new google.maps.LatLng(coord.lat, coord.lng),
        );

        const polygon = new google.maps.Polygon({
          paths: path,
          fillColor: '#FF0000',
          fillOpacity: 0.35,
          strokeWeight: 2,
          editable: this.editable,
          draggable: this.editable,
          map: this.map,
        });

        this.drawnShapes.push({
          mapObject: polygon,
          type: 'polygon',
          label: shape.label,
        });

        const centroid = this.getPolygonCenter(polygon);

        const content = this.createInfoWindowContent(shape.label, () => {
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
          draggable: this.editable,
          map: this.map,
        });

        this.drawnShapes.push({
          mapObject: marker,
          type: 'marker',
          label: shape.label,
        });

        const content = this.createInfoWindowContent(shape.label, () => {
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

          this.emitCoords(
            marker.getPosition()!.lat(),
            marker.getPosition()!.lng(),
          );
        });
      }
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
        draggable: this.editable,
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
}