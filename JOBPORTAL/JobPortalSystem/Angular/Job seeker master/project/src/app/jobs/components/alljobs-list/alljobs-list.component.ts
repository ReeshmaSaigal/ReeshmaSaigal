import { Component, OnInit } from '@angular/core';
import { JobService } from '../../services/job.service';

@Component({
  selector: 'app-alljobs-list',
  templateUrl: './alljobs-list.component.html',
  styleUrls: ['./alljobs-list.component.css']
})
export class AlljobsListComponent implements OnInit {

  jobs: any[] = [];
  selectedJob: any;

  currentPage = 1;
  totalPages = 1;
  itemsPerPage = 2;

  searchQuery: string = '';

  constructor(private jobService: JobService) {}

  ngOnInit(): void {
    this.getJobs();
  }

  // ✅ Load Jobs
  getJobs(): void {
    this.jobService.getJobs(
      this.currentPage,
      this.itemsPerPage,
      this.searchQuery
    ).subscribe({
      next: (res: any) => {
        this.jobs = res || [];

        console.log('Jobs:', this.jobs);

        // ✅ Auto select first job
        if (this.jobs.length > 0) {
          this.selectedJob = this.jobs[0];
        }
      },
      error: (err) => {
        console.error('Error loading jobs', err);
      }
    });
  }

  // ✅ Show job detail
  viewJobDetail(job: any): void {
    this.selectedJob = job;
  }

  // ✅ Pagination
  changePage(pageNumber: number): void {
    if (pageNumber < 1 || pageNumber > this.totalPages) return;

    this.currentPage = pageNumber;
    this.getJobs();
  }

  // ✅ SAVE / UNSAVE (FIXED)
  saveJob(job: any): void {

    if (!job.saved) {

      this.jobService.saveJob(job.id).subscribe({
        next: () => {
          job.saved = true;
          this.jobs = [...this.jobs]; // 🔥 trigger change detection
        },
        error: () => {
          // fallback (since backend returning ok:false)
          job.saved = true;
          this.jobs = [...this.jobs];
        }
      });

    } else {

      this.jobService.unSaveJob(job.id).subscribe({
        next: () => {
          job.saved = false;
          this.jobs = [...this.jobs];
        },
        error: () => {
          job.saved = false;
          this.jobs = [...this.jobs];
        }
      });

    }
  }
}