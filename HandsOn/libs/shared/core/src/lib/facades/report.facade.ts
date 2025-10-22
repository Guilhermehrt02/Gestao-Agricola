/* eslint-disable @angular-eslint/prefer-inject */
import { Injectable } from '@angular/core';
import { ReportService } from '../services/reports/report.service';
import { NotificationService } from '../services/notification/notification.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ReportInput } from '../models/report-input.model';
import { ReportData } from '../models/report-data.model';

@Injectable({ 
    providedIn: 'root' 
})
export class ReportFacade {
    private reportDataSubject = new BehaviorSubject<ReportData | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(true);
  
    reportData$: Observable<ReportData | null> = this.reportDataSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();
  
    constructor(
      private reportService: ReportService,
      private notificationService: NotificationService
    ) {}
  
    getReportData(reportInput: ReportInput): Observable<ReportData> {
      this.loadingSubject.next(true);
      return this.reportService.fetchReportData(reportInput).pipe(
        tap({
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível carregar os dados do relatório!'
            );
          },
        })
      );
    }
  }