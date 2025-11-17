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

interface MapLayer {
  label: string;
  class: string;
  visible?: boolean;
  focusable?: boolean;
  children?: MapLayer[];
  data?: any;
  hideShapeOnly?: boolean;
}

@Component({
  selector: 'lib-map-layers',
  standalone: true,
  imports: [CommonModule, CheckboxModule, FormsModule, ButtonModule],
  templateUrl: './map-layers.component.html',
  styleUrls: ['./map-layers.component.css'],
})
export class MapLayersComponent implements OnInit, OnDestroy {
  @Output() addLayer = new EventEmitter<string>();
  @Output() createShape = new EventEmitter<{ type: 'farm' | 'plot' | 'diagnosis'; data: any }>();
  @Output() editShape = new EventEmitter<{ type: 'farm' | 'plot' | 'diagnosis'; data: any }>();
  @Output() toggleOnlyFarmShape = new EventEmitter<{
    id: string;
    hide: boolean;
  }>();
  @Output() toggleOnlyPlotShape = new EventEmitter<{
    id: string;
    hide: boolean;
  }>();

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

    this.mapState.updateVisibility(idsToUpdate, newVisibility);
  }

  onFocus(layer: MapLayer) {
    if (layer.data?.id) {
      this.mapState.focusElement(layer.data.id);
    }
  }

  toggleLayerList() {
    this.showLayerList = !this.showLayerList;
  }

  onCreateShape(type: 'farm' | 'plot' | 'diagnosis', data: any) {
    this.createShape.emit({ type, data });
  }

  onEditShape(type: 'farm' | 'plot' | 'diagnosis', data: any) {
    this.editShape.emit({ type, data });
  }

  onToggleOnlyFarmShape(layer: MapLayer) {
    if (!layer.data?.hasShapes) return;

    layer.hideShapeOnly = !layer.hideShapeOnly;

    this.toggleOnlyFarmShape.emit({
      id: layer.data.info.id,
      hide: layer.hideShapeOnly
    });
  }

  onToggleOnlyPlotShape(layer: MapLayer) {
    if (!layer.data?.hasShapes) return;

    layer.hideShapeOnly = !layer.hideShapeOnly;

    this.toggleOnlyPlotShape.emit({
      id: layer.data.info.id,
      hide: layer.hideShapeOnly
    });
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