import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { JobHomeComponent } from '../components/job-home/job-home.component';
import { JobListComponent } from '../components/job-list/job-list.component';
import { JobAddComponent } from '../components/job-add/job-add.component';
import { JobViewComponent } from '../components/job-view/job-view.component';
import { JobUpdateComponent } from '../components/job-update/job-update.component';

const routes: Routes = [
  {
    path: '',
    component: JobHomeComponent,
    children: [
      {
        path: 'list',
        component: JobListComponent
      },
      {
        path: 'add',
        component: JobAddComponent
      },
      {
        path: 'view',
        component: JobViewComponent
      },
      {
        path: 'update/:id',
        component: JobUpdateComponent
      }
    ]
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class JobRouteModule { }
