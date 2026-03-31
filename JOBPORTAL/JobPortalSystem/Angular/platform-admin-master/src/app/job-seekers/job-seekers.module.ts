import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JobSeekerHomeComponent } from './components/job-seeker-home/job-seeker-home.component';
import { JobSeekerListComponent } from './components/job-seeker-list/job-seeker-list.component';
import { JobSeekersRoutingModule } from './routes/job-seekers-routing.module';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    JobSeekerHomeComponent,
    JobSeekerListComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    JobSeekersRoutingModule,
    HttpClientModule,
    SharedModule
  ]
})
export class JobSeekersModule { }
