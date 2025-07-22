import {
  ApplicationConfig,
  importProvidersFrom,
  provideZoneChangeDetection,
} from '@angular/core';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideRouter } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { appRoutes } from './app.routes';
import { providePrimeNG } from 'primeng/config';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { ConfirmationService, MessageService } from 'primeng/api';
import { provideTranslateService } from '@ngx-translate/core';
import { translations } from './translations';
import { Environment, interceptorsProviders } from '@farm/core';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import Aura from '@primeng/themes/aura';
import { TooltipModule } from 'primeng/tooltip';
import { APP_CONFIG } from '@farm/core';

export const appConfig: ApplicationConfig = {
  providers: [
    { provide: APP_CONFIG, useValue: environmentFactory() },
    provideAnimations(),
    provideAnimationsAsync(),
    provideRouter(appRoutes),
    importProvidersFrom(HttpClientModule),
    interceptorsProviders,
    {
      provide: 'LOCALSTORAGE',
      useValue: window.localStorage,
    },
    providePrimeNG({
      theme: {
        preset: Aura,
        options: {
          darkModeSelector: '.farm-dark',
        },
      },
      translation: translations.pt,
    }),
    JwtHelperService,
    {
      provide: JWT_OPTIONS,
      useFactory: jwtOptionsFactory,
    },
    MessageService,
    ConfirmationService,
    provideTranslateService({
      defaultLanguage: 'pt',
      useDefaultLang: true,
    }),
    provideZoneChangeDetection({ eventCoalescing: true }),
    TooltipModule,
  ],
};

function environmentFactory(): Environment {
  let env: Environment = {
    production: false,
    jwtToken: '',
    allowedDomains: [],
    authApiUrl: '',
    usersApiUrl: '',
    clientId: '',
    redirectUri: '',
    apiUrl: '',
    googleMapsApiKey: '',
  };

  try {
    env = require('./environments/environment.json');
  } catch {
    env = require('./environments/environment.prod.json');
  }
  // env = require('./environments/environment.json');
  return env;
}

export function jwtOptionsFactory() {
  return {
    tokenGetter: () => {
      return environmentFactory().jwtToken;
    },
    allowedDomains: environmentFactory().allowedDomains,
  };
}
