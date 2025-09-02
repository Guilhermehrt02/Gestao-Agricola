import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ReportChartComponent,
  ReportSummaryComponent,
  DateRangeFilterComponent,
  CardComponent,
} from '@farm/ui';
import {
  ReportComponentFacade,
  ResponseCompare,
} from './reports.facade.component';
import { ChartData } from 'chart.js';
import { startOfMonth, endOfMonth } from 'date-fns';

import { Gallery } from 'libs/shared/ui/src/lib/components/gallery/gallery';
import { Accordion } from 'libs/shared/ui/src/lib/components/accordion/accordion';
// import { Carouselnp } from 'libs/shared/ui/src/lib/components/carousel/carousel';

export interface ItemCompare {
  images_book: string;
  results: {
    name: string;
    similarity: number;
  }[];
}

@Component({
  selector: 'lib-reports',
  imports: [
    CommonModule,
    ReportChartComponent,
    ReportSummaryComponent,
    DateRangeFilterComponent,
    Gallery,
    CardComponent,
    Accordion,
    // Carouselnp,
  ],
  templateUrl: './reports.component.html',
  styleUrl: './reports.component.css',
})
export class ReportsComponent implements OnInit {
  formData = {
    propriedade: 'Fazenda São José',
    safra: '2024/2025',
    talhao: 'Talhão 1',
    data: new Date(),
    tipoDiagnostico: 'Doença Foliar',
    foto: null,
    fotoUrl: 'assets/exemplo.jpg', // pode vir de FileReader
  };

  loading = false;
  id = '';
  results: ResponseCompare = [];
  imageUrl = 'assets/images/user_image_396.jpg';

  constructor(private resultsService: ReportComponentFacade) {}

  ngOnInit(): void {
    this.fetchResults();
  }

  fetchResults() {
    this.loading = true;
    this.resultsService.compareStaticImage().subscribe({
      next: (data) => {
        this.results = data; // data já é ItemCompare[]
        this.loading = false;
      },
      error: (err) => {
        console.error('Erro ao comparar imagem:', err);
        this.loading = false;
      },
    });
  }
}
