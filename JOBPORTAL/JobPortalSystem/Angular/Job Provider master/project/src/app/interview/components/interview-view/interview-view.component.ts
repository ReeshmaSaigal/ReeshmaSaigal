import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InterviewService } from '../../services/interview.service';
import { ActivatedRoute, Router } from '@angular/router';
import { JobService } from 'src/app/job/sevices/job.service';
import { ApplicationService } from 'src/app/application/services/application.service';

@Component({
  selector: 'app-interview-view',
  templateUrl: './interview-view.component.html',
  styleUrls: ['./interview-view.component.css']
})
export class InterviewViewComponent implements OnInit {

  scheduleInterviewForm!: FormGroup;
submitted = false;
showSuccessToast = false;
showErrorToast = false;
  constructor(
    private fb: FormBuilder,
    private interviewService: InterviewService,
    private appservice:ApplicationService,
    private router: Router,private route:ActivatedRoute
  ) {}
applicationId!:string;
jobTitle:string='';
  ngOnInit(): void {
    this.initForm();
    // ✅ Get route param
  this.applicationId = this.route.snapshot.paramMap.get('Id');

  // ✅ Get query param
  this.route.queryParams.subscribe(params => {
    this.jobTitle = params['jobTitle'];
  });

  console.log("ApplicationId:", this.applicationId);
  console.log("JobTitle:", this.jobTitle);

  // ✅ Auto-fill form
  this.scheduleInterviewForm.patchValue({
    jobTitle: this.jobTitle
  });
    
  }

  // ✅ FORM INIT (clean separation)
  initForm() {
    this.scheduleInterviewForm = this.fb.group({
      jobTitle: ['', Validators.required],
      location: ['', Validators.required],
      interviewDate: ['', Validators.required],
      interviewTime: ['', Validators.required]
    });
  }

  // ✅ SUBMIT
onSubmit(): void {

  if (this.scheduleInterviewForm.invalid) {
    this.scheduleInterviewForm.markAllAsTouched();
     const firstInvalid = document.querySelector('.is-invalid');
    if (firstInvalid) {
      firstInvalid.scrollIntoView({ behavior: 'smooth' });
    }

    this.showErrorToast = true;
    setTimeout(() => this.showErrorToast = false, 3000);

    return;
  }

  // 🔥 HARDCODE EVERYTHING
  const companyUserId = localStorage.getItem("jobProviderId");


  // ✅ combine date + time
  const dateTime = new Date(
    this.scheduleInterviewForm.value.interviewDate + ' ' +
    this.scheduleInterviewForm.value.interviewTime
  ).toISOString();

  const payload = {
    applicationId: this.applicationId,
    date: dateTime
  };

  console.log("FINAL PAYLOAD:", payload);

  this.interviewService
    .scheduleInterview(companyUserId, payload)
    .subscribe({
      next: () => {
        // alert("Interview Scheduled Successfully ✅");
        this.showSuccessToast = true;
  setTimeout(() => this.showSuccessToast = false, 3000);

  this.scheduleInterviewForm.reset();
  this.submitted = false;
        this.router.navigate(['/interview/list']);
      },
      error: (err) => {
        console.error("API ERROR:", err);
        alert("Error scheduling interview ❌");
      }
    });
}
}