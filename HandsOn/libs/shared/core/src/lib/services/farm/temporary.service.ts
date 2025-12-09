import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class TemporaryLocalService {
  private readonly KEY = 'temporary-shapes';

  load(): any[] {
    const raw = localStorage.getItem(this.KEY);
    return raw ? JSON.parse(raw) : [];
  }

  save(temporaries: any[]): void {
    localStorage.setItem(this.KEY, JSON.stringify(temporaries));
  }

  clear(): void {
    localStorage.removeItem(this.KEY);
  }
}
