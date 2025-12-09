/* eslint-disable @angular-eslint/prefer-inject */
import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { CardComponent } from '../../components/card/card.component';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'lib-edit-element-dialog.component',
  imports: [CommonModule, FormsModule, CardComponent],
  template: `
    <lib-card>
      <div class="flex flex-col gap-4">

        <!-- TÍTULO OPCIONAL DIFERENTE -->
        <h2 class="text-lg font-semibold text-gray-100">
          {{ mode === 'create' ? 'Criar Novo Elemento' : 'Editar Elemento' }}
        </h2>

        <!-- CAMPOS DIFERENTES POR MODO -->
        <ng-container [ngSwitch]="mode">

          <!-- Modo editar -->
          <ng-container *ngSwitchCase="'edit'">
            <div class="flex flex-col gap-1">
              <label for="label">Nome</label>
              <input id="label" pInputText [(ngModel)]="value" placeholder="Digite o nome..." />
            </div>
          </ng-container>

          <!-- Modo criar -->
          <ng-container *ngSwitchCase="'create'">
            <div class="flex flex-col gap-1">
              <label for="label">Nome do novo elemento:</label>
              <input id="label" pInputText [(ngModel)]="value" placeholder="Ex: Novo talhão" />
            </div>

            <!-- Se quiser adicionar novos campos para criação -->
            <!-- <div class="flex flex-col gap-1">
              <label>Tipo:</label>
              <select [(ngModel)]="type"> ... </select>
            </div> -->
          </ng-container>

        </ng-container>

        <!-- Botões -->
        <div class="flex justify-end gap-3 pt-4 border-t border-gray-700">
          <button pButton class="p-button-text p-button-sm" (click)="cancel()">
            <i class="pi pi-times mr-2"></i>
          </button>

          <button pButton label="Salvar" (click)="save()"
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
  mode: 'edit' | 'create' = 'edit';

  constructor(
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig
  ) {
    this.mode = config.data?.mode ?? 'edit';
    this.value = config.data?.label ?? '';
  }

  save() {
    this.ref.close({ value: this.value, mode: this.mode });
  }

  cancel() {
    this.ref.close(null);
  }
}
