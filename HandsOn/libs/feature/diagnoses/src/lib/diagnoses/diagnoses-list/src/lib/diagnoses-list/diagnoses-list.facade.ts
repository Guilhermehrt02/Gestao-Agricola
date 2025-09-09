/* eslint-disable @angular-eslint/prefer-inject */
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ConfirmationService, DiagnosisFacade, AuthFacade } from '@farm/core';
import { Router } from '@angular/router';
import { Row, Action } from '@farm/ui';

@Injectable({
  providedIn: 'root',
})
export class DiagnosesListComponentFacade {
  private diagnosesSubject = new BehaviorSubject<Row[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  userId: string | undefined;
  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  diagnoses$: Observable<Row[]> = this.diagnosesSubject.asObservable();

  constructor(
    private diagnosisFacade: DiagnosisFacade,
    private authFacade: AuthFacade,
    private confirmationService: ConfirmationService,
    private router: Router,
  ) {}

  load() {
    const data = this.authFacade.decodedToken;

    this.userId = data.nameid;

    this.loadingSubject.next(true);

    this.diagnosisFacade
      .getAllDiagnoses(this.userId)
      .pipe(
        tap(
          (diagnoses) => {
            this.diagnosesSubject.next(
              diagnoses.map((diagnosis) => this.mapDiagnosisToRow(diagnosis)),
            );
            this.loadingSubject.next(false);
          },
          () => {
            this.loadingSubject.next(false);
          },
        ),
      )
      .subscribe();
  }

  private mapDiagnosisToRow(diagnosis: any): Row {
    return {
      ...diagnosis,
      actions: [
        {
          tooltip: 'Editar',
          icon: 'pi pi-fw pi-pencil',
          iconClass: 'primary',
          routerLink: `/app/diagnoses/diagnosis/${diagnosis.id}`,
        },
        {
          tooltip: 'Excluir',
          icon: 'pi pi-fw pi-trash',
          iconClass: 'danger',
          command: () => {
            this.confirmationService.confirm({
              header: 'Excluir Diagnóstico',
              message: 'Você tem certeza que deseja excluir este diagnóstico?',
              accept: () => {
                this.diagnosisFacade.deleteDiagnosis(diagnosis.id, this.userId).subscribe(() => {
                  this.load();
                });
              },
            });
          },
        },
      ] as Action[],
    };
  }

  navigateToCreateDiagnosis(): void {
    this.router.navigate(['/app/diagnoses/diagnosis/create']);
  }

  navigateToEditDiagnosis(id: string): void {
    this.router.navigate([`/app/diagnoses/diagnosis/${id}`]);
  }

  navigateToViewDiagnosis(id: string): void {
    this.router.navigate([`/app/diagnoses/diagnosis/${id}/result`]);
  }

  navigateToDeleteDiagnosis(id: string): void {
    this.confirmationService.confirm({
      header: 'Excluir Diagnóstico',
      message: 'Você tem certeza que deseja excluir este diagnóstico?',
      accept: () => {
        this.diagnosisFacade.deleteDiagnosis(id, this.userId).subscribe(() => {
          this.load();
        });
      },
    });
  }
}
