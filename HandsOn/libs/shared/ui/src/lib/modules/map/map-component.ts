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
  OnInit,
  OnDestroy,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { Geolocation } from '@capacitor/geolocation';
import { ButtonComponent } from '../../components/button/button.component';
import { GoogleMapsService, 
  LocationShapeData, 
  MapElement, 
  MapLocation, 
  MapStateService 
} from '@farm/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Subscription } from 'rxjs';
import { Marker } from 'leaflet';

@Component({
  selector: 'lib-map-component',
  standalone: true,
  imports: [CommonModule, ButtonComponent],
  templateUrl: './map-component.html',
  styleUrls: ['./map-component.css'],
})
export class MapComponent implements AfterViewInit, OnChanges, OnInit, OnDestroy {
  private activeInfoWindow: google.maps.InfoWindow | null = null;
  @Input() mapElements?: MapElement[];
  @Input() editingElementId: string | null = null;
  @Input() creatingShape: { id: string; classType?: 'farm' | 'plot' | 'diagnosis' } | null = null;

  @ViewChild('mapContainer', { static: false }) mapElementRef!: ElementRef;

  @Output() setFocusByDrawing = new EventEmitter<google.maps.Marker | google.maps.Polygon>();
  @Output() shapeChanged = new EventEmitter<MapElement>();
  
  constructor(
      private router: Router,
      private mapState: MapStateService
    ) {}

  private readonly googleMapsService = inject(GoogleMapsService);

  map!: google.maps.Map;
  marker!: google.maps.Marker;

  loading = false;
  error: string | null = null;

  private highlightedPolygon: google.maps.Polygon | null = null;
  private mapReady = false;
  private sub = new Subscription();
  private elements: MapElement[] = [];
  private drawingEditing: MapElement | null = null;
  private drawingCreating: MapElement | null = null;
  private originalCoordinates: { lat: number; lng: number }[] | null = null;
  private creationOverlayListener: google.maps.MapsEventListener | null = null;
  private drawingManager: google.maps.drawing.DrawingManager | null = null;

  private mapReadySubject = new BehaviorSubject<boolean>(false);
  mapReady$ = this.mapReadySubject.asObservable();

  ngAfterViewInit() {
    this.googleMapsService.loadGoogleMaps().then(async () => {
      const coords = await this.getInitialCoordinates();
      this.initMap(coords.latitude, coords.longitude);

      this.mapReady = true;
      this.mapReadySubject.next(true);
    });
  }

  ngOnInit(): void {
    this.sub = new Subscription();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['editingElementId'] && this.editingElementId) {
      if (this.activeInfoWindow) {
        this.activeInfoWindow.close();
        this.activeInfoWindow = null;
      }
      this.applyEditingMode(changes['editingElementId'].currentValue);
    }

    if (changes['creatingShape'] && this.creatingShape) {
      if (this.activeInfoWindow) {
        this.activeInfoWindow.close();
        this.activeInfoWindow = null;
      }
      this.applyCreatingMode(changes['creatingShape'].currentValue);
    }
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  syncElements(shapes: MapElement[]) {
    if (!this.map) return;

    this.clearAllMapObjects();

    shapes.forEach((shape) => {
      if (shape.hasShapes === false || shape.visible === false || shape.hideShapeOnly === true) {
        return; 
      }

      if (!shape.id) {
        shape.id = this.generateId();
      }

      if (shape.type === 'polygon' && 
        shape.info?.coordinates && 
        shape.info.coordinates.length > 0
      ) {
        const path = shape.info.coordinates.map(
          (coord: any) => new google.maps.LatLng(coord.lat, coord.lng),
        );

        const polygon = new google.maps.Polygon({
          paths: path,
          fillColor: shape.color || '#FF0000',
          fillOpacity: 0.35,
          strokeWeight: 2,
          editable: shape.editable,
          draggable: false,
          map: this.map,
        });

        shape.mapObject = polygon;

        const centroid = this.getPolygonCenter(polygon);

        const content = this.createInfoWindowContent(shape);

        const infoWindow = new google.maps.InfoWindow({
          content,
          position: centroid,
        });

        polygon.addListener('mouseover', (e: google.maps.MapMouseEvent) => {
          if (this.editingElementId || this.creatingShape) return;
          if (this.activeInfoWindow) {
            this.activeInfoWindow.close();
          }
          
          infoWindow.setPosition(e.latLng);
          infoWindow.open(this.map);
          this.activeInfoWindow = infoWindow;
        });

        polygon.addListener('mouseout', () => {
          if (this.editingElementId || this.creatingShape) return;
          if (this.activeInfoWindow === infoWindow) {
            infoWindow.close();
            this.activeInfoWindow = null;
          }
        });

        polygon.addListener('click', () => {
          this.clearHighlight();

          this.setFocus(shape);

          this.setFocusByDrawing.emit(shape.mapObject);
        });

      } else if (shape.type === 'marker' && 
        shape.info?.coordinates && 
        shape.info.coordinates.length > 0
      ) {
        const pos = new google.maps.LatLng(
          shape.info.coordinates[0].lat,
          shape.info.coordinates[0].lng,
        );

        const marker = new google.maps.Marker({
          position: pos,
          draggable: false,
          map: this.map,
        });

        shape.mapObject = marker;

        const content = this.createInfoWindowContent(shape);

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
      }
    });

    this.elements = shapes;

    this.map.addListener('click', (e: google.maps.MapMouseEvent) => {
      this.clearHighlight();
    });

    this.fitMapToShapes();
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

    this.mapReady = true;

    this.map.addListener('click', () => {
      if (this.activeInfoWindow) {
        this.activeInfoWindow.close();
        this.activeInfoWindow = null;
      }
    });
  }

