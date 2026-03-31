import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { JobHomeComponent } from '../components/job-home/job-home.component';
import { JobListComponent } from '../components/job-list/job-list.component';

const routes: Routes = [{
  path:'',component:JobHomeComponent,
  children:[
    {
      path:'list',component:JobListComponent
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class JobsRoutingModule { }
