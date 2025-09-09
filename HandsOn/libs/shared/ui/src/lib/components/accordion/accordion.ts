import { AccordionModule } from 'primeng/accordion';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'lib-accordion',
  imports: [AccordionModule, CommonModule],
  templateUrl: './accordion.html',
  standalone: true,
  styleUrl: './accordion.css',
})
export class Accordion {
  content_01 = `Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in 
  reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in 
  culpa qui officia deserunt mollit anim id est laborum.`;

  tabs = [
    { title: 'Sintomas', content: `${this.content_01}`, value: '0' },
    { title: 'Prevenção', content: `${this.content_01}`, value: '1' },
    {
      title: 'Recomendações',
      content: `${this.content_01}`,
      value: '2',
    },
  ];
}