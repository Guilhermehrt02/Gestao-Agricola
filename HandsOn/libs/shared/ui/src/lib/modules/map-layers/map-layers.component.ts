import {
  Component,
  EventEmitter,
  Input,
  Output,
  OnChanges,
  SimpleChanges,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckboxModule } from 'primeng/checkbox';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';

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
export class MapLayersComponent implements OnChanges {
  @Input() rawLayers: any[] = [];
  @Output() toggleVisibility = new EventEmitter<MapLayer>();
  @Output() focusLayer = new EventEmitter<MapLayer>();
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


  layers: MapLayer[] = [];
  adding = false;
  newLayerName = '';
  showLayerList = true;

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['rawLayers'] && !changes['rawLayers'].isFirstChange() && changes['rawLayers'].currentValue !== changes['rawLayers'].previousValue) {
      this.buildLayerGroups();
    }
  }

  private buildLayerGroups() {
    const farmsMap: { [farmId: string]: MapLayer } = {};

    for (const item of this.rawLayers) {
      if (item.class === 'farm') {
        const farmId = item.info?.id || item.id || item.label;
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

    for (const item of this.rawLayers) {
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

    for (const item of this.rawLayers) {
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

        if (plotLayer) {
          if (!plotLayer.children) plotLayer.children = [];
          plotLayer.children.push(diagnosisLayer);
        }
      }
    }

    this.layers = Object.values(farmsMap);
  }

  onToggle(layer: MapLayer) {
    this.toggleVisibility.emit(layer);
  }

  onFocus(layer: MapLayer) {
    this.focusLayer.emit(layer);
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
}
