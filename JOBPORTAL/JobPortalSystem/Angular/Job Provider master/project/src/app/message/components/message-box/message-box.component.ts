import { Component } from '@angular/core';

@Component({
  selector: 'app-message-box',
  templateUrl: './message-box.component.html',
  styleUrls: ['./message-box.component.css']
})
export class MessageBoxComponent {
  // @Input() title: string;
  // @Input() message: string;

  closeMessageBox() {
    // Add any logic to close or hide the message box
  }

}
