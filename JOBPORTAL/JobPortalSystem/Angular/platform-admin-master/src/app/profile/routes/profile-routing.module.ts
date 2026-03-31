import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProfileHomeComponent } from '../components/profile-home/profile-home.component';
import { ProfileUpdateComponent } from '../components/profile-update/profile-update.component';

const routes: Routes = [{
  path:'',component:ProfileHomeComponent,
  children:[
    {
      path:'update',component:ProfileUpdateComponent
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileRoutingModule { }
