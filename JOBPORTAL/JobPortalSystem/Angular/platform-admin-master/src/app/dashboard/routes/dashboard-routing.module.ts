import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardHomeComponent } from '../components/dashboard-home/dashboard-home.component';
import { DashboardComponent } from '../components/dashboard/dashboard.component';


const routes: Routes = [{
  path:'',component:DashboardHomeComponent

}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
