import { AccordionModule } from 'primeng/accordion';
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'lib-accordion',
  imports: [AccordionModule, CommonModule],
  templateUrl: './accordion.html',
  standalone: true,
  styleUrl: './accordion.css',
})
export class Accordion implements OnChanges {
  @Input() symptoms = '';
  @Input() prevention = '';
  @Input() recommendation = '';

  tabs: { title: string; content: string; value: string }[] = [];

  ngOnChanges() {
    this.tabs = [
      { title: 'Sintomas', content: this.symptoms, value: '0' },
      { title: 'Prevenção', content: this.prevention, value: '1' },
      { title: 'Recomendações', content: this.recommendation, value: '2' },
    ];
  }
}
