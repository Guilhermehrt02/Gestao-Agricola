/* eslint-disable @angular-eslint/prefer-inject */
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DateTypeFilterComponent, 
  GetLocationComponent,
  CardComponent 
} from '@farm/ui';
import { FarmMapViewComponentFacade } from './farmMapView.facade';
import { Diagnosis, MapLocation } from '@farm/core';

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
export class FarmMapView implements OnInit {
  loading = false;
  data: Diagnosis[] = [];
  locationShapes: any[] = [];

  constructor(private facade: FarmMapViewComponentFacade) {}

  ngOnInit() {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.diagnoses$.subscribe((diagnoses) => (this.data = diagnoses));

    this.facade.load();
  }

  onLocationShapesFiltered(filteredLocationShapes: MapLocation[]) {
    this.locationShapes = filteredLocationShapes;
  }
}
