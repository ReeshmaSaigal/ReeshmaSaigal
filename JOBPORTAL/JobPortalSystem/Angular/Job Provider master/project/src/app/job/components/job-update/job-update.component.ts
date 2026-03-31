import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { JobService } from '../../sevices/job.service';
import { addJob } from '../../models/job';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyService } from 'src/app/company/services/company.service';

@Component({
  selector: 'app-job-update',
  templateUrl: './job-update.component.html',
  styleUrls: ['./job-update.component.css']
})
export class JobUpdateComponent implements OnInit {

  addJobForm!: FormGroup;
  jobId!: string;
submitted = false;
showSuccessToast = false;
showErrorToast = false;
  // dropdown data
  industryName: any[] = [];
  locationName: any[] = [];
  catogoryName: any[] = [];

  constructor(
    private fb: FormBuilder,
    private jobService: JobService,
    private companyService: CompanyService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {

    // ✅ FORM (match backend exactly)
    this.addJobForm = this.fb.group({
      jobTitle: ['', Validators.required],
      locationId: ['', Validators.required],
      industryId: ['', Validators.required],
      jobSummary: ['', Validators.required],
      categoryId: ['', Validators.required]
    });

    // ✅ load dropdowns
    this.loadIndustries();
    this.loadLocations();
    this.loadCategories();

    // ✅ get id + load job
    this.route.params.subscribe(params => {
      this.jobId = params['id'];
      this.getJobdetails();
    });
  }

  // ✅ LOAD JOB DATA
  getJobdetails() {
    
    this.jobService.getjobid(this.jobId).subscribe({
      next: (res: any) => {
        console.log("JOB DATA:", res);

        this.addJobForm.patchValue({
          jobTitle: res.jobTitle,
          locationId: res.locationId,
          industryId: res.industryId,
          jobSummary: res.jobSummary,
          categoryId: res.categoryId
        });
      },
      error: (err) =>console.log(err)

    });
  }

  // ✅ UPDATE JOB
  onSubmit() {
    this.submitted=true;
    if (this.addJobForm.invalid) {
      this.addJobForm.markAllAsTouched();
             // show error toast
    this.showErrorToast = true;
    setTimeout(() => this.showErrorToast = false, 3000);
      
      return;
    }

    const jobData: addJob = this.addJobForm.value;

    this.jobService.updateJob(this.jobId, jobData).subscribe({
      next: () => {
        // alert("Job updated successfully ✅");
         // show success toast
  this.showSuccessToast = true;
  setTimeout(() => this.showSuccessToast = false, 3000);
this.addJobForm.reset();
        this.router.navigate(['/jobs/list']);
      },
      error: (err) => {
        console.log(err);
        alert("Update failed ❌");
      }
    });
  }

  // ✅ DROPDOWNS
  loadIndustries() {
    this.companyService.getIndustries().subscribe(data => {
      this.industryName = data;
    });
  }

  loadLocations() {
    this.companyService.getLocations().subscribe(data => {
      this.locationName = data;
    });
  }

  loadCategories() {
    this.companyService.getCategories().subscribe(data => {
      this.catogoryName = data;
    });
  }
}