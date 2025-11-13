/* eslint-disable @angular-eslint/prefer-inject */
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Farm } from '../models/farm.model';
import { Harvest } from '../models/harvest.model';
import { Plot } from '../models/plot.model';
import { FarmService } from '../services/farm/farm.service';
import { PlotService } from '../services/farm/plot.service';
import { HarvestService } from '../services/farm/harvest.service';
import { NotificationService } from '../services/notification/notification.service';
@Injectable({
    providedIn: 'root',
})

export class FarmFacade {
    private farmsSubject = new BehaviorSubject<Farm[] | null>(null);
    private harvestsSubject = new BehaviorSubject<Harvest[] | null>(null);
    private plotsSubject = new BehaviorSubject<Plot[] | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(true);

    farms$: Observable<Farm[] | null> = this.farmsSubject.asObservable();
    harvests$: Observable<Harvest[] | null> = this.harvestsSubject.asObservable();
    plots$: Observable<Plot[] | null> = this.plotsSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();

    constructor(
        private farmService: FarmService,
        private plotService: PlotService,
        private harvestService: HarvestService,
        private notificationService: NotificationService
    ) {}

    getFarms(): Observable<Farm[]> {
        return this.farmService.getFarms().pipe(
            tap({
                next: (farms) => {
                    this.farmsSubject.next(farms);
                    this.loadingSubject.next(false);
                },
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível carregar as fazendas!'
                    );
                    this.loadingSubject.next(false);
                }
            })
        );
    }

    getPlotsByFarm(farmId: string): Observable<Plot[]> {
        return this.plotService.getPlotsByFarm(farmId).pipe(
            tap({
                next: (plots) => {
                    this.plotsSubject.next(plots);
                    this.loadingSubject.next(false);
                },
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível carregar os talhões!'
                    );
                    this.loadingSubject.next(false);
                }
            })
        );
    }

    getHarvestsByFarm(farmId: string): Observable<Harvest[]> {
        return this.harvestService.getHarvestsByFarm(farmId).pipe(
            tap({
                next: (harvests) => {
                    this.harvestsSubject.next(harvests);
                    this.loadingSubject.next(false);
                },
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível carregar as colheitas!'
                    );
                    this.loadingSubject.next(false);
                }
            })
        );
    }

    updateFarm(farm: Farm): Observable<Farm> {
        return this.farmService.updateFarm(farm).pipe(
            tap({
                next: () => {
                    this.notificationService.success(
                        'Sucesso!',
                        'Fazenda atualizada com sucesso!'
                    );
                },
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível atualizar a fazenda!'
                    );
                }
            })
        );
    }

    updatePlot(plot: Plot): Observable<Plot> {
        return this.plotService.updatePlot(plot).pipe(
            tap({
                next: () => {
                    this.notificationService.success(
                        'Sucesso!',
                        'Talhão atualizado com sucesso!'
                    );
                },
                error: () => {
                    this.notificationService.error(
                        'Erro!',
                        'Não foi possível atualizar o talhão!'
                    );
                }
            })
        );
    }
}