import { Injectable } from '@angular/core';
import { RequestService } from '../request/request.service';
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';
import { catchError } from 'rxjs';
import { Plot } from '../../models/plot.model';

@Injectable({
  providedIn: 'root'
})
export class PlotService extends RequestService {
    httpOptionsBypassInterceptor = {
        ...this.httpOptions,
        context: new HttpContext().set(BYPASS_INTERCEPTORS, false),
    };

    getPlotsByFarm(farmId: string) {
        return this.httpClient
            .get<Plot[]>(`${this.apiUrl}/plot/farm/${farmId}`, this.httpOptionsBypassInterceptor)
            .pipe(catchError(this.handleError));
    }

    updatePlot(plot: Plot) {
        return this.httpClient
            .put<Plot>(`${this.apiUrl}/plot/${plot.id}`, JSON.stringify(plot), this.httpOptions)
            .pipe(catchError(this.handleError));
    }
}