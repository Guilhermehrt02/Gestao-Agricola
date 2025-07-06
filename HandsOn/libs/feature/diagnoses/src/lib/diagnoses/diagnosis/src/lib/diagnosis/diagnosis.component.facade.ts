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
} from '@farm/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class DiagnosisComponentFacade {
  private diagnosisSubject = new BehaviorSubject<Diagnosis | null>(null);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  id: string | undefined;
  isOwnProfile = false;
  diagnosis$: Observable<Diagnosis | null> = this.diagnosisSubject.asObservable();
  loading$: Observable<boolean> = this.loadingSubject.asObservable();

  constructor(
    private authenticationService: AuthenticationService,
    private diagnosisFacade: DiagnosisFacade,
    private confirmationService: ConfirmationService,
    private uploadFacade: UploadFacade,
    private router: Router,
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

  submit(diagnosis: any) {
    const receiptFile = diagnosis.receiptFile;

    const finalizeSubmit = (updatedDiagnosis: any) => {
      if (this.id) {
        this.updateDiagnosis(updatedDiagnosis);
      } else {
        this.addDiagnosis(updatedDiagnosis);
      }
    };

    if (receiptFile) {
      this.uploadFacade.uploadFile(receiptFile).subscribe({
        next: (uploadResponse) => {
          const receiptUrl = uploadResponse.fileUrl;

          const updatedDiagnosis = {
            ...diagnosis,
            receiptUrl,
            receiptFile: null,
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
      this.router.navigate(['/app/diagnosis']);
    });
  }

  updateDiagnosis(diagnosis: Diagnosis) {
    this.loadingSubject.next(true);

    this.diagnosisFacade.updateDiagnosis(diagnosis).subscribe(() => {
      this.router.navigate(['/app/diagnosis']);
    });
  }

  deleteDiagnosis(id: string) {
    this.confirmationService.confirm({
      message: 'Você tem certeza que deseja excluir esse diagnóstico?',
      accept: () => {
        this.diagnosisFacade.deleteDiagnosis(id).subscribe(() => {
          this.router.navigate(['/app/diagnosis']);
        });
      },
    });
  }
}
