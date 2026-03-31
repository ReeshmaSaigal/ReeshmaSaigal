import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../../service/dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  interviewCount: number = 0;
  jobCount: number = 0;
  applicationCount: number = 0;

  constructor(private dashboardService: DashboardService) {}

 
 ngOnInit(): void {
  this.loadCounts();
}

loadCounts() {

  const jobProviderId = localStorage.getItem("jobProviderId");
  const companyId = localStorage.getItem("companyId");

  
  // ✅ APPLICATION COUNT
  this.dashboardService.CountOfApplications(jobProviderId).subscribe({
    next: (res) => {
      console.log("Applications:", res);
      this.applicationCount = res?.length || res?.data?.length || 0;
    },
    error: (err) => {
      console.error("Application error", err);
      this.applicationCount = 0;
    }
  });

  // ✅ INTERVIEW COUNT
  this.dashboardService.CountOfInterviews(companyId).subscribe({
    next: (res) => {
      console.log("Interviews:", res);
      this.interviewCount = res?.length || res?.data?.length || 0;
    },
    error: (err) => {
      console.error("Interview error", err);
      this.interviewCount = 0;
    }
  });
  this.dashboardService.CountOfJobs().subscribe({
    next: (res) => {
      console.log("Jobs:", res);
      this.jobCount = res?.count || res?.data?.count || 0;
    },
    error: (err) => {
      console.error("Job error", err);
      this.jobCount = 0;
    }
  });
}
}