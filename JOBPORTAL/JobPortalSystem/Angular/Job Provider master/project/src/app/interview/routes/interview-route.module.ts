import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { InterviewHomeComponent } from '../components/interview-home/interview-home.component';
import { InterviewListComponent } from '../components/interview-list/interview-list.component';
import { InterviewViewComponent } from '../components/interview-view/interview-view.component';

const routes: Routes = [
  {
    path: '',
    component: InterviewHomeComponent,
    children: [
      {
        path: 'list',
        component: InterviewListComponent
      },
      {
        path: 'view',
        component: InterviewViewComponent
      },
      {
        path: 'schedule/:Id',
        component: InterviewViewComponent
      }
    ]
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class InterviewRouteModule { }
