/* eslint-disable @angular-eslint/prefer-inject */
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  Diagnosis,
  DiagnosisFacade,
  AuthFacade
} from '@farm/core';

@Injectable({ providedIn: 'root' })
export class FarmMapViewComponentFacade {
    private loadingSubject = new BehaviorSubject<boolean>(false);
    private diagnosisSubject = new BehaviorSubject<Diagnosis[]>([]);
    
    userId: string | undefined;

    loading$: Observable<boolean> = this.loadingSubject.asObservable();
    diagnoses$: Observable<Diagnosis[]> = this.diagnosisSubject.asObservable();

    constructor(
        private diagnosisFacade: DiagnosisFacade, 
        private authFacade: AuthFacade,
    ) {}

    load() {
        const data = this.authFacade.decodedToken;

        this.userId = data.nameid;

        this.loadingSubject.next(true);

        this.diagnosisFacade
        .getAllDiagnoses(this.userId)
        .pipe(
            tap(
            (diagnosisData) => {
                this.diagnosisSubject.next(diagnosisData);
                this.loadingSubject.next(false);
            },
            () => {
                this.loadingSubject.next(false);
            },
            ),
        )
        .subscribe();
    }
}