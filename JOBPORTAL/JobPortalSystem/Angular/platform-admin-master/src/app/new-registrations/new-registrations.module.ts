import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewRegistrationComponent } from './components/new-registration/new-registration.component';
import { NewRegistrationHomeComponent } from './components/new-registration-home/new-registration-home.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NewRegistrationRoutingModule } from './routes/new-registration-routing.module';
import { RegistrationService } from './services/registration.service';



@NgModule({
  declarations: [
    NewRegistrationComponent,
    NewRegistrationHomeComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    NewRegistrationRoutingModule,
    HttpClientModule
  ],
  providers: [RegistrationService],
})
export class NewRegistrationsModule { }
