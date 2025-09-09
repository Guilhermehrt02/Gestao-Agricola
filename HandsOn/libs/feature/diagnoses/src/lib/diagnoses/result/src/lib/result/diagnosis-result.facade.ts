/* eslint-disable @angular-eslint/prefer-inject */
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Diagnosis, DiagnosisFacade, AuthenticationService } from '@farm/core';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root',
})
export class DiagnosisResultFacade {
    private diagnosisSubject = new BehaviorSubject<Diagnosis | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(false);

    diagnosis$: Observable<Diagnosis | null> =
    this.diagnosisSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();

    id: string | undefined;
    isOwnProfile = false;

    constructor(
    private authenticationService: AuthenticationService,
    private diagnosisFacade: DiagnosisFacade,
    private router: Router
    ) {}

    load(id: string) {
        const data = this.authenticationService.decodedToken;

        this.id = id;
        this.isOwnProfile = data.nameid === id;

        this.loadingSubject.next(true);

        this.diagnosisFacade
            .getDiagnosisById(id)
            .pipe(
            tap(
                (diagnosis) => {
                this.diagnosisSubject.next(diagnosis);
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

    reset() {
        this.diagnosisSubject.next(null);
        this.id = undefined;
    }
}
