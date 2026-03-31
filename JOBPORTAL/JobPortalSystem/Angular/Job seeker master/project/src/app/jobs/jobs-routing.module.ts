import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobsComponent } from './jobs.component';
import { AlljobsListComponent } from './components/alljobs-list/alljobs-list.component';
import { SharedModule } from '../shared/shared.module';
import { AlljobsNavbarComponent } from './components/alljobs-navbar/alljobs-navbar.component';
import { AppliedJobsComponent } from './components/applied-jobs/applied-jobs.component';
import { AddResumeComponent } from '../profile/components/add-resume/add-resume.component';

const routes: Routes = [
  // {
  //   path: 'jobs',
  //   component: JobsComponent,
  //   children: [
  //     { path: 'findAllJobs',component:AlljobsListComponent},
  //     { path: 'sidebar', loadChildren: () => import('../shared/shared.module').then(m => m.SharedModule) },
  //      {path:'',loadChildren:()=>import('../jobseeker-main/jobseeker-main.module').then(m=>m.JobseekerMainModule)}
  //   ]
  // }

  {path:'findAllJobs',component:AlljobsListComponent},
  {path:'appliedJobs',component:AppliedJobsComponent},
  {path:'upload-resume',component:AddResumeComponent}
 
];

@NgModule({
  imports: [RouterModule.forChild(routes),
  
  SharedModule],
  exports: [RouterModule]
})
export class JobsRoutingModule { }
