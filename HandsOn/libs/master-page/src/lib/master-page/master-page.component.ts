/* eslint-disable @angular-eslint/prefer-inject */
import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from '@farm/header';
import { SidebarComponent } from '@farm/sidebar';
import { MainComponent } from '@farm/main';
import { FooterComponent } from '@farm/footer';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { MenuItem } from 'primeng/api';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { UserFacade } from '@farm/core';
import { SpinnerComponent } from '@farm/ui';

@Component({
  selector: 'lib-master-page',
  imports: [
    CommonModule,
    RouterModule,
    HeaderComponent,
    SidebarComponent,
    MainComponent,
    FooterComponent,
    TieredMenuModule,
    ProgressSpinnerModule,
    SpinnerComponent,
  ],
  templateUrl: './master-page.component.html',
  styleUrl: './master-page.component.css',
})
export class MasterPageComponent implements OnInit, OnDestroy {
  menuItems: MenuItem[] = [];
  menuVisible = false;
  loading = true;

  constructor(private userFacade: UserFacade) {}

  ngOnInit(): void {
    this.userFacade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.userFacade.me().subscribe((user) => {
      this.loadMenu(user.role as string);
    });
  }

  ngOnDestroy(): void {
    this.userFacade.reset();
  }

  loadMenu(userRole: string) {
    const menuItems: MenuItem[] = [];

    menuItems.push({
      label: 'Diagnósticos',
      icon: 'pi pi-fw pi-search',
      styleClass: 'cursor-pointer',
      items: [
        {
          label: 'Cadastrar',
          icon: 'pi pi-fw pi-plus',
          routerLink: '/app/diagnoses/diagnosis/create',
        },
        {
          label: 'Gerenciar',
          icon: 'pi pi-fw pi-list',
          routerLink: '/app/diagnoses/diagnosis',
        },
      ],
    });

    menuItems.push({
      label: 'finance',
      icon: 'pi pi-fw pi-money-bill',
      styleClass: 'cursor-pointer',
      items: [
        {
          label: 'Relatórios',
          icon: 'pi pi-fw pi-chart-line',
          routerLink: '/app/finance/reports',
        },
        {
          label: 'Despesas',
          icon: 'pi pi-fw pi-arrow-up-right',
          routerLink: '/app/finance/expenses',
        },
        {
          label: 'Receitas',
          icon: 'pi pi-fw pi-arrow-down-left',
          routerLink: '/app/finance/revenues',
        },
      ],
    });

    if (userRole === 'Admin') {
      menuItems.push({
        label: 'Usuários',
        icon: 'pi pi-fw pi-users',
        styleClass: 'cursor-pointer',
        items: [
          {
            label: 'Cadastrar',
            icon: 'pi pi-fw pi-user-plus',
            routerLink: '/app/users/create',
          },
          {
            label: 'Gerenciar',
            icon: 'pi pi-fw pi-users',
            routerLink: '/app/users',
          },
        ],
      });
    }

    this.menuItems = menuItems;
  }
}
