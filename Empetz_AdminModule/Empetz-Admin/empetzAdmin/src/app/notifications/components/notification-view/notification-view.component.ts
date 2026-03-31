import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../../service/notification.service';

@Component({
  selector: 'app-notification-view',
  templateUrl: './notification-view.component.html',
  styleUrls: ['./notification-view.component.css']
})
export class NotificationViewComponent implements OnInit {
  notifications: any[]=[];
 
constructor(private notificatioService:NotificationService){}
  ngOnInit(): void {
    this.loadNotifications();
  }
  
  loadNotifications(): void {
    
    this.notifications =this.notificatioService.getNotification()
  }
}
