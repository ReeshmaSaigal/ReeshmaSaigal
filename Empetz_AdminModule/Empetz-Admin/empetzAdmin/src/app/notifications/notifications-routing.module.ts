import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotificationViewComponent } from './components/notification-view/notification-view.component';

const routes: Routes = [
  {path:'notification-view',component:NotificationViewComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NotificationsRoutingModule { }