  private createInfoWindowContent(location: MapElement): HTMLElement {
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

      addLine('Doença', info.diseaseName);
      addLine('Data', info.date ? new Date(info.date).toLocaleDateString() : undefined);
      addLine('Área total (ha)', info.totalArea?.toFixed(2));
      addLine('Área afetada (ha)', info.affectedArea?.toString());
      addLine('Fazenda', info.farmName);
      addLine('Talhão', info.plotName);
      addLine('Colheita', info.harvestName);
      const statusName = info.status === 'Processing' ? 'Em processamento' : info.status === 'Processed' ? 'Processado' : 'Desconhecido';
      addLine('Status', statusName);
      addLine('Coordenadas', info.coordinates ? info.coordinates.map(c => `(${c.lat.toFixed(4)}, ${c.lng.toFixed(4)})`).join('; ') : undefined);
      addLine('Foto', info.photoUrl ? `<img src="${info.photoUrl}" alt="Foto" style="max-width: 100%; height: auto; border-radius: 4px;">` : undefined);

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

    if (footer.children.length > 0) content.appendChild(footer);

    return content;
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

  private getPolygonCenter(polygon: google.maps.Polygon): google.maps.LatLng {
    const bounds = new google.maps.LatLngBounds();
    polygon.getPath().forEach((latLng) => bounds.extend(latLng));
    return bounds.getCenter();
  }

  private fitMapToShapes(): void {
    if (this.elements.length === 0) return;

    const bounds = new google.maps.LatLngBounds();

    this.elements.forEach(({ mapObject, type }) => {
      if (type === 'marker' && mapObject instanceof google.maps.Marker) {
        const pos = mapObject.getPosition();
        if (pos) bounds.extend(pos);
      }
      if (type === 'polygon' && mapObject instanceof google.maps.Polygon) {
        mapObject.getPath().forEach((latLng) => bounds.extend(latLng));
      }
    });

    if (this.elements.length === 1) {
      this.map.setCenter(bounds.getCenter());

      this.map.setZoom(15);
    } else {
      this.map.fitBounds(bounds);
    }
  }

  navigateToViewDiagnosis(id: string): void {
    this.router.navigate([`/app/diagnoses/diagnosis/${id}/result`]);
  }

  setFocus(shape: MapElement, highlight: boolean | undefined = true) {
    const drawing = shape.mapObject;
    if (!drawing) return;

    if (shape.type === 'polygon' && drawing instanceof google.maps.Polygon) {
      const bounds = new google.maps.LatLngBounds();

      if (shape.info?.coordinates) {
        shape.info.coordinates.forEach(coord =>
          bounds.extend(new google.maps.LatLng(coord.lat, coord.lng))
        );
      }
      this.clearHighlight();

      if(highlight){
        this.highlightedPolygon = new google.maps.Polygon({
          paths: drawing.getPath(),  
          strokeColor: '#00FF7F',
          strokeOpacity: 1,
          strokeWeight: 4,
          fillOpacity: 0,
          zIndex: 9999,
          map: this.map,
        });
      }

      this.map.fitBounds(bounds);
    }

    else if (shape.type === 'marker' && shape.info?.coordinates) {
      const position = new google.maps.LatLng(
        shape.info.coordinates[0].lat,
        shape.info.coordinates[0].lng
      );

      this.map.setCenter(position);
      this.map.setZoom(17);
    }
    
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

  clearAllMapObjects() {
    if (!this.elements) return;

    this.elements.forEach(el => {
      if (el.mapObject) {
        el.mapObject.setMap(null);
      }
    });
  }

  private applyEditingMode(editingId: string | null) {
    if (!this.map || !this.elements) return;

    // Finaliza edição ativa
    if (this.drawingEditing) {
      this.finishEditing(false);
    }

    if (!editingId) return;

    const element = this.elements.find(e => e.id === editingId);
    if (!element || !element.mapObject) return;

    this.drawingEditing = element;

    this.setFocus(element, false);

    // ===== POLYGON =====
    if (element.type === 'polygon') {
      const polygon = element.mapObject as google.maps.Polygon;

      polygon.setEditable(true);

      this.originalCoordinates = [];

      const path = polygon.getPath();
      for (let i = 0; i < path.getLength(); i++) {
        const p = path.getAt(i);
        this.originalCoordinates.push({ lat: p.lat(), lng: p.lng() });
      }
    }

    // ===== MARKER =====
    else if (element.type === 'marker') {
      const marker = element.mapObject as google.maps.Marker;

      marker.setDraggable(true);

      const pos = marker.getPosition();
      this.originalCoordinates = pos
        ? [{ lat: pos.lat(), lng: pos.lng() }]
        : null;
    }
  }

  private applyCreatingMode(creating: { id: string; classType?: 'farm' | 'plot' | 'diagnosis' } | null) {
    if (!this.map) return;

    if (this.drawingCreating) {
      this.finishCreating(false);
    }

    if (!creating) {
      this.destroyDrawingManager();
      return;
    }

    this.enableDrawingManager(creating.id, creating.classType);
  }

  private finishEditing(saved: boolean) {
    if (!this.drawingEditing) return;

    const obj = this.drawingEditing.mapObject;

    if (this.drawingEditing.type === 'polygon') {
      (obj as google.maps.Polygon).setEditable(false);
    } else if (this.drawingEditing.type === 'marker') {
      (obj as google.maps.Marker).setDraggable(false);
    }

    this.drawingEditing = null;
    this.originalCoordinates = null;
  }

  public saveEditing() {
    if (!this.drawingEditing) return;

    let updatedCoords: { lat: number; lng: number }[] = [];

    if (this.drawingEditing.type === 'polygon') {
      const polygon = this.drawingEditing.mapObject as google.maps.Polygon;
      const path = polygon.getPath();

      updatedCoords = [];
      for (let i = 0; i < path.getLength(); i++) {
        const p = path.getAt(i);
        updatedCoords.push({ lat: p.lat(), lng: p.lng() });
      }
    }

    else if (this.drawingEditing.type === 'marker') {
      const marker = this.drawingEditing.mapObject as google.maps.Marker;
      const pos = marker.getPosition();

      if (pos) {
        updatedCoords = [{ lat: pos.lat(), lng: pos.lng() }];
      }
    }

    const updated: MapElement = {
      ...this.drawingEditing,
      info: {
        ...this.drawingEditing.info,
        coordinates: updatedCoords
      }
    };

    this.shapeChanged.emit(updated);

    this.finishEditing(true);
  }

  public cancelEditing() {
    if (!this.drawingEditing || !this.originalCoordinates) return;

    // ===== POLYGON =====
    if (this.drawingEditing.type === 'polygon') {
      const polygon = this.drawingEditing.mapObject as google.maps.Polygon;
      const path = polygon.getPath();

      // limpa
      while (path.getLength() > 0) {
        path.removeAt(0);
      }

      // restaura
      this.originalCoordinates.forEach(coord => {
        path.push(new google.maps.LatLng(coord.lat, coord.lng));
      });
    }

    // ===== MARKER =====
    else if (this.drawingEditing.type === 'marker') {
      const marker = this.drawingEditing.mapObject as google.maps.Marker;
      const coord = this.originalCoordinates[0];

      marker.setPosition(new google.maps.LatLng(coord.lat, coord.lng));
    }

    this.finishEditing(false);
  }

  private enableDrawingManager(creatingId: string, classType?: 'farm' | 'plot' | 'diagnosis') {
    this.destroyDrawingManager();

    const drawingManager = new google.maps.drawing.DrawingManager({
      drawingMode: null,
      drawingControl: true,
      drawingControlOptions: {
        position: google.maps.ControlPosition.TOP_CENTER,
        drawingModes: [
          ...(classType === 'diagnosis' ? [google.maps.drawing.OverlayType.MARKER] : []),
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

    google.maps.event.addListener(
      drawingManager,
      'polygoncomplete',
      (polygon: google.maps.Polygon) => {
        const label =
          prompt('Nome do polígono:', 'Polígono sem nome') ||
          'Polígono sem nome';

        const shapeData: MapElement = {
          id: creatingId,
          type: 'polygon',
          label,
          class: classType,
          info: {
            id: creatingId,
            coordinates: polygon.getPath().getArray().map(latLng => ({
              lat: latLng.lat(),
              lng: latLng.lng(),
            })),
          },
        };

        this.shapeChanged.emit(shapeData);

        this.finishCreating(true);
      },
    );

    if (classType === 'diagnosis'){
      google.maps.event.addListener(
        drawingManager,
        'markercomplete',
        (marker: google.maps.Marker) => {
          const label =
            prompt('Nome do local ou ponto:', 'Ponto sem nome') ||
            'Ponto sem nome';
  
          const shapeData: MapElement = {
            id: creatingId,
            type: 'marker',
            class: 'diagnosis',
            label,
            info: {
              id: creatingId,
              coordinates: [{
                lat: marker.getPosition()?.lat() || 0,
                lng: marker.getPosition()?.lng() || 0,
              }],
            },
          };
  
          this.shapeChanged.emit(shapeData);
  
          this.finishCreating(true);
        },
      );
    }
  }
  
  public cancelCreating() {
    if (!this.drawingCreating) return;

    this.finishCreating(false);
  }

  private finishCreating(saved: boolean) {
    if (this.drawingCreating) {
      if (!saved) {
        this.drawingCreating.mapObject.setMap(null);
      }
      this.drawingCreating = null;
    }
    this.mapState.stopCreatingShape();
    this.destroyDrawingManager();
  }

}