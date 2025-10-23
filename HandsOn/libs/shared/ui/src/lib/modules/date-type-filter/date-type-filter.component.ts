import { Component, EventEmitter, Output, OnInit, Input } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  AbstractControl,
  ValidationErrors,
  ReactiveFormsModule
} from '@angular/forms';
import {
  subMonths,
  startOfMonth,
  endOfMonth,
  startOfYear,
  endOfYear,
  format,
} from 'date-fns';
import { CommonModule } from '@angular/common';
import {
  SelectComponent,
  SelectOption,
} from '../../components/select/select.component';
import { ButtonComponent } from '../../components/button/button.component';
import { InputComponent } from '../../components/input/input.component';
import { Diagnosis, DiagnosisStatus, ExpenseCategoryLabels } from '@farm/core';
import { RevenueSourceLabels } from '@farm/core';

const expenseCategoryOptions: SelectOption[] = Object.entries(
  ExpenseCategoryLabels,
).map(([value, label]) => ({ value, label }));

const revenueSourceOptions: SelectOption[] = Object.entries(
  RevenueSourceLabels,
).map(([value, label]) => ({ value, label }));

@Component({
  selector: 'lib-date-type-filter',
  imports: [CommonModule, SelectComponent, ButtonComponent, InputComponent, ReactiveFormsModule],
  templateUrl: './date-type-filter.component.html',
  styleUrls: ['./date-type-filter.component.css'],
  standalone: true,
})
export class DateTypeFilterComponent implements OnInit {
  @Input() diagnoses: Diagnosis[] | undefined;
  form!: FormGroup;

  farms: SelectOption[] = [];
  plots: SelectOption[] = [];
  harvests: SelectOption[] = [];
  problems: SelectOption[] = [];
  cultures: SelectOption[] = [];
  status: SelectOption[] = Object.entries(
      DiagnosisStatus,
  ).map(([value, label]) => ({ value, label }));

  constructor() {
    this.form = new FormGroup({
      farm: new FormControl(null),
      plot: new FormControl(null),
      harvest: new FormControl(null),
      problem: new FormControl(null),
      culture: new FormControl(null),
      result: new FormControl(null),
      startDate: new FormControl(null),
      endDate: new FormControl(null),
    });
  }

  ngOnInit() {
    if (this.diagnoses?.length) {
      this.loadOptions();
    }
  }

  /** 
   * Extrai e organiza os dados únicos a partir dos diagnósticos
   */
  loadOptions() {
    const farmsMap = new Map<string, string>();
    const plotsMap = new Map<string, string>();
    const harvestsMap = new Map<string, string>();
    const problemsMap = new Map<string, string>();
    const culturesMap = new Map<string, string>();

    (this.diagnoses || []).forEach((d) => {
      if (d.farm?.id && !farmsMap.has(d.farm.id)) {
        farmsMap.set(d.farm.id, d.farm.name);
      }

      if (d.plot?.id && !plotsMap.has(d.plot.id)) {
        plotsMap.set(d.plot.id, d.plot.name);
      }

      if (d.harvest?.id && !harvestsMap.has(d.harvest.id)) {
        harvestsMap.set(d.harvest.id, d.harvest.name);
      }

      d.result?.imageSimilarities?.forEach((sim) => {
        if (sim.disease && !problemsMap.has(sim.disease.id)) {
          problemsMap.set(sim.disease.id, sim.disease.name);
        }
      });
    });

    this.farms = Array.from(farmsMap, ([value, label]) => ({ label, value }));
    this.plots = Array.from(plotsMap, ([value, label]) => ({ label, value }));
    this.harvests = Array.from(harvestsMap, ([value, label]) => ({ label, value }));
    this.problems = Array.from(problemsMap, ([value, label]) => ({ label, value }));
    this.cultures = Array.from(culturesMap, ([value, label]) => ({ label, value }));
  }

  getFilterValues() {
    return this.form.getRawValue();
  }
}
