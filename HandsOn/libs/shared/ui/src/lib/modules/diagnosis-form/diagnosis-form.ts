import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
  AbstractControl,
} from '@angular/forms';
import { distinctUntilChanged } from 'rxjs/operators';
import { ButtonComponent } from '../../components/button/button.component';
import { InputComponent } from '../../components/input/input.component';
import {
  SelectComponent,
  SelectOption,
} from '../../components/select/select.component';
import {
  Diagnosis,
  DiagnosisUploadTypeLabels,
  Farm,
  Harvest,
  Plot,
  LocationShapeData,
} from '@farm/core';
import { GetLocationComponent } from '../get-location/get-location.component';

@Component({
  selector: 'lib-diagnosis-form',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputComponent,
    ButtonComponent,
    SelectComponent,
    GetLocationComponent,
  ],
  templateUrl: './diagnosis-form.html',
  styleUrl: './diagnosis-form.css',
})
export class DiagnosisForm implements OnInit, OnChanges {
  @Input() diagnosis: Diagnosis | undefined;
  @Input() farms: Farm[] | undefined;
  @Input() harvests: Harvest[] | undefined;
  @Input() plots: Plot[] | undefined;
  @Input() loading = false;
  @Input() submitLabel = 'Cadastrar';

  @Output() diagnosisSubmit = new EventEmitter<any>();
  @Output() farmSelected = new EventEmitter<string>();

  @ViewChild('locationComp') locationComp!: GetLocationComponent;

  diagnosisForm: FormGroup;
  photoFile: File | null = null;

  uploadTypeOptions: SelectOption[] = Object.entries(
    DiagnosisUploadTypeLabels,
  ).map(([value, label]) => ({ value, label }));

  constructor() {
    this.diagnosisForm = new FormGroup({
      id: new FormControl('', { validators: [], updateOn: 'blur' }),
      farm: new FormControl('', {
        validators: [Validators.required],
        updateOn: 'blur',
      }),
      harvest: new FormControl('', {
        validators: [Validators.required],
        updateOn: 'blur',
      }),
      plot: new FormControl('', {
        validators: [Validators.required],
        updateOn: 'blur',
      }),
      uploadType: new FormControl('', {
        validators: [Validators.required],
        updateOn: 'blur',
      }),
      date: new FormControl(new Date(), {
        validators: [Validators.required, this.dateNotInFutureValidator()],
        updateOn: 'blur',
      }),
      status: new FormControl('', { validators: [], updateOn: 'blur' }),
      result: new FormControl('', { validators: [], updateOn: 'blur' }),
      latitude: new FormControl(null, { validators: [], updateOn: 'blur' }),
      longitude: new FormControl(null, { validators: [], updateOn: 'blur' }),
      locationShapes: new FormControl([], { validators: [], updateOn: 'blur' }),
    });
  }

