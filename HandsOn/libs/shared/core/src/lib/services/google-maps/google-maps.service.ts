import { Injectable, inject } from '@angular/core';
import { APP_CONFIG } from '../../config/app-config.token';
import { Environment } from '../../models/environment.model';
import { loadGoogleMaps } from '../../utils/google-maps-loader';

@Injectable({
  providedIn: 'root'
})
export class GoogleMapsService {
  private readonly config = inject(APP_CONFIG) as Environment;
  private isLoaded = false;

  async loadGoogleMaps(): Promise<void> {
    if (this.isLoaded) return;

    try {
      await loadGoogleMaps(this.config.googleMapsApiKey);
      this.isLoaded = true;
    } catch (error) {
      console.error('Erro ao carregar Google Maps:', error);
      throw error;
    }
  }

  isGoogleMapsLoaded(): boolean {
    return this.isLoaded && !!(window as any).google?.maps;
  }

  getGoogleMapsApiKey(): string {
    return this.config.googleMapsApiKey;
  }
}
