/* eslint-disable @angular-eslint/prefer-inject */
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DateTypeFilterComponent, 
  GetLocationComponent,
  CardComponent 
} from '@farm/ui';
import { FarmMapViewComponentFacade } from './farmMapView.facade';

@Component({
  selector: 'lib-farm-map-view',
  imports: [
    CommonModule,
    DateTypeFilterComponent,
    GetLocationComponent,
    CardComponent,
  ],
  templateUrl: './farmMapView.html',
  styleUrls: ['./farmMapView.css'],
})
export class FarmMapView {
  constructor(private facade: FarmMapViewComponentFacade) {}
  onSubmit(filters: { startDate: string; endDate: string; farmId?: string; plotId?: string; cultureId?: string; diseaseId?: string; harvestId?: string; }) {
    this.facade.submit({
      startDate: new Date(filters.startDate),
      endDate: new Date(filters.endDate),
      farmId: filters.farmId,
      plotId: filters.plotId,
      cultureId: filters.cultureId,
      diseaseId: filters.diseaseId,
      harvestId: filters.harvestId,
    });
  }  
}
