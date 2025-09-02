import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { switchMap } from 'rxjs/operators';

import {
  ReportInput,
  ReportFacade,
  ReportData,
  ExpenseCategoryLabels,
  RevenueSourceLabels,
} from '@farm/core';
import { Router } from '@angular/router';

interface Result {
  classe: string;
  conf: number;
}

interface ApiResponse {
  results: Result[];
  id: string;
}

export interface ItemCompare {
  images_book: string;
  similarity: number;
}

export type ResponseCompare = ItemCompare[];

@Injectable({ providedIn: 'root' })
export class ReportComponentFacade {
  private loadingSubject = new BehaviorSubject<boolean>(false);

  private revenueAndExpenseSubject = new BehaviorSubject<ReportData | null>(
    null,
  );

  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  expenseAndRevenueData$: Observable<ReportData | null> =
    this.revenueAndExpenseSubject.asObservable();

  constructor(
    private reportFacade: ReportFacade,
    private router: Router,
    private http: HttpClient,
  ) {}

  load(reportInput: ReportInput) {
    this.loadingSubject.next(true);

    this.reportFacade
      .getReportData(reportInput)
      .pipe(
        tap(
          (reportData) => {
            const translatedData = this.translateReportData(reportData);
            this.revenueAndExpenseSubject.next(translatedData);
            this.loadingSubject.next(false);
          },
          (error) => {
            const code = error.code;
            // if (code === 400 || code === 404) this.router.navigate(['/404']);
          },
        ),
      )
      .subscribe();
  }

  submit(reportInput: ReportInput) {
    this.load(reportInput);
  }

  private apiUrl = 'http://localhost:5000/compare';

  compareStaticImage(): Observable<ResponseCompare> {
    return this.http.get<ResponseCompare>(this.apiUrl);
  }

  private translateReportData(data: ReportData): ReportData {
    return {
      ...data,
      expenses: (data.expenses ?? []).map((item) => {
        const categoryKey = item.category as keyof typeof ExpenseCategoryLabels;
        return {
          ...item,
          label: ExpenseCategoryLabels[categoryKey] ?? item.category,
        };
      }),
      revenues: (data.revenues ?? []).map((item) => {
        const sourceKey = item.source as keyof typeof RevenueSourceLabels;
        return {
          ...item,
          label: RevenueSourceLabels[sourceKey] ?? item.source,
        };
      }),
    };
  }
}
