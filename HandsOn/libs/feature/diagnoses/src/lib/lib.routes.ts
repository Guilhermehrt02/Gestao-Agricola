import { Route } from '@angular/router';

export const diagnosesRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./diagnoses/diagnoses').then((m) => m.Diagnoses),
    children: [
      {
        path: '',
        redirectTo: 'diagnosis',
        pathMatch: 'full',
      },
      {
        path: 'diagnosis',
        loadChildren: () =>
          import('@farm/diagnoses-list').then((m) => m.diagnosesListRoutes),
      },
      {
        path: 'diagnosis/create',
        loadChildren: () =>
          import('@farm/diagnosis').then((m) => m.diagnosisRoutes),
      },
      {
        path: 'diagnosis/:id',
        loadChildren: () =>
          import('@farm/diagnosis').then((m) => m.diagnosisRoutes),
      },
      {
        path: 'diagnosis/:id/result',
        loadChildren: () =>
          import('@farm/result').then((m) => m.resultRoutes),
      }
    ],
  },
];
