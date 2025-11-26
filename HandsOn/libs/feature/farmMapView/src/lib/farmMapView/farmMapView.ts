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
  EditElementDialogComponent
} from '@farm/ui';
import { FarmMapViewComponentFacade } from './farmMapView.facade';
import { Diagnosis, 
  Farm, 
  Plot, 
  MapStateService,
  MapElement,
  GoogleMapsService
  
} from '@farm/core';
import { combineLatest, Observable } from 'rxjs';
import * as turf from '@turf/turf';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { SidebarModule } from 'primeng/sidebar';

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
    SidebarModule
  ],
  templateUrl: './farmMapView.html',
  styleUrls: ['./farmMapView.css'],
  providers: [DialogService]
})
export class FarmMapView implements OnInit {
  loading: boolean = false;
  diagnoses: Diagnosis[] = [];
  farms: Farm[] = [];
  plots: Plot[] = [];
  
  farmsShapes: MapElement[] = [];
  plotsShapes: MapElement[] = [];
  diagnosisShapes: MapElement[] = [];
  shapes: MapElement[] = [];

  loadedFarms: boolean = false;
  loadedPlots: boolean = false;
  loadedDiagnoses: boolean = false;
  sidebarOpen = window.innerWidth > 768; // desktop aberto, mobile fechado
  // sidebarOpen = true;

  @ViewChild('mapContainer', { read: ElementRef }) mapContainerRef!: ElementRef;
  @ViewChild(MapComponent) map!: MapComponent;
  editingElementId$!: Observable<string | null>;
  creatingShape$!: Observable<{ id: string; classType?: 'farm' | 'plot' | 'diagnosis' } | null>;
  private dialogRef?: DynamicDialogRef;


