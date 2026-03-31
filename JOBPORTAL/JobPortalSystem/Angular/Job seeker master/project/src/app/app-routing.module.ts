import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',loadChildren:()=>import('./home/home.module').then(m=>m.HomeModule)
  },
  {path:'',loadChildren:()=>import('./jobseeker-main/jobseeker-main.module').then(m=>m.JobseekerMainModule)},
  // {path:'',loadChildren:()=>import('./jobseeker-common/common.module').then(m=>m.CommonModule)}
  {path:'',loadChildren:()=>import('./auth/auth.module').then(m=>m.AuthModule)},
  // {path:'',loadChildren:()=>import('./profile/profile.module').then(m=>m.ProfileModule)},
  // {path:'',loadChildren:()=>import('./messages/messages.module').then(m=>m.MessagesModule)},
   {path:'',loadChildren:()=>import('./jobs/jobs.module').then(m=>m.JobsModule)},
   { path: 'jobProvider-dashboard', redirectTo: 'http://localhost:61701/dashboard', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
