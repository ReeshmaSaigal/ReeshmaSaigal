import { Component, OnInit } from '@angular/core';
import { jobService } from '../../service/jobService.service';
import { Jobs } from '../../model/job.model';

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
  styleUrls: ['./job-list.component.css']
})
export class JobListComponent implements OnInit {
  jobs: Jobs[] = [];
  filteredJobs: Jobs[] = [];
   searchTerm:string='';
  constructor(private jobService: jobService) { }

  ngOnInit(): void {
    this.getJobs();
  }

  getJobs(): void {
    this.jobService.getJobs().subscribe((jobs) => {
      this.jobs = jobs;
      this.filteredJobs = jobs;

    });
  }
  filterJobs() {

    this.jobService.filterJobs(this.searchTerm).subscribe(
      (result) => {
        this.filteredJobs = result;
        console.log(this.filteredJobs);
      },
      (error) => {
        console.error('Error filtering jobs', error);
      }
    );
  }
  filterJobsByName(jobName:string) {
    this.jobService.filterJobs(jobName).subscribe((result)=>{
      this.filteredJobs=result;
    })
  }
  }