  ngOnInit(): void {
    if (this.diagnosis) {
      this.updateDiagnosisData();
    }

    this.farm.valueChanges.pipe(distinctUntilChanged()).subscribe((farm) => {
      if (farm) {
        this.onFarmSelected(farm.value);
      }
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (
      changes['diagnosis'] &&
      changes['diagnosis'].currentValue !== changes['diagnosis'].previousValue
    ) {
      this.updateDiagnosisData();
    }

    if (changes['loading']) {
      if (this.loading) {
        this.diagnosisForm.disable();
      } else {
        this.diagnosisForm.enable();
      }
    }
  }

  get farm(): FormControl {
    return this.diagnosisForm.get('farm') as FormControl;
  }
  get harvest(): FormControl {
    return this.diagnosisForm.get('harvest') as FormControl;
  }
  get plot(): FormControl {
    return this.diagnosisForm.get('plot') as FormControl;
  }
  get uploadType(): FormControl {
    return this.diagnosisForm.get('uploadType') as FormControl;
  }
  get date(): FormControl {
    return this.diagnosisForm.get('date') as FormControl;
  }
  get status(): FormControl {
    return this.diagnosisForm.get('status') as FormControl;
  }
  get result(): FormControl {
    return this.diagnosisForm.get('result') as FormControl;
  }
  get latitude(): FormControl {
    return this.diagnosisForm.get('latitude') as FormControl;
  }
  get longitude(): FormControl {
    return this.diagnosisForm.get('longitude') as FormControl;
  }
  get farmOptions(): SelectOption[] {
    return (
      this.farms?.map((farm) => ({
        value: farm.id,
        label: farm.name,
      })) || []
    );
  }
  get harvestOptions(): SelectOption[] {
    return (
      this.harvests?.map((h) => ({
        value: h.id,
        label: h.name,
      })) ?? []
    );
  }
  get plotOptions(): SelectOption[] {
    return (
      this.plots?.map((p) => ({
        value: p.id,
        label: p.name,
      })) ?? []
    );
  }
  get locationShapes(): FormControl {
    return this.diagnosisForm.get('locationShapes') as FormControl;
  }

  onFarmSelected(farm: string): void {
    this.farmSelected.emit(farm);

    this.diagnosisForm.patchValue({
      harvest: null,
      plot: null,
    });
  }

  updateDiagnosisData(): void {
    if (!this.diagnosis) return;

    const selectedUploadType = this.uploadTypeOptions.find(
      (option) => this.diagnosis && option.value === this.diagnosis.uploadType,
    );

    const selectedFarm = this.farmOptions.find(
      (f) => this.diagnosis && f.value === this.diagnosis.farm.id,
    );

    const selectedHarvest = {
      value: this.diagnosis?.harvest.id,
      label: this.diagnosis?.harvest.name,
    };

    const selectedPlot = {
      value: this.diagnosis?.plot.id,
      label: this.diagnosis?.plot.name,
    };

    const formattedDate = this.formatDateToInput(this.diagnosis.date);

    this.diagnosisForm.patchValue({
      farm: selectedFarm ?? '',
      harvest: selectedHarvest ?? '',
      plot: selectedPlot ?? '',
      uploadType: selectedUploadType ?? '',
      date: formattedDate,
      latitude: this.latitude ?? '',
      longitude: this.longitude ?? '',
      locationShapes: this.diagnosis.locationShapes || [],
    });

  }

  onSubmit(): void {
    if (this.diagnosisForm.invalid) {
      this.diagnosisForm.markAllAsTouched();
      return;
    }

    const formData = {
      id: this.diagnosis?.id || '',
      userId: this.diagnosis?.userId || '',
      farmId: this.farm.value.value,
      harvestId: this.harvest.value.value,
      plotId: this.plot.value.value,
      uploadType: this.uploadType.value.value,
      photoFile: this.photoFile || null,
      date: this.date.value,
      status: this.status.value,
      result: this.result.value,
      createdAt: this.diagnosis?.createdAt || new Date(),
      updatedAt: new Date(),
      locationShapes: this.locationShapes.value,
    };

    this.diagnosisSubmit.emit(formData);
  }

  onFileSelected(file: File | null) {
    this.photoFile = file;
  }

  private formatDateToInput(date: string | Date): string {
    const d = new Date(date);
    const year = d.getFullYear();
    const month = String(d.getMonth() + 1).padStart(2, '0');
    const day = String(d.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
  }

  dateNotInFutureValidator() {
    return (control: AbstractControl) => {
      const today = new Date();
      const value = new Date(control.value);
      if (value > today) {
        return { futureDate: true };
      }
      return null;
    };
  }

  onLocationDetected(location: { latitude: number; longitude: number }) {
    this.latitude.setValue(location.latitude);
    this.longitude.setValue(location.longitude);
  }

  markFromFields() {
    const lat = parseFloat(this.latitude.value);
    const lng = parseFloat(this.longitude.value);
    if (!isNaN(lat) && !isNaN(lng)) {
      this.locationComp.placeOrMoveMarker(lat, lng, true);
    }
  }

  onShapesDrawn(shapes: LocationShapeData[]) {
    const shapesControl = this.diagnosisForm.get('locationShapes');
    if (shapesControl) {
      shapesControl.setValue(shapes);
      shapesControl.markAsDirty();
      shapesControl.updateValueAndValidity();
    }
  }
}
