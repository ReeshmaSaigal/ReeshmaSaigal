import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { JobService } from '../../sevices/job.service';
import { CompanyService } from 'src/app/company/services/company.service';
import { addJob } from '../../models/job';
import { Router } from '@angular/router';

@Component({
  selector: 'app-job-add',
  templateUrl: './job-add.component.html',
  styleUrls: ['./job-add.component.css']
})
export class JobAddComponent implements OnInit {

  addJobForm!: FormGroup;

  industryName: any[] = [];
  locationName: any[] = [];
  catogoryName: any[] = [];

  constructor(
    private fb: FormBuilder,
    private jobService: JobService,
    private companyService: CompanyService,
    private router: Router 
  ) {}

  ngOnInit(): void {
    this.addJobForm = this.fb.group({
      jobTitle: ['', Validators.required],
      locationId: ['', Validators.required],
      industryId: ['', Validators.required],
      jobSummary: ['', Validators.required],
      categoryId: ['', Validators.required]
    });

    this.loadIndustries();
    this.loadLocations();
    this.loadCategories();
  }
  submitted = false;
  showToast=false;
  showErrorToast=false;
  onSubmit(): void {
  this.submitted = true;
    if (this.addJobForm.invalid) {
      this.addJobForm.markAllAsTouched();
      this.showErrorToast = true;

    setTimeout(() => {
      this.showErrorToast = false;
    }, 3000);

      return;
    }

    const companyId = localStorage.getItem('companyId');
    const jobProviderId = localStorage.getItem('jobProviderId');

    if (!companyId || !jobProviderId) {
      alert("Missing company or job provider ❌");
      return;
    }

    const jobData: addJob = {
      ...this.addJobForm.value,
      postedBy: jobProviderId,
      postedDate: new Date().toISOString(),
      companyId: companyId
    };

    console.log("Sending:", jobData);

    this.jobService.addJob(jobData).subscribe({
  next: (res) => {
  console.log("SUCCESS:", res);

  // alert("Job posted successfully ✅"); // ✅ show alert first
 this.showToast = true;

  // ✅ Auto hide toast
  setTimeout(() => {
    this.showToast = false;
  }, 3000);

  // ✅ Reset form
  this.addJobForm.reset();
  this.submitted = false;
  this.router.navigate(['/jobs/list']); // ✅ then redirect
},
  error: (err) => {
    console.log("ERROR FULL:", err);
    alert("Error posting job ❌");
  }
});
  }

  loadIndustries() {
    this.companyService.getIndustries().subscribe(data => {
      this.industryName = data;
    });
  }

  loadLocations() {
    this.companyService.getLocations().subscribe(data => {
      this.locationName = data;
      console.log(this.locationName);
      
    });
  }

  loadCategories() {
    this.companyService.getCategories().subscribe(data => {
      this.catogoryName = data;
    });
  }

}