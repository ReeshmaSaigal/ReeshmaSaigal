import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SettingsHomeComponent } from '../components/settings-home/settings-home.component';
import { AccountComponent } from '../components/account/account.component';
import { CompanyProfileComponent } from '../components/company-profile/company-profile.component';
import { ProviderProfileComponent } from '../components/provider-profile/provider-profile.component';

const routes: Routes = [
  {
    path: '', component: SettingsHomeComponent,
    children: [
      { path: 'account', component: AccountComponent },
      { path: 'company', component: CompanyProfileComponent },
      { path: 'provider',component:ProviderProfileComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule { }
