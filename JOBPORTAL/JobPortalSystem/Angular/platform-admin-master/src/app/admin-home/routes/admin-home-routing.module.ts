import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomeComponent } from '../components/admin-home/admin-home.component';
import { DashboardHomeComponent } from 'src/app/dashboard/components/dashboard-home/dashboard-home.component';



const routes: Routes = [{
  path: 'admin-home', component: AdminHomeComponent,
  children: [
  {
      path: '', loadChildren: () => import('../../dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path: 'dashboard', loadChildren: () => import('../../dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path: 'job-provider', loadChildren: () => import('../../job-providers/job-providers.module').then(m => m.JobProvidersModule)
  },
  {
    path:'new-registration',loadChildren:()=>import('../../new-registrations/new-registrations.module').then(m=>m.NewRegistrationsModule)
  },
  {
    path: "job-seeker", loadChildren: () => import('../../job-seekers/job-seekers.module').then(m => m.JobSeekersModule)
  },
  {
    path:'messages',loadChildren:()=>import('../../messages/messages.module').then(m=>m.MessagesModule)
  },
  {
    path:'profile',loadChildren:()=>import('../../profile/profile.module').then(m=>m.ProfileModule)
  },
  {
    path:'jobs',loadChildren:()=>import('../../jobs/jobs.module').then(m=>m.JobsModule)
  },
  // {
  //   path:'setting',loadChildren:()=>import('../../setting/setting.module').then(m=>m.SettingModule)
  // }
  {
    path:'skill',loadChildren:()=>import('../../skill/skill.module').then(m=>m.SkillModule)
  }
  ]

}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminHomeRoutingModule { }
