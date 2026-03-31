import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JobsRoutingModule } from './jobs-routing.module';
import { JobsComponent } from './jobs.component';
import { SharedModule } from "../shared/shared.module";
import { AlljobsNavbarComponent } from './components/alljobs-navbar/alljobs-navbar.component';
import { AlljobsListComponent } from './components/alljobs-list/alljobs-list.component';
import { AppliedJobsComponent } from './components/applied-jobs/applied-jobs.component';
import { AllJobsDetailComponent } from './components/all-jobs-detail/all-jobs-detail.component';
import { ConfirmBoxConfigModule, NgxAwesomePopupModule } from '@costlydeveloper/ngx-awesome-popup';
import { SavedJobsComponent } from './components/saved-jobs/saved-jobs.component';


@NgModule({
    declarations: [
        JobsComponent,
        AlljobsNavbarComponent,
        AlljobsListComponent,
        AppliedJobsComponent,
        AllJobsDetailComponent,
        SavedJobsComponent
    ],
    imports: [
        CommonModule,
        JobsRoutingModule,
        SharedModule,
      
    ]
})
export class JobsModule { }
