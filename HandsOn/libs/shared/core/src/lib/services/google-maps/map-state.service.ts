import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { MapElement } from '../../models/map-element.model';

@Injectable({ providedIn: 'root' })
export class MapStateService {

  private _mapElements$ = new BehaviorSubject<MapElement[] | null>(null);
  private _focusElementId$ = new BehaviorSubject<string | null>(null);

  /** Observable para os componentes escutarem */
  readonly mapElements$ = this._mapElements$.asObservable();

  focusElementId$ = this._focusElementId$.asObservable();

  /** Getter para pegar o valor atual a qualquer momento */
  get mapElements(): MapElement[] | null {
    return this._mapElements$.value;
  }

  setMapElements(elements: MapElement[]) {
    this._mapElements$.next(elements);
  }

  updateVisibility(ids: string[], visible: boolean) {
    const current = this.mapElements;
    if (!current) return;

    const updated = current.map(e =>
      ids.includes(e.id) ? { ...e, visible } : e
    );

    this._mapElements$.next(updated);
  }

  updateShape(id: string, newShape: any) {
    const current = this.mapElements;
    if (!current) return;

    const updated = current.map(e =>
      e.id === id ? { ...e, mapObject: newShape, hasShapes: true } : e
    );

    this._mapElements$.next(updated);
  }

  focusElement(id: string) {
    this._focusElementId$.next(id);
  }

  requestCreateShape(elem: MapElement) {
    // outro BehaviorSubject separado se quiser comunicação mais clara
  }
}
