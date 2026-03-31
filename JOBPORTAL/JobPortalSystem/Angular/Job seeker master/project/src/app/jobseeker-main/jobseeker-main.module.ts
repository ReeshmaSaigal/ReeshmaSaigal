import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JobseekerMainRoutingModule } from './jobseeker-main-routing.module';
import { JobseekerMainComponent } from './jobseeker-main.component';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
// import { ProfileModule } from '../profile/profile.module';


@NgModule({
  declarations: [
    JobseekerMainComponent
  ],
  imports: [
    CommonModule,
    JobseekerMainRoutingModule,
    SharedModule
    // ProfileModule
  ]
})
export class JobseekerMainModule { }
