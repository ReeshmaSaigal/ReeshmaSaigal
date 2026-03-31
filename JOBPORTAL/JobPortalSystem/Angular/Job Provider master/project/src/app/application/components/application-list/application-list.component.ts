import { Component, OnInit } from '@angular/core';
import { Application } from '../../models/application';
import { ApplicationService } from '../../services/application.service';

@Component({
  selector: 'app-application-list',
  templateUrl: './application-list.component.html',
  styleUrls: ['./application-list.component.css']
})
export class ApplicationListComponent implements OnInit {

  applications: Application[] = [];
  applicationCount: number = 0;
  isLoading: boolean = false;

  constructor(private applicationService: ApplicationService) {}

  ngOnInit(): void {
    this.loadApplications();
  }

  loadApplications() {
    console.log("JOB ID:", localStorage.getItem('jobProviderId'));
  this.isLoading = true;

  // ✅ GET REAL ID FROM STORAGE
  const jobProviderId = localStorage.getItem('jobProviderId');

  if (!jobProviderId) {
    console.error("JobProviderId missing");
    this.isLoading = false;
    return;
  }

  this.applicationService.getApplicants(jobProviderId).subscribe({
    next: (res: any) => {
      console.log("Applications:", res);

      // ✅ HANDLE ALL RESPONSE TYPES
      this.applications = res?.data || res || [];
      this.applicationCount = this.applications.length;

      this.isLoading = false;
    },
    error: (err) => {
      console.error('Error loading applications', err);
      this.isLoading = false;
    }
  });
}
}