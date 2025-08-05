

import { provideHttpClient } from '@angular/common/http'; // ✅ IMPORTANTE
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { ApplicationConfig, provideBrowserGlobalErrorListeners, provideZoneChangeDetection } from '@angular/core';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient() // ✅ ESTO HABILITA HttpClient EN TODA LA APP
  ]
};
