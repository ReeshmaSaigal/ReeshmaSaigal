import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../components/home/home.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('../../dashboard/dashboard.module').then(m => m.DashboardModule)
      },
      {
        path: 'dashboard',
        loadChildren: () => import('../../dashboard/dashboard.module').then(m => m.DashboardModule)
      },
      {
        path: 'application',
        loadChildren: () => import('../../application/application.module').then(m => m.ApplicationModule)
      },
      {
        path: 'jobs',
        loadChildren: () => import('../../job/job.module').then(m => m.JobModule)
      },
      {
        path: 'interview',
        loadChildren: () => import('../../interview/interview.module').then(m => m.InterviewModule)
      },
      {
        path: 'messages',
        loadChildren: () => import('../../message/message.module').then(m => m.MessageModule)
      },
      {
        path:'settings',
        loadChildren:()=>import('../../settings/settings.module').then(m => m.SettingsModule)
      },
      {
        path:'company-member',
        loadChildren:()=>import('../../company-member/company-member.module').then(m=>m.CompanyMemberModule)
      },
      {
        path:'company',
        loadChildren:()=>import('../../company/company.module').then((m=>m.CompanyModule))
      }
    ]
  }
]


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class HomeRouteModule { }
