import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataViewModule } from 'primeng/dataview';
import { Skeleton } from 'primeng/skeleton';
import { ButtonComponent, InputComponent } from '../../..';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'lib-data-view',
  standalone: true,
  imports: [CommonModule, DataViewModule, Skeleton, ButtonComponent, InputComponent, FormsModule],
  templateUrl: './data-view.component.html',
  styleUrl: './data-view.component.css',
})
export class DataViewComponent {
  @Input() data: any[] = [];
  @Input() loading = false;
  @Input() rows = 10;
  @Input() rowsPerPageOptions: number[] = [10, 25, 50];
  @Input() paginator = true;
  @Input() stateKey = 'dataViewState';
  @Input() showRefresh = true;

  @Output() refresh: EventEmitter<void> = new EventEmitter();
  @Output() itemSelect: EventEmitter<any> = new EventEmitter();

  searchTerm = '';


  onRefresh() {
    this.refresh.emit();
  }

  onSelect(item: any) {
    this.itemSelect.emit(item);
  }

  onFilter(term: string) {
    this.searchTerm = term.toLowerCase();
  }

  get filteredData() {
    if (!this.searchTerm) return this.data;
    return this.data.filter((item) =>
      JSON.stringify(item).toLowerCase().includes(this.searchTerm)
    );
  }
}
