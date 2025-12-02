import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { MapElement } from '../../models/map-element.model';

@Injectable({ providedIn: 'root' })
export class MapStateService {

  private _mapElements$ = new BehaviorSubject<MapElement[] | null>(null);
  private _focusElementId$ = new BehaviorSubject<string | null>(null);
  private _editingElementId$ = new BehaviorSubject<string | null>(null);
  private _changingStyle$ = new BehaviorSubject<string | null>(null);
  private _creatingShape$ = new BehaviorSubject<{ id: string; classType?: 'farm' | 'plot' | 'diagnosis' } | null>(null);
  
  /** Observable para os componentes escutarem */
  readonly mapElements$ = this._mapElements$.asObservable();
  focusElementId$ = this._focusElementId$.asObservable();
  editingElementId$ = this._editingElementId$.asObservable();
  changingStyle$ = this._changingStyle$.asObservable();
  creatingShape$ = this._creatingShape$.asObservable();

  get mapElements(): MapElement[] | null {
    return this._mapElements$.value;
  }

  setMapElements(elements: MapElement[]) {
    this._mapElements$.next(elements);
  }

  updateVisibilities(ids: string[], visible: boolean) {
    const current = this.mapElements;
    if (!current) return;

    const updated = current.map(e =>
      ids.includes(e.id) ? { ...e, visible } : e
    );

    this._mapElements$.next(updated);
  }

  updateVisibility(id: string, visible: boolean) {
    const current = this.mapElements;
    if (!current) return;

    const updated = current.map(e =>
      e.id === id ? { ...e, hideShapeOnly: visible } : e
    );
    this._mapElements$.next(updated);
  }

  startEditing(id: string) {
    this._editingElementId$.next(id);
  }

  stopEditing() {
    this._editingElementId$.next(null);
  }

  startChangingStyle(id: string) {
    this._changingStyle$.next(id);
  }

  stopChangingStyle() {
    this._changingStyle$.next(null);
  }

  deleteShape(id: string) {
    const current = this.mapElements;
    if (!current) return;

    const updated = current.filter(e => e.id !== id);
    this._mapElements$.next(updated);
  }

  focusElement(id: string) {
    this._focusElementId$.next(id);
  }

  startCreatingShape(id: string, classType?: 'farm' | 'plot' | 'diagnosis') {
    this._creatingShape$.next({ id, classType });
  }

  stopCreatingShape() {
    this._creatingShape$.next(null);
  }
}
