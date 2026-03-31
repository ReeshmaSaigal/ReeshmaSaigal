import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-all-jobs-detail',
  templateUrl: './all-jobs-detail.component.html',
  styleUrls: ['./all-jobs-detail.component.css']
})
export class AllJobsDetailComponent {

  @Input() job: any;

  constructor(private router: Router) {}

  applyJob(id: number) {
    if (!id) return;

    this.router.navigate(
      ['jobseeker-home/upload-resume'],
      { queryParams: { jobId: id } }
    );
  }
}