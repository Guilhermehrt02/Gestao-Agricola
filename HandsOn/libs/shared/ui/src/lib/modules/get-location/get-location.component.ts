import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Geolocation } from '@capacitor/geolocation';
import { ButtonComponent } from '../../components/button/button.component';

@Component({
  selector: 'lib-get-location',
  imports: [CommonModule, ButtonComponent],
  templateUrl: './get-location.component.html',
  styleUrls: ['./get-location.component.css'],
})
export class GetLocationComponent  {
  loading = false;
  error: string | null = null;

  @Output() locationDetected = new EventEmitter<{ latitude: number; longitude: number }>();

  async detectLocation() {
    this.loading = true;
    this.error = null;

    try {
      const position = await Geolocation.getCurrentPosition();
      const { latitude, longitude } = position.coords;
      this.locationDetected.emit({ latitude, longitude });
    } catch (err) {
      this.error = 'Não foi possível obter a localização. Verifique as permissões.';
      console.error(err);
    } finally {
      this.loading = false;
    }
  }
}
