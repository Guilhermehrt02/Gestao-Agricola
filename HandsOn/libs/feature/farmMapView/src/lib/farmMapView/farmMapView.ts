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
  EditElementDialogComponent,
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
import { style } from '@angular/animations';

const MapLayerColors = {
  farm: {
    fillColor: '#1b5e20',
    strokeColor: '#66bb6a',
    strokeWeight: 2,
    fillOpacity: 0.6,
    strokeOpacity: 1.0
  },
  plot: {
    fillColor: '#0d47a1',
    strokeColor: '#42a5f5',
    strokeWeight: 2,
    fillOpacity: 0.6,
    strokeOpacity: 1.0
  },
  diagnosis: {
    fillColor: '#b71c1c',
    strokeColor: '#ef5350',
    strokeWeight: 2,
    fillOpacity: 0.6,
    strokeOpacity: 1.0
  },
  temporary: {
    fillColor: '#FADA5E',
    strokeColor: '#66bb6a',
    strokeWeight: 2,
    fillOpacity: 0.6,
    strokeOpacity: 1.0
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
  sidebarOpen = true;
  changingStyleShape: MapElement | null = null;

  @ViewChild('mapContainer', { read: ElementRef }) mapContainerRef!: ElementRef;
  @ViewChild(MapComponent) map!: MapComponent;
  editingElementId$!: Observable<string | null>;
  changingStyleId$!: Observable<string | null>;
  creatingShape$!: Observable<{ id: string; classType?: 'farm' | 'plot' | 'diagnosis' | 'temporary' } | null>;
  private dialogRef?: DynamicDialogRef;
  
  tempStyle: any = {
    fillColor: '#00FF00',
    strokeColor: '#66bb6a',
    strokeWeight: 2,
    fillOpacity: 0.6,
    strokeOpacity: 1.0
  };

  originalStyle: any = null;

  editingShapeStyle: any = null;

  colorPalette = [
    '#FF0000', '#FF6600', '#FFFF00', '#66FF00', '#00FF00',
    '#00FF66', '#00FFFF', '#0066FF', '#0000FF', '#6600FF',
    '#FF00FF', '#663300', '#333333', '#000000'
  ];

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
    this.changingStyleId$ = this.mapState.changingStyle$;

    this.facade.loading$.subscribe(v => this.loading = v);

    combineLatest([
      this.facade.farms$,
      this.facade.plots$,
      this.facade.diagnoses$,
      this.facade.temporaries$
    ]).subscribe(([farms, plots, diagnoses, temporaries]) => {
      const farmsShapes = this.getFarmsShapes(farms);
      const plotsShapes = this.getPlotsShapes(plots);
      const diagnosisShapes = this.getDiagnosisShapes(diagnoses);
      const temporaryShapes = this.getTemporaryShapes(temporaries);

      const mapElements = [
        ...farmsShapes,
        ...plotsShapes,
        ...diagnosisShapes,
        ...temporaryShapes
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
            style: {
              fillColor: MapLayerColors.farm.fillColor,
              strokeColor: MapLayerColors.farm.strokeColor,
              strokeWeight: MapLayerColors.farm.strokeWeight,
              fillOpacity: MapLayerColors.farm.fillOpacity,
              strokeOpacity: MapLayerColors.farm.strokeOpacity
            },
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
            style: {
              fillColor: MapLayerColors.plot.fillColor,
              strokeColor: MapLayerColors.plot.strokeColor,
              strokeWeight: MapLayerColors.plot.strokeWeight,
              fillOpacity: MapLayerColors.plot.fillOpacity,
              strokeOpacity: MapLayerColors.plot.strokeOpacity
            },
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
        style: {
          fillColor: MapLayerColors.diagnosis.fillColor,
          strokeColor: MapLayerColors.diagnosis.strokeColor,
          strokeWeight: MapLayerColors.diagnosis.strokeWeight,
          fillOpacity: MapLayerColors.diagnosis.fillOpacity,
          strokeOpacity: MapLayerColors.diagnosis.strokeOpacity
        },
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

  getTemporaryShapes(temporaries: any[]): MapElement[] {
    const shapes: MapElement[] = [];

    temporaries.forEach(temp => {
      const locShapes = temp.locationShapes || [];

      if (locShapes.length > 0) {
        locShapes.forEach((shape: any) => {
          shapes.push({
            id: this.generateId(),
            class: 'temporary',
            hasShapes: true,
            visible: true,
            hideShapeOnly: false,
            editable: false,
            label: shape.label || 'Desenho temporário',
            style: {
              fillColor: MapLayerColors.temporary.fillColor,
              strokeColor: MapLayerColors.temporary.strokeColor,
              strokeWeight: MapLayerColors.temporary.strokeWeight,
              fillOpacity: MapLayerColors.temporary.fillOpacity,
              strokeOpacity: MapLayerColors.temporary.strokeOpacity
            },
            type: shape.type, 
            children: [],
            mapObject: null,
            info: {
              id: temp.id,
              name: shape.label || 'Desenho temporário',
              coordinates: shape.coordinates, 
              totalArea: shape?.coordinates.length ? this.calculateArea(shape.coordinates) : 0,
              perimeter: shape?.coordinates.length ? this.calculatePerimeter(shape.coordinates) : 0,
              date: temp.date
            }
          });
        });
      } else {
        shapes.push({
          id: this.generateId(),
          class: 'temporary',
          hasShapes: false,
          visible: true,
          editable: false,
          label: temp.label || 'Desenho temporário',
          info: {
            id: temp.id,
            name: temp.label || 'Desenho temporário',
            date: temp.date
          }
        });
      }
    });

    return shapes;
  }


  onEditShape(id: string) {
    this.mapState.startEditing(id);

    this.mapContainerRef?.nativeElement.scrollIntoView({
      behavior: 'smooth',
      block: 'center',
    });
  }

  openStyleEditor(id: string) {
   const shape = this.mapState.mapElements?.find(s => s.id === id);
    if (!shape || !shape.style) return;

    this.editingShapeStyle = shape;
    this.mapState.focusElement(id);
    this.originalStyle = {
      ...shape.style
    };

    this.tempStyle = {
      ...shape.style
    };
  }

  onChangeColor(color: string) {
    this.tempStyle.fillColor = color;
  }

  onDeleteShape(id: string) {
    this.deleteElementShape(id);

    this.mapContainerRef?.nativeElement.scrollIntoView({
      behavior: 'smooth',
      block: 'center',
    });
  }

  onCreateShape(id: string, classType?: 'farm' | 'plot' | 'diagnosis' | 'temporary') {
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

  onSaveChangingStyle() {
    if (!this.editingShapeStyle) return;

    this.editingShapeStyle.style = this.tempStyle;

    const index = this.mapState.mapElements ? this.mapState.mapElements.findIndex(s => s.id === this.editingShapeStyle?.id) : -1;

    if (index !== -1 && this.editingShapeStyle) {
      const copy = this.mapState.mapElements ? [...this.mapState.mapElements] : [];
      copy[index] = this.editingShapeStyle; 
      this.mapState.setMapElements([...copy]);
    }

    this.editingShapeStyle = null;
    this.originalStyle = null;
    this.tempStyle = null;
  }

  onCancel() {
    this.map.cancelEditing();
    this.mapState.stopEditing();
  }

  onCancelChangingStyle() {
    this.editingShapeStyle = null;
    this.originalStyle = null;
    this.tempStyle = null;
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

    else if (objType === 'temporary') {
      const temporary = {} as any;

      temporary.id = updatedShape.id;
      temporary.locationShapes = [
        {
            type: updatedShape.type,
            label: updatedShape.info?.name || updatedShape.label || '',
            coordinates: coords
          }
        ];

      update$ = this.facade.saveTemporaryShapes(temporary);
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

  deleteElementShape(id: string) {
    const currentElements = this.mapState.mapElements ? [...this.mapState.mapElements] : [];
    const elementToDelete = currentElements.find(e => e.id === id);
    if (!elementToDelete) return;
    
    const objType = elementToDelete.class;
    if (!objType) return;

    let delete$: Observable<any> | null = null;

    if (objType === 'farm') {
      const farm = {} as Farm;

      farm.id = elementToDelete.info?.id || '';

      delete$ = this.facade.updateFarm(farm);
    }
    else if (objType === 'plot') {
      const plot = {} as Plot;

      plot.id = elementToDelete.info?.id || '';

      delete$ = this.facade.updatePlot(plot);
    }
    else if (objType === 'diagnosis') {
      const diagnosis = {} as Diagnosis;
      diagnosis.id = elementToDelete.info?.id || '';

      const updatedDiagnosisShapes = currentElements.filter(e => e.info?.id === elementToDelete.info?.id && e.id !== id);

      diagnosis.locationShapes = updatedDiagnosisShapes.map(s => (
        { type: s.type, 
          label: s.label, 
          coordinates: s.info?.coordinates || [] 
        }));

      delete$ = this.facade.updateDiagnosis(diagnosis);
    }else if (objType === 'temporary') {
      delete$ = this.facade.deleteTemporaryShapes(elementToDelete.info?.id || '');
    }

    if (!delete$) return;

    delete$.subscribe(() => {
      const updatedElements = this.mapState.mapElements ? this.mapState.mapElements.filter(e => e.id !== id) : [];
      this.mapState.setMapElements(updatedElements);
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
      data: { 
        label: element.label,
        mode: 'edit',
        type: element.class || 'temporary'
      },
      styleClass: 'custom-card-dialog'
    });

    this.dialogRef.onClose.subscribe(result => {
      if (result) {
        this.onElementEdited(element, result.value);
      }
    });
  }


  // openCreatePopup() {
  //   this.dialogRef = this.dialogService.open(EditElementDialogComponent, {
  //     header: 'Criar novo elemento',
  //     width: '90vw',
  //     contentStyle: { 'max-height': '80vh', overflow: 'auto' },
  //     data: { 
  //       mode: 'create'
  //     },
  //     styleClass: 'custom-card-dialog'
  //   });

  //   this.dialogRef.onClose.subscribe(result => {
  //     if (result) {
  //       //this.onElementCreated(result.value);
  //     }
  //   });
  // }


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