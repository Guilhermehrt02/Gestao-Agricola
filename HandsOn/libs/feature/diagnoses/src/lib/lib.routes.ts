import { Route } from '@angular/router';

export const diagnosesRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./diagnoses/diagnoses').then((m) => m.Diagnoses),
    children: [
      {
        path: '',
        redirectTo: 'diagnoses',
        pathMatch: 'full',
      },
      {
        path: 'diagnosis',
        loadChildren: () =>
          import('@farm/diagnosis').then((m) => m.diagnosisRoutes),
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
    ],
  },
];
