/* eslint-disable @typescript-eslint/no-inferrable-types */
/* eslint-disable @angular-eslint/prefer-inject */
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DateTypeFilterComponent,
  MapComponent,
  CardComponent,
  MapLayersComponent,
} from '@farm/ui';
import { FarmMapViewComponentFacade } from './farmMapView.facade';
import { Diagnosis, Farm, LocationShapeData, MapLocation, Plot } from '@farm/core';

const MapLayerColors = {
  farm: {
    fill: '#1b5e20',
    stroke: '#4caf50',
    label: '#a5d6a7'
  },
  plot: {
    fill: '#0d47a1',
    stroke: '#42a5f5',
    label: '#90caf9'
  },
  diagnosis: {
    fill: '#b71c1c',
    stroke: '#ef5350',
    label: '#ffcdd2'
  }
} as const;

@Component({
  selector: 'lib-farm-map-view',
  imports: [
    CommonModule,
    //DateTypeFilterComponent,
    MapComponent,
    CardComponent,
    MapLayersComponent,
  ],
  templateUrl: './farmMapView.html',
  styleUrls: ['./farmMapView.css'],
})
export class FarmMapView implements OnInit {
  loading = false;
  editable = false;

  diagnoses: Diagnosis[] = [];
  farms: Farm[] = [];
  plots: Plot[] = [];

  locationShapes: any[] = [];
  farmsShapes: MapLocation[] = [];
  plotsShapes: MapLocation[] = [];
  diagnosisShapes: MapLocation[] = [];

  focusedLocationShape: any;
  creatable: boolean = false;
  createTarget: { type: 'farm' | 'plot' | 'diagnosis'; data: any } = { type: 'farm', data: null };
  loadedFarms: boolean = false;
  loadedPlots: boolean = false;
  loadedDiagnoses: boolean = false;

  @ViewChild('mapContainer', { read: ElementRef }) mapContainerRef!: ElementRef;

  constructor(private facade: FarmMapViewComponentFacade) {}

   ngOnInit() {
    this.facade.loading$.subscribe(v => (this.loading = v));

    this.facade.farms$.subscribe((farms) => {
      this.farms = farms;
      if (this.farms.length > 0) {
        this.farms[0].locationShapes = [{
          type: 'polygon', 
          coordinates: [
            {
                "lat": -23.468485643871492,
                "lng": -46.51023696379445
            },
            {
                "lat": -23.464076650447456,
                "lng": -46.49744819121144
            },
            {
                "lat": -23.473051946065667,
                "lng": -46.49470160918019
            },
            {
                "lat": -23.47407540591321,
                "lng": -46.48088286833546
            },
            {
                "lat": -23.482971299354908,
                "lng": -46.48088286833546
            },
            {
                "lat": -23.478169165908206,
                "lng": -46.502598032520034
            }
        ]
        }];
      }
      this.farmsShapes = this.getFarmsShapes(farms);
      this.loadedFarms = true;
      this.tryBuildAll();
    });

    this.facade.plots$.subscribe((plots) => {
      this.plots = plots;
      if (this.plots.length > 0) {
        this.plots[0].locationShapes = [{
          type: 'polygon', 
          coordinates: [
            {
                "lat": -23.468552792303452,
                "lng": -46.509571775958754
            },
            {
                "lat": -23.464616200079586,
                "lng": -46.49789880232594
            },
            {
                "lat": -23.473119092173985,
                "lng": -46.49523805098317
            },
            {
                "lat": -23.472725451857464,
                "lng": -46.50545190291188
            }
        ]
        }];
      }
      this.plotsShapes = this.getPlotsShapes(plots);
      this.loadedPlots = true;
      this.tryBuildAll();
    });

    this.facade.diagnoses$.subscribe((diagnoses) => {
      this.diagnoses = diagnoses;
      this.diagnosisShapes = this.getDiagnosisShapes(diagnoses);
      this.loadedDiagnoses = true;
      this.tryBuildAll();
    });

    this.facade.load();
  }

  tryBuildAll() {
    if (!this.loadedFarms || !this.loadedPlots || !this.loadedDiagnoses) return;

    this.locationShapes = [
      ...this.farmsShapes,
      ...this.plotsShapes,
      ...this.diagnosisShapes
    ];
  }

  getFarmsShapes(farms: Farm[]): MapLocation[] {
    const shapes: MapLocation[] = [];

    farms.forEach(farm => {
      if (farm.locationShapes && farm.locationShapes.length > 0) {
        farm.locationShapes.forEach(shape => {
          shapes.push({
            ...shape,
            class: 'farm',
            color: MapLayerColors.farm.fill,
            type: shape.type,
            visible: true,
            hasShapes: true,
            info: {
              id: farm.id,
              name: farm.name,
              totalArea: farm.totalArea,
              affectedArea: farm.affectedArea
            }
          });
        });
      } else {
        shapes.push({
          class: 'farm',
          hasShapes: false,
          visible: true,
          info: { id: farm.id, name: farm.name }
        });
      }
    });

    return shapes;
  }

