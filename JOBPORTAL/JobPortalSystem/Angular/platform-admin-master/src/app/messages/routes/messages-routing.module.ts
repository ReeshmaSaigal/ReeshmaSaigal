import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { MessageHomeComponent } from '../components/message-home/message-home.component';
import { MessageListComponent } from '../components/message-list/message-list.component';

const routes: Routes = [{
  path:'',component:MessageHomeComponent,
  children:[
    {
      path:'list',component:MessageListComponent
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MessagesRoutingModule { }
