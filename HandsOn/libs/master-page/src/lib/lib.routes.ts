import { Route } from '@angular/router';
import { AuthenticatedGuard, IsAdminGuard } from '@farm/core';

export const masterPageRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./master-page/master-page.component').then(
        (m) => m.MasterPageComponent,
      ),
    canActivate: [AuthenticatedGuard],
    children: [
      {
        path: '',
        loadChildren: () =>
          import('@farm/dashboard').then((m) => m.dashboardRoutes),
      },
      {
        path: 'users',
        loadChildren: () => import('@farm/users').then((m) => m.usersRoutes),
        canActivate: [IsAdminGuard],
      },
      {
        path: 'settings',
        loadChildren: () =>
          import('@farm/settings').then((m) => m.settingsRoutes),
      },
      {
        path: 'finance',
        loadChildren: () =>
          import('@farm/finance').then((m) => m.financeRoutes),
      },
      {
        path: 'diagnoses',
        loadChildren: () =>
          import('@farm/diagnoses').then((m) => m.diagnosesRoutes),
      },
      {
        path: 'farmMapView',
        loadChildren: () =>
          import('@farm/farmMapView').then((m) => m.farmMapViewRoutes),
      },
      {
        path: '**',
        redirectTo: 'not-found',
      },
    ],
  },
];