  getPlotsShapes(plots: Plot[]): MapLocation[] {
    const shapes: MapLocation[] = [];

    plots.forEach(plot => {
      if (plot.locationShapes && plot.locationShapes.length > 0) {
        plot.locationShapes.forEach(shape => {
          shapes.push({
            ...shape,
            class: 'plot',
            type: shape.type,
            visible: true,
            color: MapLayerColors.plot.fill,
            hasShapes: true,
            info: {
              id: plot.id,
              name: plot.name,
              farmId: plot.farmId,
              totalArea: plot.totalArea,
              affectedArea: plot.affectedArea
            }
          });
        });
      } else {
        shapes.push({
          class: 'plot',
          hasShapes: false,
          visible: true,
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

  getDiagnosisShapes(diagnoses: Diagnosis[]): MapLocation[] {
    return diagnoses.flatMap(d => {
      if (!d.locationShapes || d.locationShapes.length === 0) return [{
        class: 'diagnosis',
        hasShapes: false,
        visible: true,
        info: { id: d.id, farmId: d.farm?.id, plotId: d.plot?.id }
      }];

      return d.locationShapes.map((shape: any) => ({
        ...shape,
        class: 'diagnosis',
        color: MapLayerColors.diagnosis.fill,
        type: shape.type,
        hasShapes: true,
        visible: true,
        info: {
          id: d.id,
          diseaseName: d.result?.imageSimilarities?.[0]?.disease?.name,
          farmName: d.farm?.name,
          farmId: d.farm?.id,
          plotName: d.plot?.name,
          plotId: d.plot?.id,
          harvestName: d.harvest?.name,
          harvestId: d.harvest?.id,
          date: d.date,
          status: d.status
        }
      }));
    });
  }

  onToggleLayer(layer: any) {
    if (!layer.data) return;

    const targetId = layer.data.id;
    const targetClass = layer.data.class;
    const newVisibility = layer.visible;

    this.updateVisibilityInLocationShapes(targetId, newVisibility);

    if (targetClass === 'farm') {
      layer.children?.forEach((plot: any) => {
        this.updateVisibilityInLocationShapes(plot.data.id, newVisibility);

        plot.children?.forEach((diagnosis: any) => {
          this.updateVisibilityInLocationShapes(diagnosis.data.id, newVisibility);
        });
      });
    }

    if (targetClass === 'plot') {
      layer.children?.forEach((diagnosis: any) => {
        this.updateVisibilityInLocationShapes(diagnosis.data.id, newVisibility);
      });
    }

  }

  private updateVisibilityInLocationShapes(id: string, visible: boolean) {
    const index = this.locationShapes.findIndex(s => s.id === id);
    if (index !== -1) {
      this.locationShapes[index].visible = visible;
    }
    this.locationShapes = [...this.locationShapes];
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

  onCreateShape(type: 'farm' | 'plot' | 'diagnosis', data: any) {
    this.creatable = !this.creatable;
    this.createTarget = { type, data };

    if (this.creatable && this.mapContainerRef?.nativeElement) {
      this.mapContainerRef.nativeElement.scrollIntoView({
        behavior: 'smooth',
        block: 'center',
      });
    }
  }

  onEditShape(type: 'farm' | 'plot' | 'diagnosis', data: any) {
    this.creatable = !this.creatable;
    this.createTarget = { type, data };
    if (this.creatable && this.mapContainerRef?.nativeElement) {
      this.mapContainerRef.nativeElement.scrollIntoView({
        behavior: 'smooth',
        block: 'center',
      });
    }
  }

  onSetFocusByDrawing(shape: any) {
    this.focusedLocationShape = shape;
  }

  onShapeCreated(shape: LocationShapeData) {
    const farm = this.farms.find(f => f.id === shape.info?.farmId);
    const plot = this.plots.find(p => p.id === shape.info?.plotId);

    if (farm) {
      this.facade.updateFarm(farm);
    }
    if (plot) {
      this.facade.updatePlot(plot);
    }
  }  

  onToggleOnlyFarmShape(event: { id: string; hide: boolean }) {
    this.updateVisibilityInLocationShapes(event.id, !event.hide);
  }

  onToggleOnlyPlotShape(event: { id: string; hide: boolean }) {
    this.updateVisibilityInLocationShapes(event.id, !event.hide);
  }
}