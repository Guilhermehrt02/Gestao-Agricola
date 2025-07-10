import {
  Component,
  Input,
  Output,
  EventEmitter,
  AfterViewInit,
  ViewChild,
  ElementRef,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import * as L from 'leaflet';

@Component({
  selector: 'lib-map-selector',
  imports: [CommonModule],
  templateUrl: './map-selector.html',
  styleUrl: './map-selector.css',
})
export class MapSelectorComponent implements AfterViewInit {
  @Input() initialCoords: { lat: number; lng: number } | null = null;
  @Input() readonly = false;
  @Output() coordinatesSelected = new EventEmitter<{
    lat: number;
    lng: number;
  }>();

  @ViewChild('map') mapElement!: ElementRef<HTMLDivElement>;

  private map!: L.Map;
  private marker!: L.Marker;

  ngAfterViewInit(): void {
    this.initMap();
  }

  private initMap(): void {
    this.map = L.map(this.mapElement.nativeElement).setView([0, 0], 15);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '© OpenStreetMap',
    }).addTo(this.map);

    if (this.initialCoords) {
      this.setMarker(this.initialCoords.lat, this.initialCoords.lng);
      this.map.setView([this.initialCoords.lat, this.initialCoords.lng], 17);
    } else {
      this.setCurrentLocation();
    }

    if (!this.readonly) {
      this.map.on('click', (e: L.LeafletMouseEvent) => {
        const { lat, lng } = e.latlng;
        this.setMarker(lat, lng);
        this.coordinatesSelected.emit({ lat, lng });
      });
    }

    setTimeout(() => {
      this.map.invalidateSize();
    }, 0);
  }

  private setMarker(lat: number, lng: number): void {
    if (this.marker) {
      this.marker.setLatLng([lat, lng]);
    } else {
      this.marker = L.marker([lat, lng]).addTo(this.map);
    }
  }

  private setCurrentLocation(): void {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          const { latitude, longitude } = position.coords;
          this.map.setView([latitude, longitude], 17);
        },
        () => {
          this.map.setView([0, 0], 2);
        },
      );
    } else {
      this.map.setView([0, 0], 2);
    }
  }
}
