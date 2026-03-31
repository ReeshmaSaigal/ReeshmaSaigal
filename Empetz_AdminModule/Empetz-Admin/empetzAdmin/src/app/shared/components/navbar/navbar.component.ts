import { Component ,Input} from '@angular/core';
import { NotificationService } from 'src/app/notifications/service/notification.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  notifications:number=0;
  constructor(private notificatioService:NotificationService){
    this.loadNotificationsLength();
  }
  loadNotificationsLength(){
 this.notifications=this.notificatioService.getNotificationlength();
  }
}
