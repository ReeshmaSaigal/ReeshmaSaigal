import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageRouteModule } from './routes/message-route.module';
import { MessageHomeComponent } from './components/message-home/message-home.component';
import { MessageListComponent } from './components/message-list/message-list.component';
import { MessageBoxComponent } from './components/message-box/message-box.component';



@NgModule({
  declarations: [
    MessageHomeComponent,
    MessageListComponent,
    MessageBoxComponent
  ],
  imports: [
    CommonModule,
    MessageRouteModule
  ]
})
export class MessageModule { }
