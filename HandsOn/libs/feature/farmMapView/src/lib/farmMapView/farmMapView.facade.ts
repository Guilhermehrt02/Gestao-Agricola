/* eslint-disable @angular-eslint/prefer-inject */
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, forkJoin } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import {
  Diagnosis,
  DiagnosisFacade,
  AuthFacade,
  Farm,
  FarmFacade,
  Plot,
} from '@farm/core';

@Injectable({ providedIn: 'root' })
export class FarmMapViewComponentFacade {
  private loadingSubject = new BehaviorSubject<boolean>(false);
  private diagnosisSubject = new BehaviorSubject<Diagnosis[]>([]);
  private farmsSubject = new BehaviorSubject<Farm[]>([]);
  private plotsSubject = new BehaviorSubject<Plot[]>([]);

  userId: string | undefined;

  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  diagnoses$: Observable<Diagnosis[]> = this.diagnosisSubject.asObservable();
  farms$: Observable<Farm[]> = this.farmsSubject.asObservable();
  plots$: Observable<Plot[]> = this.plotsSubject.asObservable();

  constructor(
    private diagnosisFacade: DiagnosisFacade,
    private authFacade: AuthFacade,
    private farmFacade: FarmFacade,
  ) {}

  load() {
    const data = this.authFacade.decodedToken;
    this.userId = data.nameid;

    this.loadingSubject.next(true);

    const farms$ = this.farmFacade.getFarms();
    const diagnoses$ = this.diagnosisFacade.getAllDiagnoses(this.userId);

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


  updateFarm(farm: Farm) {
    this.loadingSubject.next(true);

    this.farmFacade.updateFarm(farm).subscribe(() => {
      this.loadingSubject.next(false);
    });
  }

  updatePlot(plot: any) {
    this.loadingSubject.next(true);

    this.farmFacade.updatePlot(plot).subscribe(() => {
      this.loadingSubject.next(false);
    });
  }
}
