import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'lib-diagnoses',
  imports: [CommonModule, RouterModule],
  templateUrl: './diagnoses.html',
  styleUrl: './diagnoses.css',
})
export class Diagnoses {}
