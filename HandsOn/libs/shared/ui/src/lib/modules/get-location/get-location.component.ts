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
import { GoogleMapsService } from '@farm/core';

@Component({
  selector: 'lib-get-location',
  standalone: true,
  imports: [CommonModule, ButtonComponent],
  templateUrl: './get-location.component.html',
  styleUrls: ['./get-location.component.css'],
})
export class GetLocationComponent implements AfterViewInit, OnChanges {
  @Input() setPositionFromParent?: { latitude: number; longitude: number };

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

  // private drawnShapes: google.maps.MVCObject[] = [];
  drawnShapes: (google.maps.Polygon | google.maps.Marker)[] = [];

  async ngAfterViewInit(): Promise<void> {
    await this.googleMapsService.loadGoogleMaps();

    const coords = await this.getInitialCoordinates();
    this.initMap(coords.latitude, coords.longitude);
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
      // fallback para São Paulo
      return { latitude: -23.5505, longitude: -46.6333 };
    }
  }

  initMap(lat: number, lng: number): void {
    const mapEl = this.mapElementRef.nativeElement;
    const center = new google.maps.LatLng(lat, lng);

    this.map = new google.maps.Map(mapEl, {
      center,
      zoom: 15,
    });

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

    const addShapeToList = (shape: google.maps.Polygon | google.maps.Marker) => {
      this.drawnShapes.push(shape);
      this.emitCurrentShapes();
    };

    // Utilitário para calcular o centro do polígono
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
        addShapeToList(polygon);

        const label = prompt('Nome do polígono:', 'Polígono sem nome') || 'Polígono sem nome';

        const centroid = getPolygonCenter(polygon);

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

        const closeBtn = document.createElement('button');
        closeBtn.textContent = '❌';
        closeBtn.style.cursor = 'pointer';
        closeBtn.style.backgroundColor = 'transparent';
        closeBtn.style.border = '1px solid #ccc';
        closeBtn.style.borderRadius = '4px';
        closeBtn.style.fontSize = '16px';
        closeBtn.style.padding = '0 6px';
        closeBtn.style.color = 'black';

        const infoWindow = new google.maps.InfoWindow({
          content,
          position: centroid,
        });

        closeBtn.onclick = () => {
          infoWindow.close();
          polygon.setMap(null);
          this.drawnShapes = this.drawnShapes.filter(s => s !== polygon);
          this.emitCurrentShapes();
        };

        content.appendChild(title);
        content.appendChild(closeBtn);

        polygon.addListener('click', (e: google.maps.MapMouseEvent) => {
          infoWindow.setPosition(e.latLng);
          infoWindow.open(this.map);
        });

        infoWindow.open(this.map);
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

        const pos = marker.getPosition();
        if (pos) this.emitCoords(pos.lat(), pos.lng());

        this.drawnShapes = this.drawnShapes.filter(
          (s) => !(s instanceof google.maps.Marker),
        );

        addShapeToList(marker);

        const label = prompt('Nome do local ou ponto:', 'Ponto sem nome') || 'Ponto sem nome';

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

        const closeBtn = document.createElement('button');
        closeBtn.textContent = '❌';
        closeBtn.style.cursor = 'pointer';
        closeBtn.style.backgroundColor = 'transparent';
        closeBtn.style.border = '1px solid #ccc';
        closeBtn.style.borderRadius = '4px';
        closeBtn.style.fontSize = '16px';
        closeBtn.style.padding = '0 6px';
        closeBtn.style.color = 'black';

        const infoWindow = new google.maps.InfoWindow({
          content,
        });

        closeBtn.onclick = () => {
          infoWindow.close();
          marker.setMap(null);
          this.drawnShapes = this.drawnShapes.filter(s => s !== marker);
          this.emitCurrentShapes();
        };

        content.appendChild(title);
        content.appendChild(closeBtn);

        marker.addListener('click', () => {
          infoWindow.open(this.map, marker);
        });

        infoWindow.open(this.map, marker);

        marker.addListener('dragend', () => {
          const newPos = marker.getPosition();
          if (newPos) this.emitCoords(newPos.lat(), newPos.lng());
        });
      },
    );
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
    this.drawnShapes.forEach((shape) => {
      if ('setMap' in shape && typeof (shape as any).setMap === 'function') {
        (shape as google.maps.Marker | google.maps.Polygon).setMap(null);
      }
    });
    this.drawnShapes = [];
    this.emitCurrentShapes();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (
      changes['setPositionFromParent'] &&
      this.setPositionFromParent &&
      this.map
    ) {
      const { latitude, longitude } = this.setPositionFromParent;
      this.placeOrMoveMarker(latitude, longitude, true);
    }
  }

  public placeOrMoveMarker(lat: number, lng: number, emit = false) {
    const position = new google.maps.LatLng(lat, lng);

    if (this.marker) {
      this.marker.setPosition(position);
    } else {
      this.marker = new google.maps.Marker({
        position,
        map: this.map,
        draggable: true,
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
    this.shapesDrawn.emit([...this.drawnShapes]);
  }
}
