import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from './profile.component';
import { ProfileInfoComponent } from './components/profile-info/profile-info.component';
import { AddResumeComponent } from './components/add-resume/add-resume.component';
import { AppliedJobsComponent } from '../jobs/components/applied-jobs/applied-jobs.component';
import { NodeWithI18n } from '@angular/compiler';
import { AddNewProfileComponent } from './components/add-new-profile/add-new-profile.component';
import { AddProfileComponent } from './components/add-profile/add-profile.component';

const routes: Routes = [
  {
    path:'profile',component:AddNewProfileComponent
  },
  {
    path:'profile-info/:id',component:ProfileInfoComponent
  },
  {
    path:'add-profile',component: AddProfileComponent
  },
  {
    path:'upload-resume',component:AddResumeComponent
  },
  {
    path:'appliedJobs',component:AppliedJobsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileRoutingModule { }
