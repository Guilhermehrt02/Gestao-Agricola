/* eslint-disable @angular-eslint/prefer-inject */
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent, Column, Row, TableComponent, DataViewComponent } from '@farm/ui';
import { DiagnosesListComponentFacade } from './diagnoses-list.facade';
import { DataView } from 'primeng/dataview';
import { TagModule } from 'primeng/tag';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'lib-diagnoses-list',
  imports: [CommonModule, ButtonComponent, DataView, TagModule, ButtonModule],
  templateUrl: './diagnoses-list.html',
  styleUrl: './diagnoses-list.css',
})
export class DiagnosesList implements OnInit {
  data: any[] = [];
  loading = false;

  constructor(private facade: DiagnosesListComponentFacade) {}

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => (this.loading = loading));
    this.facade.diagnoses$.subscribe((diagnoses) => (this.data = diagnoses));

    this.facade.load();
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