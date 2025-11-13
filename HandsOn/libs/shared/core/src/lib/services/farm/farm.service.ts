import { Injectable } from '@angular/core';
import { RequestService } from '../request/request.service';
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';
import { Farm } from '../../models/farm.model';
import { catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FarmService extends RequestService {
    httpOptionsBypassInterceptor = {
        ...this.httpOptions,
        context: new HttpContext().set(BYPASS_INTERCEPTORS, false),
    };

    getFarms() {
        return this.httpClient
            .get<Farm[]>(`${this.apiUrl}/farm`, this.httpOptionsBypassInterceptor)
            .pipe(catchError(this.handleError));
    }

    updateFarm(farm: Farm) {
        return this.httpClient
            .put<Farm>(`${this.apiUrl}/farm/${farm.id}`, JSON.stringify(farm), this.httpOptions)
            .pipe(catchError(this.handleError));
    }
}