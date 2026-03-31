import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AuthHomeComponent } from './components/auth-home/auth-home.component';


const routes: Routes = [
  { path: '', component: LoginComponent ,
    // children:[
    //   { path: '', component: LoginComponent },
    //   { path: 'login', component: LoginComponent }
    // ]
  },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
