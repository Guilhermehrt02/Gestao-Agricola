/* eslint-disable @angular-eslint/use-lifecycle-interface */
/* eslint-disable @typescript-eslint/no-inferrable-types */
/* eslint-disable @angular-eslint/prefer-inject */
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  //DateTypeFilterComponent,
  MapComponent,
  CardComponent,
  MapLayersComponent,
} from '@farm/ui';
import { FarmMapViewComponentFacade } from './farmMapView.facade';
import { Diagnosis, 
  Farm, 
  LocationShapeData, 
  MapLocation, 
  Plot, 
  MapStateService,
  MapElement,
  GoogleMapsService
} from '@farm/core';
import { combineLatest } from 'rxjs';

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
  farmsShapes: MapElement[] = [];
  plotsShapes: MapElement[] = [];
  diagnosisShapes: MapElement[] = [];

  focusedLocationShape: any;
  creatable: boolean = false;
  createTarget: { type: 'farm' | 'plot' | 'diagnosis'; data: any } = { type: 'farm', data: null };
  loadedFarms: boolean = false;
  loadedPlots: boolean = false;
  loadedDiagnoses: boolean = false;

  @ViewChild('mapContainer', { read: ElementRef }) mapContainerRef!: ElementRef;
  @ViewChild(MapComponent) map!: MapComponent;

  constructor(private facade: FarmMapViewComponentFacade, private mapState: MapStateService) {}

  ngAfterViewInit() {
    combineLatest([
      this.map.mapReady$,
      this.mapState.mapElements$,
      this.mapState.focusElementId$
    ]).subscribe(([ready, elements, focusId]) => {
      if (!ready || !elements) return;

      this.map.syncElements(elements);

      if (focusId) {
        const element = elements.find(e => e.id === focusId);
        if (element) {
          this.map.setFocus(element);

          if (this.mapContainerRef?.nativeElement) {
            setTimeout(() => {
              this.mapContainerRef.nativeElement.scrollIntoView({
                behavior: 'smooth',
                block: 'center',
              });
            }, 100); 
          }
        }
      }
    });
  }

  ngOnInit() {
    this.facade.loading$.subscribe(v => this.loading = v);

    combineLatest([
      this.facade.farms$,
      this.facade.plots$,
      this.facade.diagnoses$
    ]).subscribe(([farms, plots, diagnoses]) => {

      const farmsShapes = this.getFarmsShapes(farms);
      const plotsShapes = this.getPlotsShapes(plots);
      const diagnosisShapes = this.getDiagnosisShapes(diagnoses);

      const mapElements = [
        ...farmsShapes,
        ...plotsShapes,
        ...diagnosisShapes
      ];

      this.mapState.setMapElements(mapElements);
    });

    this.facade.load();
  }


  getFarmsShapes(farms: Farm[]): MapElement[] {
    const shapes: MapElement[] = [];

    farms.forEach(farm => {
      // Verifica se a fazenda tem shapes
      if (farm.locationShapes && farm.locationShapes.length > 0) {
        farm.locationShapes.forEach(shape => {
          shapes.push({
            id: this.generateId(),
            class: 'farm',
            hasShapes: true,
            visible: true,
            label: shape.label,
            color: MapLayerColors.farm.fill,
            type: shape.type,
            children: [],
            mapObject: null,
            info: {
              id: farm.id,
              name: farm.name,
              totalArea: farm.totalArea,
              affectedArea: farm.affectedArea,
              date: farm.createdAt
            }
          });
        });
      } else {
        shapes.push({
          id: this.generateId(),
            class: 'farm',
            hasShapes: false,
            visible: true,
            info: {
              id: farm.id,
              name: farm.name,
              totalArea: farm.totalArea,
              affectedArea: farm.affectedArea,
              date: farm.createdAt
            }
        });
      }
    });

    return shapes;
  }

  getPlotsShapes(plots: Plot[]): MapElement[] {
    const shapes: MapElement[] = [];

    plots.forEach(plot => {
      // Verifica se a fazenda tem shapes
      if (plot.locationShapes && plot.locationShapes.length > 0) {
        plot.locationShapes.forEach(shape => {
          shapes.push({
            id: this.generateId(),
            class: 'plot',
            hasShapes: true,
            visible: true,
            label: shape.label,
            color: MapLayerColors.plot.fill,
            type: shape.type,
            children: [],
            mapObject: null,
            info: {
              id: plot.id,
              name: plot.name,
              farmName: this.farms.find(f => f.id === plot.farmId)?.name || '',
              farmId: plot.farmId,
              totalArea: plot.totalArea,
              affectedArea: plot.affectedArea,
              date: plot.createdAt
            }
          });
        });
      } else {
        shapes.push({
          id: this.generateId(),
            class: 'plot',
            hasShapes: false,
            visible: true,
            info: {
              id: plot.id,
              name: plot.name,
              farmName: this.farms.find(f => f.id === plot.farmId)?.name || '',
              farmId: plot.farmId,
              totalArea: plot.totalArea,
              affectedArea: plot.affectedArea,
              date: plot.createdAt
            }
        });
      }
    });

    return shapes;
  }

  getDiagnosisShapes(diagnoses: Diagnosis[]): MapElement[] {
    return diagnoses.flatMap(d => {
      if (!d.locationShapes || d.locationShapes.length === 0) return [{
        id: this.generateId(),
        class: 'diagnosis',
        hasShapes: false,
        visible: true,
        info: {
          id: d.id,
          name: d.result?.imageSimilarities?.[0]?.disease?.name || 'Diagnóstico',
          farmName: d.farm?.name,
          farmId: d.farm?.id,
          plotName: d.plot?.name,
          plotId: d.plot?.id,
          harvestName: d.harvest?.name,
          harvestId: d.harvest?.id,
          status: d.status,
          coordinates: [],
          date: d.createdAt
        } 
      }];

      return d.locationShapes.map((shape: any) => ({
        id: this.generateId(),
        class: 'diagnosis',
        hasShapes: true,
        visible: true,
        label: shape.label,
        color: MapLayerColors.diagnosis.fill,
        type: shape.type,
        children: [],
        mapObject: null,
        info: {
          id: d.id,
          name: shape.label || d.result?.imageSimilarities?.[0]?.disease?.name || 'Diagnóstico',
          farmName: d.farm?.name,
          farmId: d.farm?.id,
          plotId: d.plot?.id,
          plotName: d.plot?.name,
          harvestId: d.harvest?.id,
          harvestName: d.harvest?.name,
          status: d.status,
          coordinates: shape.coordinates,
          date: d.createdAt
        } 
      }));
    });
  }

  private updateVisibilityInLocationShapes(id: string, visible: boolean) {
    const index = this.locationShapes.findIndex(s => s.id === id);
    if (index !== -1) {
      this.locationShapes[index].visible = visible;
    }
    this.locationShapes = [...this.locationShapes];
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

  generateId(): string {
    return Math.random().toString(36).substring(2, 10) + Date.now().toString(36);
  }
}