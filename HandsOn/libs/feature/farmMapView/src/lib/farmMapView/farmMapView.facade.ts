/* eslint-disable @angular-eslint/prefer-inject */
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  FarmMapInput,
  Diagnosis,
  DiagnosisFacade
} from '@farm/core';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class FarmMapViewComponentFacade {
    private loadingSubject = new BehaviorSubject<boolean>(false);

    private mapDataSubject = new BehaviorSubject<Diagnosis[] | null>(
      null,
    );

    loading$: Observable<boolean> = this.loadingSubject.asObservable();
    mapData$: Observable<Diagnosis[] | null> = this.mapDataSubject.asObservable();

    constructor(private diagnosisFacade: DiagnosisFacade, private router: Router) {}

    load(farmMapInput: FarmMapInput) {
        this.loadingSubject.next(true);

        this.diagnosisFacade
        .getDiagnosesByFilter(farmMapInput)
        .pipe(
            tap(
            (diagnosisData) => {
                this.mapDataSubject.next(diagnosisData);
                this.loadingSubject.next(false);
            },
            (error) => {
                const code = error.code;
                if (code === 400 || code === 404) this.router.navigate(['/404']);
            },
            ),
        )
        .subscribe();
    }

    submit(farmInput: FarmMapInput) {
        this.load(farmInput);
    }
}