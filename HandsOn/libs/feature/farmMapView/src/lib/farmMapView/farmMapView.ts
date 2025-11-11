/* eslint-disable @angular-eslint/prefer-inject */
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DateTypeFilterComponent,
  GetLocationComponent,
  CardComponent,
  MapLayersComponent,
} from '@farm/ui';
import { FarmMapViewComponentFacade } from './farmMapView.facade';
import { Diagnosis, Farm, MapLocation, Plot } from '@farm/core';

@Component({
  selector: 'lib-farm-map-view',
  imports: [
    CommonModule,
    DateTypeFilterComponent,
    GetLocationComponent,
    CardComponent,
    MapLayersComponent,
  ],
  templateUrl: './farmMapView.html',
  styleUrls: ['./farmMapView.css'],
})
export class FarmMapView implements OnInit {
  loading = false;
  data: Diagnosis[] = [];
  locationShapes: any[] = [];
  editable = false;
  farms: Farm[] = [];
  plots: Plot[] = [];
  farmsShapes: any[] = [];
  plotsShapes: any[] = [];
  focusedLocationShape: any;

  @ViewChild('mapContainer', { read: ElementRef }) mapContainerRef!: ElementRef;


  constructor(private facade: FarmMapViewComponentFacade) {}

  ngOnInit() {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.diagnoses$.subscribe((diagnoses) => (this.data = diagnoses));
    // this.facade.farms$.subscribe((farms) => (this.farms = farms));
    // this.facade.plots$.subscribe((plots) => (this.plots = plots));
    const farms = [
      {
        id: '08dde8cc-119c-4fcc-850c-a4f0b17b3cd7',
        userId: 'u1',
        name: 'Farm 1',
        totalArea: 100,
        affectedArea: 50,
        createdAt: new Date(),
        updatedAt: new Date(),
        locationShapes: [{ 
          type: 'Polygon', 
          coordinates: [[[0,0],[0,1],[1,1],[1,0],[0,0]]]
        }],
      },
    ];
    const plots = [
      {
        id: "08dde8cc-933a-4b6d-8a12-24b31897bcbb",
        farmId: '08dde8cc-119c-4fcc-850c-a4f0b17b3cd7',
        name: 'Plot 1',
        totalArea: 60,
        affectedArea: 30,
        createdAt: new Date(),
        updatedAt: new Date()
      },
    ];

    this.farmsShapes = this.getFarmsShapes(farms);

    this.plotsShapes = this.getPlotsShapes(plots);

    this.facade.load();
  }

  onLocationShapesFiltered(filteredLocationShapes: any) {
    let locationShapes = filteredLocationShapes.diagnoses;

    const farms = this.farmsShapes.filter(farmShape => 
      filteredLocationShapes.farms.includes(farmShape.info?.id)
    );

    const plots = this.plotsShapes.filter(plotShape => 
      filteredLocationShapes.plots.includes(plotShape.info?.id)
    );

    if (farms.length) {
      locationShapes = locationShapes.concat(farms);
    }

    if (plots.length) {
      locationShapes = locationShapes.concat(plots);
    }

    this.locationShapes = locationShapes;
  }

  onToggleLayer(layer: any) {
    console.log('Visibilidade alterada:', layer);
    
  }

  onFocusLayer(layer: any) {
    this.focusedLocationShape = layer.data;

     if (this.mapContainerRef?.nativeElement) {
      this.mapContainerRef.nativeElement.scrollIntoView({
        behavior: 'smooth',
        block: 'center',
      });
    }
  }

  getFarmsShapes(farms: Farm[]): MapLocation[] {
    const shapes: MapLocation[] = [];

    farms.forEach((farm) => {
      if (farm.locationShapes) {
        farm.locationShapes.forEach((shape) => {
          shapes.push({
            ...shape,
            class: 'farm',
            hasShapes: true,
            info: {
              id: farm.id,
              name: farm.name,
              totalArea: farm.totalArea,
              affectedArea: farm.affectedArea,
            }
          });
        });
      } else {
        shapes.push({ 
          class: 'farm', 
          hasShapes: false,
          info: { id: farm.id, name: farm.name }
        });
      }
    });
    return shapes;
  }

  getPlotsShapes(plots: Plot[]): MapLocation[] {
    const shapes: MapLocation[] = [];

    plots.forEach((plot) => {
      if (plot.locationShapes) {
        plot.locationShapes.forEach((shape) => {
          shapes.push({
            ...shape,
            class: 'plot',
            hasShapes: true,
            info: {
              id: plot.id,
              name: plot.name,
              farmId: plot.farmId,
              totalArea: plot.totalArea,
              affectedArea: plot.affectedArea,
            },
          });
        });
      } else {
        shapes.push({ 
          class: 'plot', hasShapes: false,
          info: { 
            id: plot.id, 
            name: plot.name, 
            farmId: plot.farmId
          }
        });
      }
    });
    return shapes;
  }
}
