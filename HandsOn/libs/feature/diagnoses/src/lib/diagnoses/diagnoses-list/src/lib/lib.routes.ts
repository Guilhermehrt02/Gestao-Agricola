import { Route } from '@angular/router';
import { DiagnosesList } from './diagnoses-list/diagnoses-list';

export const diagnosesListRoutes: Route[] = [
  { path: '', component: DiagnosesList },
];
