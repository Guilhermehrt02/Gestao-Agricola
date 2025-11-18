/* eslint-disable @angular-eslint/prefer-inject */
import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { CardComponent } from '../../components/card/card.component';
import { InputComponent } from '../../components/input/input.component';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'lib-edit-element-dialog.component',
  imports: [CommonModule, FormsModule, CardComponent],
  template: `
    <lib-card>
      <div class="flex flex-col gap-4">

        <div class="flex flex-col gap-1">
          <label for="label" class="text-sm font-medium text-gray-200">
            Nome (Label):
          </label>

          <input 
            id="label" 
            pInputText 
            [(ngModel)]="value"
            class="w-full"
            placeholder="Digite o nome..."
          />
        </div>

        <div class="flex justify-end gap-3 pt-4 border-t border-gray-700">
          <button 
            pButton 
            (click)="cancel()"
            class="p-button-text p-button-sm">
            <i class="pi pi-times mr-2"></i>
          </button>

          <button 
            pButton 
            label="Salvar"
            (click)="save()"
            class="p-button-sm"
            [disabled]="value.trim() === ''">
            <i class="pi pi-check mr-2"></i>
          </button>
        </div>

      </div>
    </lib-card>
  `
})
export class EditElementDialogComponent {
  value = '';

  constructor(
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig
  ) {
    this.value = config.data?.label ?? '';
  }

  save() {
    this.ref.close(this.value);
  }

  cancel() {
    this.ref.close(null);
  }
}
