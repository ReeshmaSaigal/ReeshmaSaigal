import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SettingsHomeComponent } from './components/settings-home/settings-home.component';
import { AccountComponent } from './components/account/account.component';
import { SettingsRoutingModule } from './routes/settings-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CompanyProfileComponent } from './components/company-profile/company-profile.component';
import { ProviderProfileComponent } from './components/provider-profile/provider-profile.component';
import { ProviderProfessionalInfoComponent } from './components/provider-professional-info/provider-professional-info.component';



@NgModule({
  declarations: [
    SettingsHomeComponent,
    AccountComponent,
    CompanyProfileComponent,
    ProviderProfileComponent,
    ProviderProfessionalInfoComponent
   
  ],
  imports: [
    CommonModule,
    SettingsRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class SettingsModule { }
