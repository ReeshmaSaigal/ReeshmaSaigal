import { Component } from '@angular/core';

@Component({
  selector: 'app-interview-header',
  templateUrl: './interview-header.component.html',
  styleUrls: ['./interview-header.component.css']
})
export class InterviewHeaderComponent {
  isMenuOpen: boolean = false;
  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
