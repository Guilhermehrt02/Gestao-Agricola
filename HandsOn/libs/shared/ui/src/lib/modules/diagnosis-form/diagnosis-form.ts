import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
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
import { ButtonComponent } from '../../components/button/button.component';
import { InputComponent } from '../../components/input/input.component';
import {
  SelectComponent,
  SelectOption,
} from '../../components/select/select.component';
import { Diagnosis, DiagnosisUploadTypeLabels } from '@farm/core';
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
  @Input() loading = false;
  @Input() submitLabel = 'Cadastrar';

  @Output() diagnosisSubmit = new EventEmitter<any>();

  diagnosisForm: FormGroup;
  photoFile: File | null = null;

  uploadTypeOptions: SelectOption[] = Object.entries(
    DiagnosisUploadTypeLabels,
  ).map(([value, label]) => ({ value, label }));

  constructor() {
    this.diagnosisForm = new FormGroup({
      id: new FormControl('', { validators: [], updateOn: 'blur' }),
      farmId: new FormControl('', {
        validators: [Validators.required],
        updateOn: 'blur',
      }),
      harvestId: new FormControl('', {
        validators: [Validators.required],
        updateOn: 'blur',
      }),
      plotId: new FormControl('', {
        validators: [Validators.required],
        updateOn: 'blur',
      }),
      uploadType: new FormControl('', {
        validators: [Validators.required],
        updateOn: 'blur',
      }),
      photoUrl: new FormControl('', {
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
    });
  }

  ngOnInit(): void {
    if (this.diagnosis) {
      this.updateDiagnosisData();
    }
  }

  ngOnChanges(): void {
    if (this.diagnosis) {
      this.updateDiagnosisData();
    }

    if (this.loading) {
      this.diagnosisForm.disable();
    } else {
      this.diagnosisForm.enable();
    }
  }

  get farmId(): FormControl {
    return this.diagnosisForm.get('farmId') as FormControl;
  }
  get harvestId(): FormControl {
    return this.diagnosisForm.get('harvestId') as FormControl;
  }
  get plotId(): FormControl {
    return this.diagnosisForm.get('plotId') as FormControl;
  }
  get uploadType(): FormControl {
    return this.diagnosisForm.get('uploadType') as FormControl;
  }
  get photoUrl(): FormControl {
    return this.diagnosisForm.get('photoUrl') as FormControl;
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

  updateDiagnosisData(): void {
    if (!this.diagnosis) return;

    const selectedUploadType = this.uploadTypeOptions.find(
      (option) => this.diagnosis && option.value === this.diagnosis.uploadType,
    );

    const formattedDate = this.formatDateToInput(this.diagnosis.date);

    this.diagnosisForm.patchValue({
      farmId: this.diagnosis.farmId ?? '',
      harvestId: this.diagnosis.harvestId ?? '',
      plotId: this.diagnosis.plotId ?? '',
      uploadType: selectedUploadType ?? '',
      photoUrl: this.diagnosis.photoUrl ?? '',
      date: formattedDate,
      latitude: this.diagnosis.latitude ?? '',
      longitude: this.diagnosis.longitude ?? '',
    });
  }

  onSubmit(): void {
    if (this.diagnosisForm.invalid) {
      return this.diagnosisForm.markAllAsTouched();
    }

    const formData = {
      id: this.diagnosis?.id || '',
      userId: this.diagnosis?.userId || '',
      farmId: this.farmId.value,
      harvestId: this.harvestId.value,
      plotId: this.plotId.value,
      uploadType: this.uploadType.value.value,
      photoUrl: this.photoUrl.value,
      date: this.date.value,
      status: this.status.value,
      result: this.result.value,
      latitude: this.latitude.value,
      longitude: this.longitude.value,
      createdAt: this.diagnosis?.createdAt || new Date(),
      updatedAt: new Date(),
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
}
