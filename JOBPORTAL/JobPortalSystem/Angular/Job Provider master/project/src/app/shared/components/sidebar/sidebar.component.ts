import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth/services/auth.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {

  constructor(private router: Router, private authService: AuthService) {}

  jobsRoute() {
    this.router.navigate(['jobs/list'])
  }

  showCompanyOption(): boolean {
    // Get the user role from the AuthService
    const userRole = this.authService.getRole();

    // Check if the user is a company user
    return userRole === 'JOB_PROVIDER';
  }
}
