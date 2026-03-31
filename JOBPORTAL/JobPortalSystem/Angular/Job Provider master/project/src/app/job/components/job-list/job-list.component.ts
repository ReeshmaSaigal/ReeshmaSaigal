import { Component, OnInit } from '@angular/core';
import { addJob } from '../../models/job';
import { JobService } from '../../sevices/job.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
  styleUrls: ['./job-list.component.css']
})
export class JobListComponent implements OnInit {
  jobs: addJob[] = [];
  currentPage = 1;
  totalPages = 1;
  totalItems = 0;
  itemsPerPage = 5;
  searchQuery: string = '';
  jobId:any;
  constructor(private jobService: JobService,private route:Router) { }

  ngOnInit() {
    this.getJobs();
  }
  getJobs() {
    this.jobService.getJob(this.currentPage, this.itemsPerPage,this.searchQuery
      ).subscribe(
      (res: any) => {
        this.jobs = res;
        console.log(res);
        this.jobId=res.id;
        // this.currentPage = res.currentPage;
        // this.totalPages = res.totalPages;
        // this.totalItems = res.totalItems;
      },
      (error) => {
        console.error('Error fetching job data:', error);
      }
    );
  }

  changePage(pageNumber: number) {
    if (pageNumber >= 1 && pageNumber <= this.totalPages) {
      this.currentPage = pageNumber;
      this.getJobs();
    }
  }

  
  onSearch() {
      this.currentPage = 1; // Reset to the first page when a new search query is entered
     this.getJobs();
     }
 
     updateJob(id: any) {
  this.route.navigate([`jobs/update/${id}`]);
}

     deleteJob(id: any) {
  if (confirm("Are you sure you want to delete this job?")) {
    this.jobService.deleteJob(id).subscribe(() => {
      this.getJobs();
    });
  }
}
   
  }
  


