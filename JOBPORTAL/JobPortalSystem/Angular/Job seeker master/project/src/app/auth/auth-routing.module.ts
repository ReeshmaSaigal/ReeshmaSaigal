import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterationComponent } from './components/registeration/registeration.component';
import { SetPasswordComponent } from './components/set-password/set-password.component';

const routes: Routes = [{
  path:'login',component:LoginComponent
}
,
{path:'signup',component:RegisterationComponent},
{path:'set-password',component:SetPasswordComponent}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
