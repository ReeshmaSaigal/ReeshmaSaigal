import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {


  // Mock data for notifications
  notifications = [
    { title: 'New User Registered', message: 'A new user has just registered.', date: new Date(), type: 'User' },
    { title: 'Post Reported', message: 'A post has been reported by another user.', date: new Date(), type: 'Report' },
    { title: 'Message Received', message: 'You have received a new message.', date: new Date(), type: 'Message' },
    // Add more notifications as needed
  ];
  constructor() { }
  getNotificationlength():any
   {
    return this.notifications.length;
  }
  getNotification():any
  {
    return this.notifications;
  }
}
