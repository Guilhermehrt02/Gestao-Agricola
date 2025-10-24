import {
  Component,
  Input,
  OnChanges,
  SimpleChanges,
  Output,
  EventEmitter,
} from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import {
  SelectComponent,
  SelectOption,
} from '../../components/select/select.component';
import { ButtonComponent } from '../../components/button/button.component';
import { InputComponent } from '../../components/input/input.component';
import { Diagnosis, DiagnosisStatus } from '@farm/core';

@Component({
  selector: 'lib-date-type-filter',
  imports: [
    CommonModule,
    SelectComponent,
    ButtonComponent,
    InputComponent,
    ReactiveFormsModule,
  ],
  templateUrl: './date-type-filter.component.html',
  styleUrls: ['./date-type-filter.component.css'],
  standalone: true,
})
export class DateTypeFilterComponent implements OnChanges {
  @Input() diagnoses: Diagnosis[] = [];
  @Output() locationShapesFiltered = new EventEmitter<any>();

  selectedFilter: any = null;
  form!: FormGroup;

  farms: SelectOption[] = [];
  plots: SelectOption[] = [];
  harvests: SelectOption[] = [];
  problems: SelectOption[] = [];
  cultures: SelectOption[] = [];

  statusOptions: SelectOption[] = Object.entries(DiagnosisStatus).map(
    ([value, label]) => ({ value, label }),
  );

  constructor() {
    this.form = new FormGroup({
      farm: new FormControl(null),
      plot: new FormControl(null),
      harvest: new FormControl(null),
      problem: new FormControl(null),
      culture: new FormControl(null),
      status: new FormControl(null),
      startDate: new FormControl(null),
      endDate: new FormControl(null),
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['diagnoses'] && this.diagnoses?.length) {
      this.loadOptions();
    }
  }

  loadOptions() {
    const farmsMap = new Map<string, string>();
    const plotsMap = new Map<string, string>();
    const harvestsMap = new Map<string, string>();
    const problemsMap = new Map<string, string>();
    const culturesMap = new Map<string, string>();

    this.diagnoses = this.diagnoses.filter((d) => d.locationShapes.length > 0);

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
    }); 

    this.farms = Array.from(farmsMap, ([value, label]) => ({ label, value }));
    this.plots = Array.from(plotsMap, ([value, label]) => ({ label, value }));
    this.harvests = Array.from(harvestsMap, ([value, label]) => ({ label, value }));
    this.problems = Array.from(problemsMap, ([value, label]) => ({ label, value }));
    this.cultures = Array.from(culturesMap, ([value, label]) => ({ label, value }));

    this.locationShapesFiltered.emit(
      this.diagnoses.map((d) => d.locationShapes).flat(),
    );
  }

  get startDate(): FormControl {
    return this.form.get('startDate') as FormControl;
  }

  get endDate(): FormControl {
    return this.form.get('endDate') as FormControl;
  }

  get farm(): FormControl {
    return this.form.get('farm') as FormControl;
  }

  get plot(): FormControl {
    return this.form.get('plot') as FormControl;
  }

  get harvest(): FormControl {
    return this.form.get('harvest') as FormControl;
  }

  get problem(): FormControl {
    return this.form.get('problem') as FormControl;
  }

  get culture(): FormControl {
    return this.form.get('culture') as FormControl;
  }

  get status(): FormControl {
    return this.form.get('status') as FormControl;
  }

  onFilterChange() {
    const filter = this.form.getRawValue();

    const filteredDiagnoses = (this.diagnoses || []).filter((d) => {
      const selectedHarvestIds = (filter.harvest || []).map((h: any) => h.value);
      const selectedFarmIds = (filter.farm || []).map((f: any) => f.value);
      const selectedPlotIds = (filter.plot || []).map((p: any) => p.value);
      const selectedProblemIds = (filter.problem || []).map((p: any) => p.value);
      const selectedCultureIds = (filter.culture || []).map((c: any) => c.value);
      const selectedStatus = (filter.status || []).map((s: any) => s.value);

      const matchHarvest =
        !selectedHarvestIds.length || selectedHarvestIds.includes(d.harvest?.id);
      const matchFarm =
        !selectedFarmIds.length || selectedFarmIds.includes(d.farm?.id);
      const matchPlot =
        !selectedPlotIds.length || selectedPlotIds.includes(d.plot?.id);
      const matchProblem =
        !selectedProblemIds.length ||
        selectedProblemIds.includes(d.result?.imageSimilarities?.[0]?.disease?.id);
      const matchCulture =
        !selectedCultureIds.length ||
        selectedCultureIds.includes(d.result?.imageSimilarities?.[0]?.disease?.class);
      const matchStatus =
        !selectedStatus.length || selectedStatus.includes(d.status);

      return (
        matchHarvest &&
        matchFarm &&
        matchPlot &&
        matchProblem &&
        matchCulture &&
        matchStatus
      );
    });


    this.locationShapesFiltered.emit(filteredDiagnoses.map((d) => d.locationShapes).flat());
  }

}
