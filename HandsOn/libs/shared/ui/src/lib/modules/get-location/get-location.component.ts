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

    this.marker = new google.maps.Marker({
      position: center,
      map: this.map,
      draggable: true,
    });

    this.emitCoords(lat, lng);

    this.map.addListener('click', (event: google.maps.MapMouseEvent) => {
      const coords = event.latLng!;
      this.marker.setPosition(coords);
      this.emitCoords(coords.lat(), coords.lng());
    });

    this.marker.addListener('dragend', () => {
      const pos = this.marker.getPosition();
      if (pos) this.emitCoords(pos.lat(), pos.lng());
    });
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
      this.marker.setPosition(
        new google.maps.LatLng(coords.latitude, coords.longitude),
      );
      this.emitCoords(coords.latitude, coords.longitude);
    } catch (err) {
      this.error = 'Não foi possível obter sua localização.';
      console.error(err);
    } finally {
      this.loading = false;
    }
  }
}
