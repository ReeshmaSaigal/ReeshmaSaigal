import { Component } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {
  logout() {
    // Implement logout functionality
    console.log("Logout clicked");
  }

  closeSidebar() {
    // Logic to close sidebar
  }
}
