import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminHomeComponent } from './components/admin-home/admin-home.component';
import { AdminHomeRoutingModule } from './routes/admin-home-routing.module';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { SidebarComponent } from '../shared/components/sidebar/sidebar.component';
import { HeaderComponent } from '../shared/header/header.component';

@NgModule({
  declarations: [
    AdminHomeComponent
 
  ],
  imports: [
    CommonModule,
    RouterModule,
    AdminHomeRoutingModule,
    SharedModule
  ]
})
export class AdminHomeModule { }
