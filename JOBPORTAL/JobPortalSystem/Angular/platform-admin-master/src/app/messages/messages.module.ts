import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageHomeComponent } from './components/message-home/message-home.component';
import { MessageListComponent } from './components/message-list/message-list.component';
import { MessagesRoutingModule } from './routes/messages-routing.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    MessageHomeComponent,
    MessageListComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MessagesRoutingModule
  ]
})
export class MessagesModule { }
