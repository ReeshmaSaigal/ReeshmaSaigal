import { Component, OnInit } from '@angular/core';
import { JobService } from '../../services/job.service';

@Component({
  selector: 'app-saved-jobs',
  templateUrl: './saved-jobs.component.html'
})
export class SavedJobsComponent implements OnInit {

  savedJobs: any[] = [];

  constructor(private jobService: JobService) {}

  ngOnInit(): void {
    this.loadSavedJobs();
  }

  loadSavedJobs() {
    const userId = sessionStorage.getItem('jobSeekerId');

    this.jobService.getSavedJobs(userId).subscribe((res: any) => {
      this.savedJobs = res;
      console.log('Saved Jobs:', res);
    });
  }

  removeSaved(job: any) {

    this.jobService.unSaveJob(job.id).subscribe(() => {

      // 🔥 remove from UI instantly
      this.savedJobs = this.savedJobs.filter(j => j.id !== job.id);

    });
  }
}