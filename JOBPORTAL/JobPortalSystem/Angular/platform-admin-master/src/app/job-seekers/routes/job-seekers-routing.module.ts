import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { JobProvidersHomeComponent } from 'src/app/job-providers/components/job-providers-home/job-providers-home.component';
import { JobSeekerListComponent } from '../components/job-seeker-list/job-seeker-list.component';
import { JobSeekerHomeComponent } from '../components/job-seeker-home/job-seeker-home.component';

const routes: Routes = [{
  path:'',component:JobSeekerHomeComponent,
  children:[{path:'list',component:JobSeekerListComponent}]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class JobSeekersRoutingModule { }
