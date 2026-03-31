import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth/service/AuthService.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  
  constructor(private authservice : AuthService,private router: Router) { }

  ngOnInit() {
  }

  navigateToDashboard() {
    this.router.navigate(['/admin-home/dashboard']);
  }

  navigateToNewRegistrations() {
    this.router.navigate(['/admin-home/new-registration/registrations']);
  }

  navigateToMessages() {
    this.router.navigate(['/admin-home/messages']);
  }

  navigateToSettings() {
    this.router.navigate(['/admin-home/setting/update']);
  }

  navigateToJobProviders() {
    this.router.navigate(['/admin-home/job-provider/list']);
  }

  navigateToJobs() {
    this.router.navigate(['/admin-home/jobs/list']);
  }

  navigateToJobSeekers() {
    this.router.navigate(['/admin-home/job-seeker/list']);
  }
  navigateToSkills() {
    this.router.navigate(['/admin-home/skill/addSkill']);
  }
  logout(): void {
    this.authservice.logout();
    this.router.navigate(['/login']);

  }
}
