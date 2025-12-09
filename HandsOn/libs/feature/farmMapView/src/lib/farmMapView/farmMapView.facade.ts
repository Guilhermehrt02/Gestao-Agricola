/* eslint-disable @angular-eslint/prefer-inject */
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, forkJoin, of } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import {
  Diagnosis,
  DiagnosisFacade,
  AuthFacade,
  Farm,
  FarmFacade,
  Plot,
  TemporaryLocalService
} from '@farm/core';

@Injectable({ providedIn: 'root' })
export class FarmMapViewComponentFacade {
  private loadingSubject = new BehaviorSubject<boolean>(false);
  private diagnosisSubject = new BehaviorSubject<Diagnosis[]>([]);
  private farmsSubject = new BehaviorSubject<Farm[]>([]);
  private plotsSubject = new BehaviorSubject<Plot[]>([]);
  private temporarySubject = new BehaviorSubject<any[]>([]);

  userId: string | undefined;

  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  diagnoses$: Observable<Diagnosis[]> = this.diagnosisSubject.asObservable();
  farms$: Observable<Farm[]> = this.farmsSubject.asObservable();
  plots$: Observable<Plot[]> = this.plotsSubject.asObservable();
  temporaries$: Observable<any[]> = this.temporarySubject.asObservable();

  constructor(
    private diagnosisFacade: DiagnosisFacade,
    private authFacade: AuthFacade,
    private farmFacade: FarmFacade,
    private temporaryLocalService: TemporaryLocalService
  ) {}

  load() {
    const data = this.authFacade.decodedToken;
    this.userId = data.nameid;

    this.loadingSubject.next(true);

    const farms$ = this.farmFacade.getFarms();
    const diagnoses$ = this.diagnosisFacade.getAllDiagnoses(this.userId);
    const temporaries = this.temporaryLocalService.load();
    this.temporarySubject.next(temporaries);

    const plots$ = farms$.pipe(
      switchMap((farms) => {
        this.farmsSubject.next(farms);

        const plotRequests = farms.map(farm =>
          this.farmFacade.getPlotsByFarm(farm.id)
        );

        return forkJoin(plotRequests).pipe(
          map((plotsArray) => plotsArray.flat())
        );
      })
    );

    forkJoin([farms$, plots$, diagnoses$])
      .pipe(
        tap({
          next: ([farms, plots, diagnoses]) => {
            this.farmsSubject.next(farms);
            this.plotsSubject.next(plots);
            this.diagnosisSubject.next(diagnoses);
          },
          error: () => this.loadingSubject.next(false)
        })
      )
      .subscribe(() => {
        this.loadingSubject.next(false);
      });
  }


  updateFarm(farm: Farm): Observable<Farm> {
    this.loadingSubject.next(true);

    return this.farmFacade.updateFarm(farm).pipe(
      tap({
        next: () => this.loadingSubject.next(false),
        error: () => this.loadingSubject.next(false)
      })
    );
  }

  updatePlot(plot: any): Observable<Plot> {
    this.loadingSubject.next(true);

    return this.farmFacade.updatePlot(plot).pipe(
      tap({
        next: () => this.loadingSubject.next(false),
        error: () => this.loadingSubject.next(false)
      })
    );
  }

  updateDiagnosis(diagnosis: Diagnosis): Observable<Diagnosis> {
    this.loadingSubject.next(true);
    
    return this.diagnosisFacade.updateDiagnosis(diagnosis).pipe(
      tap({
        next: () => this.loadingSubject.next(false),
        error: () => this.loadingSubject.next(false)
      })
    );
  }

  saveTemporaryShapes(temporaries: any): Observable<any> {
    const currentTemporaries = this.temporaryLocalService.load();

    const updated = [
      ...currentTemporaries.filter(t => t.id !== temporaries.id),
      temporaries
    ];

    this.temporaryLocalService.save(updated);
    this.temporarySubject.next(updated);

    return of(updated);
  }

  deleteTemporaryShapes(tempId: string): Observable<any> {
    const currentTemporaries = this.temporaryLocalService.load();
    const updated = currentTemporaries.filter(t => t.id !== tempId);

    this.temporaryLocalService.save(updated);
    this.temporarySubject.next(updated);
    return of(updated);
  }

}
