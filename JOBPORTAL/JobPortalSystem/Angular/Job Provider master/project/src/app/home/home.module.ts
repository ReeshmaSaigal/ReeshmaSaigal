import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { HomeRouteModule } from './routes/home-route.module';
import { SharedModule } from '../shared/shared.module';
import { DashboardModule } from '../dashboard/dashboard.module';
import { ApplicationModule } from '../application/application.module';
import { JobModule } from '../job/job.module';



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    HomeRouteModule,
    SharedModule,
    DashboardModule,
    ApplicationModule,
    JobModule
  ]
})
export class HomeModule { }
