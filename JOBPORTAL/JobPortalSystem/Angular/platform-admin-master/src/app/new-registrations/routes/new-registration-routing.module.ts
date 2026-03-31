import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { NewRegistrationHomeComponent } from '../components/new-registration-home/new-registration-home.component';
import { NewRegistrationComponent } from '../components/new-registration/new-registration.component';


const routes: Routes = [{
  path:'',component:NewRegistrationHomeComponent,
  children:[
    {
      path:'registrations',component:NewRegistrationComponent
    }
  ]

}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NewRegistrationRoutingModule { }
