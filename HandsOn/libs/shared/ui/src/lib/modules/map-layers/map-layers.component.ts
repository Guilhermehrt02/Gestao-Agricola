/* eslint-disable @angular-eslint/prefer-inject */
import {
  Component,
  EventEmitter,
  Input,
  Output,
  OnDestroy,
  OnInit,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckboxModule } from 'primeng/checkbox';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { Subscription } from 'rxjs';
import { 
  MapElement,
  MapStateService
} from '@farm/core';
import { OverlayPanelModule } from 'primeng/overlaypanel';

interface MapLayer {
  label: string;
  class: string;
  visible?: boolean;
  focusable?: boolean;
  children?: MapLayer[];
  data?: any;
  hideShapeOnly?: boolean;
  showMenu?: boolean;
  showItems?: boolean;
}

@Component({
  selector: 'lib-map-layers',
  standalone: true,
  imports: [CommonModule, 
    CheckboxModule, 
    FormsModule, 
    ButtonModule, 
    OverlayPanelModule,
  ],
  templateUrl: './map-layers.component.html',
  styleUrls: ['./map-layers.component.css'],
})
export class MapLayersComponent implements OnInit, OnDestroy {
  @Output() createShape = new EventEmitter<{ id: string; classType?: 'farm' | 'plot' | 'diagnosis' }>();
  @Output() editShape = new EventEmitter<string>();
  @Output() changeStyle = new EventEmitter<string>();
  @Output() deleteShape = new EventEmitter<string>();


  private sub = new Subscription();
  layers: MapLayer[] = [];
  adding = false;
  newLayerName = '';
  showLayerList = true;
  constructor(private mapState: MapStateService) {}

  ngOnInit() {
    this.sub.add(
      this.mapState.mapElements$.subscribe(elements => {
        this.buildLayerGroups(elements || []);
      })
    );
  }

  private buildLayerGroups(elements: MapElement[]) {
    const farmsMap: { [farmId: string]: MapLayer } = {};

    for (const item of elements) {
      if (item.class === 'farm' && item.info?.id) {
        const farmId =  item.info?.id;

        farmsMap[farmId] = {
          label: item.label || item.info?.name || 'Fazenda sem nome',
          class: 'farm',
          visible: item.visible,
          focusable: true,
          data: item,
          children: [],
          showMenu: false,
          showItems: true,
        };
      }
    }

    for (const item of elements) {
      if (item.class === 'plot') {
        const farmId = item.info?.farmId;

        const plotLayer: MapLayer = {
          label: item.label || item.info?.name || 'Talhão sem nome',
          class: 'plot',
          visible: item.visible,
          focusable: true,
          data: item,
          children: [],
          showMenu: false,
          showItems: true,
        };

        if (farmId && farmsMap[farmId]) {
          farmsMap[farmId].children?.push(plotLayer);
        }
      }
    }

    for (const item of elements) {
      if (item.class === 'diagnosis') {
        const plotId = item.info?.plotId;

        const diagnosisLayer: MapLayer = {
          label: item.label || item.info?.diseaseName || 'Diagnóstico',
          class: 'diagnosis',
          visible: item.visible,
          focusable: true,
          data: item,
        };

        const plotLayer = Object.values(farmsMap)
          .flatMap((f) => f.children || [])
          .find((p) => p.data?.info?.id === plotId);

        if (plotLayer && plotLayer.children) {
          plotLayer.children.push(diagnosisLayer);
        }
      }
    }

    this.layers = Object.values(farmsMap);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  onToggle(layer: MapLayer) {
    const idsToUpdate = this.collectIds(layer);
    const newVisibility = layer.visible || false;

    this.mapState.updateVisibilities(idsToUpdate, newVisibility);
  }

  onFocus(layer: MapLayer) {
    if (layer.data?.id) {
      this.mapState.focusElement(layer.data.id);
    }
  }

  toggleLayerList() {
    this.showLayerList = !this.showLayerList;
  }

  onEditShape(id: string) {
    this.editShape.emit(id);
  }

  onChangeStyle(id: string) {
    this.changeStyle.emit(id);
  }

  onDeleteShape(id: string) {
    this.deleteShape.emit(id);
  }

  onCreateShape(id: string, classType?: 'farm' | 'plot' | 'diagnosis') {
    this.createShape.emit({ id, classType });
  }

  onToggleOnlyOneShape(layer: MapLayer) {
    if (!layer.data?.hasShapes) return;
    layer.data.hideShapeOnly = !layer.data.hideShapeOnly;
    const newHideShape = layer.data.hideShapeOnly || false;

    this.mapState.updateVisibility(layer.data.id, newHideShape);
  }

  private collectIds(layer: MapLayer): string[] {
    let ids: string[] = [];

    if (layer.data?.id) {
      ids.push(layer.data.id);
    }

    if (layer.children && layer.children.length > 0) {
      for (const child of layer.children) {
        ids = ids.concat(this.collectIds(child));
      }
    }

    return ids;
  }
}