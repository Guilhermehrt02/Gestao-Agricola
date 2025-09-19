import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { RequestService } from '../request/request.service';
import { Diagnosis } from '../../models/diagnosis.model'; 
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';

@Injectable({
    providedIn: 'root',
})
export class DiagnosisService extends RequestService {
    httpOptionsBypassInterceptor = {
        ...this.httpOptions,
        context: new HttpContext().set(BYPASS_INTERCEPTORS, false),
    };

    getAllDiagnoses(userId: string) {
        return this.httpClient
            .get<Diagnosis[]>(`${this.apiUrl}/diagnosis/user/${userId}`, this.httpOptionsBypassInterceptor)
            .pipe(catchError(this.handleError));
    }

    getDiagnosisById(id: string) {
        return this.httpClient
            .get<Diagnosis>(`${this.apiUrl}/diagnosis/${id}`, this.httpOptions)
            .pipe(catchError(this.handleError));
    }

    createDiagnosis(diagnosis: Diagnosis) {
        return this.httpClient
            .post<Diagnosis>(`${this.apiUrl}/diagnosis`, JSON.stringify(diagnosis), this.httpOptions)
            .pipe(catchError(this.handleError));
    }

    updateDiagnosis(diagnosis: Diagnosis) {
        return this.httpClient
            .put<Diagnosis>(`${this.apiUrl}/diagnosis/${diagnosis.id}`, JSON.stringify(diagnosis), this.httpOptions)
            .pipe(catchError(this.handleError));
    }

    deleteDiagnosis(id: string) {
        return this.httpClient
            .delete<void>(`${this.apiUrl}/diagnosis/${id}`, this.httpOptions)
            .pipe(catchError(this.handleError));
    }

}