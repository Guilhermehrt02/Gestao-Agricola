import {
  Component,
  ElementRef,
  EventEmitter,
  Output,
  AfterViewInit,
  ViewChild,
  inject,
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
export class GetLocationComponent implements AfterViewInit {
  @ViewChild('mapContainer', { static: false }) mapElementRef!: ElementRef;

  @Output() locationDetected = new EventEmitter<{
    latitude: number;
    longitude: number;
  }>();

  private readonly googleMapsService = inject(GoogleMapsService);

  map!: google.maps.Map;
  marker!: google.maps.Marker;

  loading = false;
  error: string | null = null;

  private drawnShapes: google.maps.MVCObject[] = [];

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

    const addShapeToList = (shape: google.maps.MVCObject) => {
      this.drawnShapes.push(shape);
    };

    // Polygon
    google.maps.event.addListener(
      drawingManager,
      'polygoncomplete',
      (polygon: google.maps.Polygon) => {
        addShapeToList(polygon);
        const path = polygon.getPath().getArray();
        const coordinates = path.map((p) => ({ lat: p.lat(), lng: p.lng() }));
        //console.log('Área desenhada:', coordinates);
      },
    );
    
    google.maps.event.addListener(
    drawingManager,
    'markercomplete',
    (marker: google.maps.Marker) => {
      // Remove marcadores anteriores
      this.drawnShapes = this.drawnShapes.filter((shape) => {
        if (shape instanceof google.maps.Marker) {
          shape.setMap(null); 
          return false; 
        }
        return true; 
      });

      addShapeToList(marker);

      //console.log('Marcador desenhado:', marker.getPosition()?.toJSON());
      console.log(this.drawnShapes);
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
    this.drawnShapes.forEach(shape => {
      if ('setMap' in shape && typeof (shape as any).setMap === 'function') {
        (shape as google.maps.Marker | google.maps.Polygon).setMap(null);
      }
    });
    this.drawnShapes = [];
  }

}
