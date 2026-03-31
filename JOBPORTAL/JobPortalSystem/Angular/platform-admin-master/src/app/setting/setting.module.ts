import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SettingRoutingModule } from './routes/setting-routing.module';
import { SettingHomeComponent } from './components/setting-home/setting-home.component';
import { SettingUpdateComponent } from './components/setting-update/setting-update.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    SettingHomeComponent,
    SettingUpdateComponent
  ],
  imports: [
    CommonModule,
    SettingRoutingModule,
    ReactiveFormsModule
  ]

})
export class SettingModule { }
