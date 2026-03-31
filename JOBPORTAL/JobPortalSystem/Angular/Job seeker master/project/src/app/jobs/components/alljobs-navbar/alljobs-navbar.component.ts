import { Component } from '@angular/core';

@Component({
  selector: 'app-alljobs-navbar',
  templateUrl: './alljobs-navbar.component.html',
  styleUrls: ['./alljobs-navbar.component.css']
})
export class AlljobsNavbarComponent {

  isResponsive: boolean = false;

  toggleResponsive() {
    this.isResponsive = !this.isResponsive;
  }
}
