import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UserdetailsComponent } from './components/userdetails/userdetails.component';
import { FormsModule } from '@angular/forms';
import { BlockUsersComponent } from './components/block-users/block-users.component';


@NgModule({
  declarations: [
    UserdetailsComponent,
    BlockUsersComponent
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    FormsModule
  ]
})
export class UsersModule { }
