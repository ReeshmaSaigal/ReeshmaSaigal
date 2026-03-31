import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JobHomeComponent } from './components/job-home/job-home.component';
import { JobListComponent } from './components/job-list/job-list.component';
import { RouterModule } from '@angular/router';
import { JobsRoutingModule } from './routes/jobs-routing.module';
import { SearchbarComponent } from '../shared/searchbar/searchbar.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    JobHomeComponent,
    JobListComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    JobsRoutingModule,
    SharedModule,
    FormsModule
  ]
})
export class JobsModule { }
