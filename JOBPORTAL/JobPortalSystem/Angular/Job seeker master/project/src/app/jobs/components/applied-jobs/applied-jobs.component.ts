import { Component, OnInit } from '@angular/core';
import { JobService } from '../../services/job.service';
import { job } from '../../models/job';
import { Router } from '@angular/router';
import { ConfirmBoxInitializer, DialogLayoutDisplay } from '@costlydeveloper/ngx-awesome-popup';

@Component({
  selector: 'app-applied-jobs',
  templateUrl: './applied-jobs.component.html',
  styleUrls: ['./applied-jobs.component.css']
})

export class AppliedJobsComponent implements OnInit {

  appliedJobList: any[] = [];

  constructor(
    private jobService: JobService,
    private router: Router
  ) {}

  ngOnInit() {
    this.getAppliedJobs();
  }

  // =========================
  // GET APPLIED JOBS
  // =========================
  getAppliedJobs() {
    this.jobService.getAppliedJobs().subscribe({
      next: (res: any) => {
        this.appliedJobList = res;
        console.log(res);
      },
      error: (err) => {
        console.error(err);
      }
    });
  }

  // =========================
  // DELETE / CANCEL JOB
  // =========================
  deleteJob(id: any) {

    const confirmDelete = confirm('Cancel this application?');

    if (!confirmDelete) return;

    this.jobService.cancelJob(id).subscribe({
      next: (res: any) => {

        if (res?.message === 'deleted') {
          alert('Application cancelled successfully');
          this.getAppliedJobs(); // refresh list
        }

      },
      error: (err) => {
        console.error(err);
        alert('Failed to cancel');
      }
    });
  }
}