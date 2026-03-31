import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashbordComponent } from './components/dashbord/dashbord.component';
import { DashboardHomeComponent } from './components/dashboard-home/dashboard-home.component';


@NgModule({
  declarations: [
    DashbordComponent,
    DashboardHomeComponent,

  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
  
  ]
})
export class DashboardModule { }
