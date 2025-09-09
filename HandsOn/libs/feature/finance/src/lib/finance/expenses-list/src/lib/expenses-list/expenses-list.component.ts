/* eslint-disable @angular-eslint/prefer-inject */
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent, Column, Row, TableComponent } from '@farm/ui';
import { ExpensesListComponentFacade } from './expenses-list.component.facade';

@Component({
  selector: 'lib-expenses-list',
  imports: [CommonModule, TableComponent, ButtonComponent],
  templateUrl: './expenses-list.component.html',
  styleUrl: './expenses-list.component.css',
})
export class ExpensesListComponent implements OnInit{
  data: Row[] = [];
  columns: Column[];
  loading = false;
  showMoreButton = true;

  constructor(private facade: ExpensesListComponentFacade) {
    this.columns = columns;
  }

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.expenses$.subscribe((expenses) => {
      this.data = expenses
    });

    this.facade.load();
  }

  refresh() {
    this.facade.load();
  }

  onCreate() {
    this.facade.navegateToCreateExpense();
  }
  
}

const columns: Column[] = [
  {
    field: 'description',
    header: 'Descrição',
    type: 'text',
    sortable: false,
    filterable: false,
    visible: true,
    showToUser: true,
  },
  {
    field: 'category',
    header: 'Categoria',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'amount',
    header: 'Valor',
    type: 'currency',
    sortable: true,
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
    field: 'createdAt',
    header: 'Criado em',
    type: 'datetime',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: false,
  },
  {
    field: 'updatedAt',
    header: 'Atualizado em',
    type: 'datetime',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: false,
  },
  {
    field: 'paymentMethod',
    header: 'Forma de Pagamento',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'receiptUrl',
    header: 'Comprovante',
    type: 'file',
    sortable: false,
    filterable: true,
    visible: true,
    showToUser: true,
  }
];
