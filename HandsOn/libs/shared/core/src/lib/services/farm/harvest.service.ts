import { Injectable } from '@angular/core';
import { RequestService } from '../request/request.service';
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';
import { catchError } from 'rxjs';
import { Harvest } from '../../models/harvest.model';

@Injectable({
  providedIn: 'root'
})
export class HarvestService extends RequestService {
    httpOptionsBypassInterceptor = {
        ...this.httpOptions,
        context: new HttpContext().set(BYPASS_INTERCEPTORS, false),
    };

    getHarvestsByFarm(farmId: string) {
        return this.httpClient
            .get<Harvest[]>(`${this.apiUrl}/harvest/farm/${farmId}`, this.httpOptionsBypassInterceptor)
            .pipe(catchError(this.handleError));
    }
}