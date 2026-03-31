import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplicationListComponent } from './components/application-list/application-list.component';
import { ApplicationViewComponent } from './components/application-view/application-view.component';
import { ApplicationRouteModule } from './routes/application-route.module';
import { ApplicationHomeComponent } from './components/application-home/application-home.component';
import { ApplicationSeekerProfessionalInfoComponent } from './components/application-seeker-professional-info/application-seeker-professional-info.component';



@NgModule({
  declarations: [
    ApplicationListComponent,
    ApplicationViewComponent,
    ApplicationHomeComponent,
    ApplicationSeekerProfessionalInfoComponent
  ],
  imports: [
    CommonModule,
    ApplicationRouteModule
  ]
})
export class ApplicationModule { }
