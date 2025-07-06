import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CardComponent, DiagnosisForm } from '@farm/ui';
import { DiagnosisComponentFacade } from './diagnosis.component.facade';
import { Diagnosis } from '@farm/core';

@Component({
  selector: 'lib-diagnosis',
  imports: [CommonModule, CardComponent, DiagnosisForm, RouterModule],
  templateUrl: './diagnosis.html',
  styleUrl: './diagnosis.css',
})
export class DiagnosisComponent implements OnInit, OnDestroy {
  id: string | undefined;
  diagnosis: Diagnosis | undefined;
  loading = false;

  title = 'Criar Diagnóstico';
  description = 'Preencha os campos abaixo para criar um novo diagnóstico';
  submitLabel = 'Cadastrar';

  constructor(
    // eslint-disable-next-line @angular-eslint/prefer-inject
    private route: ActivatedRoute,
    // eslint-disable-next-line @angular-eslint/prefer-inject
    private facade: DiagnosisComponentFacade
  ) {}

  ngOnInit() {
    this.facade.reset();

    this.id = this.route.snapshot.paramMap.get('id') || undefined;

    if (!this.id) {
      return;
    }
    this.title = 'Editar Diagnóstico';
    this.description = 'Preencha os campos abaixo para editar o diagnóstico';
    this.submitLabel = 'Editar';

    this.facade.load(this.id);

    this.facade.diagnosis$.subscribe((diagnosis) => {
      if (!diagnosis) return;

      this.diagnosis = diagnosis;
    });

    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });
  }

  ngOnDestroy() {
    this.facade.reset();
  }

  onSubmit(diagnosis: any) {
    this.facade.submit(diagnosis);
  }

}
