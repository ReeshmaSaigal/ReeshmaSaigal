import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileHomeComponent } from './components/profile-home/profile-home.component';
import { ProfileUpdateComponent } from './components/profile-update/profile-update.component';
import { ProfileRoutingModule } from './routes/profile-routing.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    ProfileHomeComponent,
    ProfileUpdateComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ProfileRoutingModule
  ]
})
export class ProfileModule { }
