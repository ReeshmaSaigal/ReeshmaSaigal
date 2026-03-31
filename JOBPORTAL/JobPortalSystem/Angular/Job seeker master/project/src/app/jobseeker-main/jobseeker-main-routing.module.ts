import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobseekerMainComponent } from './jobseeker-main.component';

const routes: Routes = [
  {
    path: 'jobseeker-home',
    component: JobseekerMainComponent,
    children: [
      { path: '',loadChildren:()=>import('../jobs/jobs.module').then(m=>m.JobsModule)},
      { path: 'sidebar', loadChildren: () => import('../shared/shared.module').then(m => m.SharedModule) },
      {path:'',loadChildren:()=>import('../profile/profile.module').then(m=>m.ProfileModule)},
      {path:'',loadChildren:()=>import('../settings/settings.module').then(m=>m.SettingsModule)},
      {path:'',loadChildren:()=>import('../messages/messages.module').then(m=>m.MessagesModule)}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class 
JobseekerMainRoutingModule { }
