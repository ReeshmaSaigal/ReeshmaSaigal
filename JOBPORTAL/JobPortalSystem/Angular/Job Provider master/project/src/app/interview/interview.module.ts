import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InterviewListComponent } from './components/interview-list/interview-list.component';
import { InterviewViewComponent } from './components/interview-view/interview-view.component';
import { InterviewHomeComponent } from './components/interview-home/interview-home.component';
import { InterviewRouteModule } from './routes/interview-route.module';
import { InterviewHeaderComponent } from './components/interview-header/interview-header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    InterviewListComponent,
    InterviewViewComponent,
    InterviewHomeComponent,
    InterviewHeaderComponent
  ],
  imports: [
    CommonModule,
    InterviewRouteModule,
    FormsModule,
    ReactiveFormsModule 
  ]
})
export class InterviewModule { }
