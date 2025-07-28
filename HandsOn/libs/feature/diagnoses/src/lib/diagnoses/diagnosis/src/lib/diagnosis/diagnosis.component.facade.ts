/* eslint-disable @angular-eslint/prefer-inject */
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  Diagnosis,
  DiagnosisFacade,
  ConfirmationService,
  AuthenticationService,
  UploadFacade,
  Farm,
  Harvest,
  Plot,
  FarmFacade,
} from '@farm/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class DiagnosisComponentFacade {
  private diagnosisSubject = new BehaviorSubject<Diagnosis | null>(null);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  private farmsSubject = new BehaviorSubject<Farm[] | null>(null);
  private harvestsSubject = new BehaviorSubject<Harvest[] | null>(null);
  private plotsSubject = new BehaviorSubject<Plot[] | null>(null);

  diagnosis$: Observable<Diagnosis | null> = this.diagnosisSubject.asObservable();
  farms$: Observable<Farm[] | null> = this.farmsSubject.asObservable();
  harvests$: Observable<Harvest[] | null> = this.harvestsSubject.asObservable();
  plots$: Observable<Plot[] | null> = this.plotsSubject.asObservable();
  loading$: Observable<boolean> = this.loadingSubject.asObservable();

  id: string | undefined;
  isOwnProfile = false;

  constructor(
    private authenticationService: AuthenticationService,
    private diagnosisFacade: DiagnosisFacade,
    private confirmationService: ConfirmationService,
    private uploadFacade: UploadFacade,
    private router: Router,
    private farmFacade: FarmFacade
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

  loadFarmOptions() {
    this.farmFacade.getFarms().subscribe(farms => {
      this.farmsSubject.next(farms);
    });
  }

  loadHarvests(farmId: string) {
    this.farmFacade.getHarvestsByFarm(farmId).subscribe(harvests => {
      this.harvestsSubject.next(harvests);
    });
  }

  loadPlots(farmId: string) {
    this.farmFacade.getPlotsByFarm(farmId).subscribe(plots => {
      this.plotsSubject.next(plots);
    });
  }

  reset() {
    this.diagnosisSubject.next(null);
    this.id = undefined;
  }

  submit(diagnosis: any) {
    const photoFile = diagnosis.photoFile;

    const finalizeSubmit = (updatedDiagnosis: any) => {
      if (this.id) {
        this.updateDiagnosis(updatedDiagnosis);
      } else {
        this.addDiagnosis(updatedDiagnosis);
      }
    };

    if (photoFile) {
      this.uploadFacade.uploadFile(photoFile).subscribe({
        next: (uploadResponse) => {
          const photoUrl = uploadResponse.fileUrl;

          const updatedDiagnosis = {
            ...diagnosis,
            photoUrl,
            photoFile: null,
          };

          finalizeSubmit(updatedDiagnosis);
        },
        error: () => {
          this.loadingSubject.next(false);
        },
      });
    } else {
      finalizeSubmit(diagnosis);
    }
  }

  addDiagnosis(diagnosis: Diagnosis) {
    this.loadingSubject.next(true);

    this.diagnosisFacade.createDiagnosis(diagnosis).subscribe(() => {
      this.router.navigate(['/app/diagnoses']);
    });
  }

  updateDiagnosis(diagnosis: Diagnosis) {
    this.loadingSubject.next(true);

    this.diagnosisFacade.updateDiagnosis(diagnosis).subscribe(() => {
      this.router.navigate(['/app/diagnoses']);
    });
  }

  deleteDiagnosis(id: string) {
    this.confirmationService.confirm({
      message: 'Você tem certeza que deseja excluir esse diagnóstico?',
      accept: () => {
        this.diagnosisFacade.deleteDiagnosis(id).subscribe(() => {
          this.router.navigate(['/app/diagnoses']);
        });
      },
    });
  }
}
