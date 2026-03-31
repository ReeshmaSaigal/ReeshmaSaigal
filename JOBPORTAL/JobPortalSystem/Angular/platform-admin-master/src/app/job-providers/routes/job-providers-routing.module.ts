import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JobProvidersHomeComponent } from '../components/job-providers-home/job-providers-home.component';
import { RouterModule, Routes } from '@angular/router';
import { ProvidersListComponent } from '../components/providers-list/providers-list.component';

const routes: Routes = [{
  path:'',component:JobProvidersHomeComponent,
  children:[
    {
      path:'list',component:ProvidersListComponent
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})


export class JobProvidersRoutingModule { }