  constructor(private facade: FarmMapViewComponentFacade, 
    private mapState: MapStateService,
    private dialogService: DialogService) {}
  
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
    this.editingElementId$ = this.mapState.editingElementId$;
    this.creatingShape$ = this.mapState.creatingShape$;

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
        farm.locationShapes.forEach((shape: any) => {
          shapes.push({
            id: farm.id,
            class: 'farm',
            hasShapes: true,
            visible: true,
            editable: false,
            hideShapeOnly: false,
            label: farm.locationShapes?.[0]?.label || farm.name,
            color: MapLayerColors.farm.fill,
            type: shape.type,
            children: [],
            mapObject: null,
            info: {
              id: farm.id,
              name: farm.name,
              coordinates: shape.coordinates, 
              totalArea: shape.coordinates.length ? this.calculateArea(shape.coordinates) : 0,
              perimeter: shape.coordinates.length ? this.calculatePerimeter(shape.coordinates) : 0,
              affectedArea: farm.affectedArea,
              date: farm.createdAt
            }
          });
        });
      } else {
        shapes.push({
          id: farm.id,
            class: 'farm',
            hasShapes: false,
            visible: true,
            label: farm.name,
            info: {
              id: farm.id,
              name: farm.name,
              totalArea: farm.totalArea,
              perimeter: farm.perimeter,
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
        plot.locationShapes.forEach((shape: any) => {
          shapes.push({
            id: plot.id,
            class: 'plot',
            hasShapes: true,
            visible: true,
            hideShapeOnly: false,
            editable: false,
            label: plot.locationShapes?.[0]?.label || plot.name,
            color: MapLayerColors.plot.fill,
            type: shape.type,
            children: [],
            mapObject: null,
            info: {
              id: plot.id,
              name: plot.name,
              farmName: this.farms.find(f => f.id === plot.farmId)?.name || '',
              farmId: plot.farmId,
              coordinates: shape.coordinates,
              totalArea: shape.coordinates.length ? this.calculateArea(shape.coordinates) : 0,
              perimeter: shape.coordinates.length ? this.calculatePerimeter(shape.coordinates) : 0,
              affectedArea: plot.affectedArea,
              date: plot.createdAt
            }
          });
        });
      } else {
        shapes.push({
          id: plot.id,
            class: 'plot',
            hasShapes: false,
            visible: true,
            label: plot.name,
            info: {
              id: plot.id,
              name: plot.name,
              farmName: this.farms.find(f => f.id === plot.farmId)?.name || '',
              farmId: plot.farmId,
              totalArea: plot.totalArea,
              affectedArea: plot.affectedArea,
              perimeter: plot.perimeter,
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
        id:  this.generateId(),
        class: 'diagnosis',
        hasShapes: false,
        visible: true,
        editable: false,
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
        editable: false,
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
          date: d.createdAt,
          photoUrl: d.photoUrl
        } 
      }));
    });
  }

  onEditShape(id: string) {
    this.mapState.startEditing(id);

    this.mapContainerRef?.nativeElement.scrollIntoView({
      behavior: 'smooth',
      block: 'center',
    });
  }

  onDeleteShape(id: string) {
    this.mapState.deleteShape(id);

    this.mapContainerRef?.nativeElement.scrollIntoView({
      behavior: 'smooth',
      block: 'center',
    });
  }

  onCreateShape(id: string, classType?: 'farm' | 'plot' | 'diagnosis') {
    this.mapState.startCreatingShape(id, classType);

    this.mapContainerRef?.nativeElement.scrollIntoView({
      behavior: 'smooth',
      block: 'center',
    });
  }

  onSaveEditing() {
    this.map.saveEditing();
    this.mapState.stopEditing();
  }

  onCancel() {
    this.map.cancelEditing();
    this.mapState.stopEditing();
  }

  onCancelCreate() {
    this.map.cancelCreating();
    this.mapState.stopCreatingShape();
  }

  onShapeEdited(updatedShape: MapElement) {
    if (!updatedShape.info?.id || !updatedShape.info?.coordinates) return;

    const id = updatedShape.info.id;     
    const coords = updatedShape.info.coordinates;
    const objType = updatedShape.class;
    if (!objType) return;

    let update$: Observable<any> | null = null;

    if (objType === 'farm') {
      const farm = {} as Farm;

      farm.id = id;
      farm.locationShapes = [
        { type: updatedShape.type, 
          label: updatedShape.info?.name || updatedShape.label || '', 
          coordinates: coords 
        }];
        
      update$ = this.facade.updateFarm(farm);
    }
    
    else if (objType === 'plot') {
      const plot = {} as Plot;
      plot.id = id;
      plot.locationShapes = [
        {
          type: updatedShape.type,
          label: updatedShape.info?.name || updatedShape.label || '',
          coordinates: coords
        }
      ]
      update$ = this.facade.updatePlot(plot);
    }

    else if (objType === 'diagnosis') {
      const diagnosis = {} as Diagnosis;
      diagnosis.id = id;
      diagnosis.locationShapes = [
        {
            type: updatedShape.type,
            label: updatedShape.info?.name || updatedShape.label || '',
            coordinates: coords
          }
        ];
      update$ = this.facade.updateDiagnosis(diagnosis);
    }

    if (!update$) return;

    update$.subscribe(() => {
      const copy = this.mapState.mapElements ? [...this.mapState.mapElements] : [];

      const index = copy.findIndex(s => s.id === updatedShape.id);

      if (index !== -1) {
        copy[index] = updatedShape; 
      } else {
        copy.push(updatedShape);   
      }

      this.mapState.setMapElements([...copy]);
    });
  }

  generateId(): string {
    return Math.random().toString(36).substring(2, 10) + Date.now().toString(36);
  }

  calculateArea(coords: { lat: number; lng: number }[]) {
    if (!coords || coords.length < 3) return 0;

    const points = coords.map(c => [c.lng, c.lat]) as [number, number][];

    // Fecha o polígono caso não esteja fechado
    const first = points[0];
    const last = points[points.length - 1];

    if (first[0] !== last[0] || first[1] !== last[1]) {
      points.push(first);
    }

    const polygon = turf.polygon([points]);
    
    const areaM2 = turf.area(polygon);
    const areaHa = areaM2 / 10000;

    return areaHa;
  }

  calculatePerimeter(coords: { lat: number; lng: number }[]) {
    if (!coords || coords.length < 2) return 0;
    const points = coords.map(c => [c.lng, c.lat]) as [number, number][];

    // Fecha o polígono caso não esteja fechado
    const first = points[0];
    const last = points[points.length - 1];
    if (first[0] !== last[0] || first[1] !== last[1]) {
      points.push(first);
    }
    const line = turf.lineString(points);
    const lengthMeters = turf.length(line, { units: 'meters' });
    return lengthMeters;
  }

  openEditPopup(element: MapElement) {
    this.dialogRef = this.dialogService.open(EditElementDialogComponent, {
      header: 'Editar elemento',
      width: '90vw',
      contentStyle: { 'max-height': '80vh', overflow: 'auto' },
      data: element,
      styleClass: 'custom-card-dialog'
    });


    this.dialogRef.onClose.subscribe((result: any) => {
      if (result) {
        this.onElementEdited(element, result); 
      }
    });
  }

  onElementEdited(element: MapElement, label: string = '') {
    const id = element.info?.id;
    if (!id || !label) return;

    const currentElements = this.mapState.mapElements ? [...this.mapState.mapElements] : [];
    const updatedElement = { ...element };

    const objType = element.class;
    if (!objType) return;

    let update$: Observable<any> | null = null;

    if (objType === 'farm') {
      const farm = {} as Farm;

      farm.id = id;
      farm.name = label;
      updatedElement.label = label;
  
      update$ = this.facade.updateFarm(farm);
    }
    
    else if (objType === 'plot') {
      const plot = {} as Plot;

      plot.id = id;
      plot.name = label;
      updatedElement.label = label;

      update$ = this.facade.updatePlot(plot);
    }

    else if (objType === 'diagnosis') {
      const diagnosis = {} as Diagnosis;

      diagnosis.id = id;

      const allDiagnosisShapes = currentElements.filter(e => e.info?.id === element.info?.id);
      
      diagnosis.locationShapes = allDiagnosisShapes.map(s => (
        { type: s.type, 
          label: element.id === s.id ? label : s.label, 
          coordinates: s.info?.coordinates || [] 
        }));
        
      updatedElement.label = label;

      update$ = this.facade.updateDiagnosis(diagnosis);
    }

    if (!update$) return;
    
    const index = this.mapState.mapElements ? this.mapState.mapElements.findIndex(s => s.id === element.id) : -1;

    update$.subscribe(() => {
      if (index !== -1) {
        currentElements[index] = updatedElement; 
        this.mapState.setMapElements([...currentElements]);
      }

    });
  }

  ngOnDestroy() {
    this.dialogRef?.close();
  }

}