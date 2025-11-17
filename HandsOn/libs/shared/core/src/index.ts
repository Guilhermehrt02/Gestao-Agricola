import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthenticationInterceptor } from './lib/interceptors/authentication/authentication.interceptor';

// config
export * from './lib/config/app-config.token';

// models
export * from './lib/models/environment.model';
export * from './lib/models/token.model';
export * from './lib/models/user.model';
export * from './lib/models/expense.model';
export * from './lib/models/revenue.model';
export * from './lib/models/report-data.model';
export * from './lib/models/expense-data-chart.model';
export * from './lib/models/report-input.model';
export * from './lib/models/revenue-data-chart.model';
export * from './lib/models/diagnosis.model';
export * from './lib/models/farm.model';
export * from './lib/models/harvest.model';
export * from './lib/models/plot.model';
export * from './lib/models/locationShape.model';
export * from './lib/models/mapLocation.model';
export * from './lib/models/farm-map-input.model';
export * from './lib/models/map-element.model';

// services
export * from './lib/services/authentication/authentication.service';
export * from './lib/services/confirmation/confirmation.service';
export * from './lib/services/notification/notification.service';
export * from './lib/services/request/request.service';
export * from './lib/services/user/user.service';
export * from './lib/services/expense/expense.service';
export * from './lib/services/revenue/revenue.service';
export * from './lib/services/reports/report.service';
export * from './lib/services/diagnosis/diagnosis.service';
export * from './lib/services/google-maps/google-maps.service';
export * from './lib/services/google-maps/Map-state.service';


// facades
export * from './lib/facades/auth.facade';
export * from './lib/facades/user.facade';
export * from './lib/facades/expense.facade';
export * from './lib/facades/revenue.facade';
export * from './lib/facades/report.facade';
export * from './lib/facades/upload.facade';
export * from './lib/facades/diagnosis.facade';
export * from './lib/facades/farm.facade';

// guards
export * from './lib/guards/authenticated/authenticated.guard';
export * from './lib/guards/is-admin/is-admin.guard';

// interceptors
export const interceptorsProviders = [
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthenticationInterceptor,
    multi: true,
  },
];

export { BYPASS_INTERCEPTORS } from './lib/interceptors/authentication/authentication.interceptor';

// utils
export * from './lib/utils/form-validators';
export * from './lib/utils/google-maps-loader';

// enums
export * from './lib/enums/user-roles.enum';
export * from './lib/enums/user-status.enum';
export * from './lib/enums/expense-category.enum';
export * from './lib/enums/revenue-source.enum';
export * from './lib/enums/payment-method.enum';
export * from './lib/enums/diagnosis-status.enum';
export * from './lib/enums/diagnosis-uploadType.enum';
