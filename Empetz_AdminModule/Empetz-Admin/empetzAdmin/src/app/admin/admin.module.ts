import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminHomeComponent } from './components/admin-home/admin-home.component';
import { DashboardModule } from '../dashboard/dashboard.module';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    AdminHomeComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    DashboardModule,
    SharedModule
  ]
})
export class AdminModule { }
