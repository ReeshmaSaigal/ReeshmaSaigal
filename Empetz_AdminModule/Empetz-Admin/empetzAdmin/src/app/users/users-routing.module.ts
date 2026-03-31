import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserdetailsComponent } from './components/userdetails/userdetails.component';
import { BlockUsersComponent } from './components/block-users/block-users.component';

const routes: Routes = [
  {
    path:'user-details',component:UserdetailsComponent
  },
  {
    path:'block-user',component:BlockUsersComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
