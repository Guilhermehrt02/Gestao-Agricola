/* eslint-disable @angular-eslint/prefer-inject */
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // ← ADICIONE ESTE
import { ButtonComponent } from '@farm/ui';
import { DiagnosesListComponentFacade } from './diagnoses-list.facade';
import { DataView } from 'primeng/dataview';
import { TagModule } from 'primeng/tag';
import { ButtonModule } from 'primeng/button';
import { SelectModule } from 'primeng/select';
import { SelectItem } from 'primeng/api';
import { SelectButtonModule } from 'primeng/selectbutton';

@Component({
  selector: 'lib-diagnoses-list',
  imports: [
    CommonModule,
    FormsModule, // ← ADICIONE ESTE
    SelectButtonModule,
    ButtonComponent,
    DataView,
    TagModule,
    ButtonModule,
    SelectModule,
  ],
  templateUrl: './diagnoses-list.html',
  styleUrl: './diagnoses-list.css',
})
export class DiagnosesList implements OnInit {
  data: any[] = [];
  loading = false;
  sortOptions!: SelectItem[];
  sortKey!: string;
  sortOrder!: number;
  sortField!: string;
  layout: 'list' | 'grid' = 'list';
  options = [
    { label: 'List', value: 'list' },
    { label: 'Grid', value: 'grid' },
  ];

  constructor(private facade: DiagnosesListComponentFacade) {}

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => (this.loading = loading));
    this.facade.diagnoses$.subscribe((diagnoses) => (this.data = diagnoses));

    this.sortField = 'createdAt';
    this.sortOrder = -1;

    this.sortOptions = [
      { label: 'Recente', value: this.sortField },
      { label: 'Ultimos', value: '!' + this.sortField },
    ];

    this.facade.load();
  }

  onSortChange(event: any) {
    let value = event.value;

    if (value.indexOf('!') === 0) {
      this.sortOrder = -1;
      this.sortField = value.substring(1, value.length);
    } else {
      this.sortOrder = 1;
      this.sortField = value;
    }
  }

  refresh() {
    this.facade.load();
  }

  onCreate() {
    this.facade.navigateToCreateDiagnosis();
  }

  onEdit(item: any) {
    this.facade.navigateToEditDiagnosis(item.id);
  }

  onView(item: any) {
    this.facade.navigateToViewDiagnosis(item.id);
  }

  onDelete(item: any) {
    this.facade.navigateToDeleteDiagnosis(item.id);
  }
}
