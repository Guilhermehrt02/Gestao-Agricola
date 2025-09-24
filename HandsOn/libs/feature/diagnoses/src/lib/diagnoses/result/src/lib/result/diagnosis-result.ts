/* eslint-disable @angular-eslint/prefer-inject */
import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Accordion, Gallery, ImageCompare, CardComponent } from '@farm/ui';
import { Diagnosis } from '@farm/core';
import { DiagnosisResultFacade } from './diagnosis-result.facade';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { ReactiveFormsModule, FormControl } from '@angular/forms';

@Component({
  selector: 'lib-diagnosis-result',
  imports: [
    CommonModule, 
    Accordion, 
    Gallery, 
    RouterModule, 
    ImageCompare, 
    CardComponent,
    ReactiveFormsModule],
  templateUrl: './diagnosis-result.html',
  styleUrl: './diagnosis-result.css',
})
export class DiagnosisResult implements OnInit, OnDestroy {
  id: string | undefined;
  diagnosis: Diagnosis | undefined;
  loading = false;
  showComment = false;
  selectedOption: 'sim' | 'nao' | 'parcial' = 'sim';
  commentControl = new FormControl('');
  feedbackSent = false;

  title = "Resultado do Diagnóstico";
  description = "Veja abaixo o resultado do diagnóstico realizado para a sua lavoura.";

  mainResult?: any;
  otherResults: any[] = [];

  constructor(
    private route: ActivatedRoute,
    public facade: DiagnosisResultFacade
  ) {}

  ngOnInit() {
    this.facade.reset();

    this.id = this.route.snapshot.paramMap.get('id') || undefined;

    if(!this.id) return;

    this.facade.load(this.id);

    this.facade.diagnosis$.subscribe((diagnosis) => {
      if (!diagnosis) return;

      this.diagnosis = diagnosis;
      this.mainResult = diagnosis.result.imageSimilarities[0];
      this.otherResults = diagnosis.result.imageSimilarities.slice(1);
    });

    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });
  }

  ngOnDestroy() {
    this.facade.reset();
  }
  showCommentBox(option: 'nao' | 'parcial') {
    this.selectedOption = option;
    this.showComment = true;
    this.commentControl.setValue('');
  }

  submitFeedback(option: 'sim' | 'nao' | 'parcial', comment = '') {
    this.showComment = false;
    this.selectedOption = 'sim';
    this.commentControl.setValue('');
    this.feedbackSent = true;
  }
}
