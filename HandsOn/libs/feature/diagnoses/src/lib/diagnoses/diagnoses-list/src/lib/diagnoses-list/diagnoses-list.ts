/* eslint-disable @angular-eslint/prefer-inject */
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent, Column, Row, TableComponent } from '@farm/ui';
import { DiagnosesListComponentFacade } from './diagnoses-list.facade';

@Component({
  selector: 'lib-diagnoses-list',
  imports: [CommonModule, TableComponent, ButtonComponent],
  templateUrl: './diagnoses-list.html',
  styleUrl: './diagnoses-list.css',
})
export class DiagnosesList implements OnInit {
  data: Row[] = [];
  columns: Column[];
  loading = false;
  showMoreButton = true;

  constructor(private facade: DiagnosesListComponentFacade) {
    this.columns = columns;
  }

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.diagnoses$.subscribe((diagnoses) => {
      this.data = diagnoses;
    });

    this.facade.load();
  }

  refresh() {
    this.facade.load();
  }

  onCreate() {
    this.facade.navigateToCreateDiagnosis();
  }
}

const columns: Column[] = [
  {
    field: 'status',
    header: 'Status',
    type: 'text',
    sortable: false,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'result',
    header: 'Resultado',
    type: 'text',
    sortable: false,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'uploadType',
    header: 'Tipo de Upload',
    type: 'text',
    sortable: false,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'date',
    header: 'Data',
    type: 'date',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'farm',
    header: 'Propriedade',
    type: 'text',
    sortable: false,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'harvest',
    header: 'Safra',
    type: 'text',
    sortable: false,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'plot',
    header: 'Talhão',
    type: 'text',
    sortable: false,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'createdAt',
    header: 'Data de Criação',
    type: 'datetime',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'updatedAt',
    header: 'Data de Atualização',
    type: 'datetime',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'photoUrl',
    header: 'Foto',
    type: 'file',
    sortable: false,
    filterable: true,
    visible: true,
    showToUser: true,
  }
];
