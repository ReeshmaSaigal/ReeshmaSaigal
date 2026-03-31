import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-nav',
  templateUrl: './home-nav.component.html',
  styleUrls: ['./home-nav.component.css']
})
export class HomeNavComponent {

  constructor(private route:Router){}
  navigateToEmployer(){
    // this.route.navigateByUrl('http://localhost:4200/signup');
    // window.location.href = 'http://localhost:61701/dashboard';
    this.route.navigate(['/jobProvider-dashboard']);
  }
}
