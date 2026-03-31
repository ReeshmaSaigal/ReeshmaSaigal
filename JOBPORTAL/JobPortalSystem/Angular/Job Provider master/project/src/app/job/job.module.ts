import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JobListComponent } from './components/job-list/job-list.component';
import { JobAddComponent } from './components/job-add/job-add.component';
import { JobViewComponent } from './components/job-view/job-view.component';
import { JobUpdateComponent } from './components/job-update/job-update.component';
import { JobHomeComponent } from './components/job-home/job-home.component';
import { JobRouteModule } from './routes/job-route.module';
import { JobHeaderComponent } from './components/job-header/job-header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    JobListComponent,
    JobAddComponent,
    JobViewComponent,
    JobUpdateComponent,
    JobHomeComponent,
    JobHeaderComponent
  ],
  imports: [
    CommonModule,
    JobRouteModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class JobModule { }
