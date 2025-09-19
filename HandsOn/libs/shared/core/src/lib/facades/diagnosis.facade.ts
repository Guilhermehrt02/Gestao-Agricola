/* eslint-disable @angular-eslint/prefer-inject */
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Diagnosis} from '../models/diagnosis.model';
import { NotificationService } from '../services/notification/notification.service';
import { DiagnosisService } from '../services/diagnosis/diagnosis.service';

@Injectable({
    providedIn: 'root',
})

export class DiagnosisFacade {
    private diagnosisSubject = new BehaviorSubject<Diagnosis[] | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(true);

    diagnosis$: Observable<Diagnosis[] | null> = this.diagnosisSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();

    constructor(
        private diagnosisService: DiagnosisService,
        private notificationService: NotificationService,
    ) {}

    getAllDiagnoses(userId: string): Observable<Diagnosis[]> {
        return this.diagnosisService.getAllDiagnoses(userId).pipe(
            tap({
                next: (diagnoses) => {
                    this.diagnosisSubject.next(diagnoses);
                    this.loadingSubject.next(false);
                },
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível carregar os diagnósticos!'
                    );
                    this.loadingSubject.next(false);
                }
            })
        )
    }

    getDiagnosisById(id: string): Observable<Diagnosis> {
        return this.diagnosisService.getDiagnosisById(id).pipe(
            tap({
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível carregar o diagnóstico!'
                    );
                }
            })
        );
    }

    createDiagnosis(diagnosis: Diagnosis): Observable<Diagnosis> {
        return this.diagnosisService.createDiagnosis(diagnosis).pipe(
            tap({
                next: () => {
                    this.notificationService.success(
                        'Sucesso!',
                        'Diagnóstico criado com sucesso!'
                    );
                },
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível criar o diagnóstico!'
                    );
                }
            })
        );
    }

    updateDiagnosis(diagnosis: Diagnosis): Observable<Diagnosis> {
        return this.diagnosisService.updateDiagnosis(diagnosis).pipe(
            tap({
                next: () => {
                    this.notificationService.success(
                        'Sucesso!',
                        'Diagnóstico atualizado com sucesso!'
                    );
                },
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível atualizar o diagnóstico!'
                    );
                }
            })
        );
    }

    deleteDiagnosis(id: string, userId?: string): Observable<void> {
        return this.diagnosisService.deleteDiagnosis(id).pipe(
            tap({
                next: () => {
                    this.notificationService.success(
                        'Sucesso!',
                        'Diagnóstico excluído com sucesso!'
                    );
                    this.getAllDiagnoses(userId ?? '');
                },
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível excluir o diagnóstico!'
                    );
                }
            })
        );
    }
}