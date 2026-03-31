import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:'',loadChildren:()=>import('./auth/auth.module').then(m=>m.AuthModule),
  },
  {
    path:'',loadChildren:()=>import('./admin-home/admin-home.module').then(m=>m.AdminHomeModule)
  },
  // {
  //   path:'',loadChildren:()=>import('./jobs/jobs.module').then(m=>m.JobsModule)
  // },
  // {
  //   path:'',loadChildren:()=>import('./skill/skill.module').then(m=>m.SkillModule)
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
