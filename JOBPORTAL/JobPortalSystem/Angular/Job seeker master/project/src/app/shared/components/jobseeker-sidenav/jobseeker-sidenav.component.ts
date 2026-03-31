import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-jobseeker-sidenav',
  templateUrl: './jobseeker-sidenav.component.html',
  styleUrls: ['./jobseeker-sidenav.component.css']
})
export class JobseekerSidenavComponent implements OnInit {

  user: any;

  constructor(private router: Router){
  }
  
  ngOnInit() {
    this.user = JSON.parse(sessionStorage.getItem('user') as string);
  }
  
// navigate() {
//   this.router.navigate(['allJobs/findAllJobs']);
// }

}
