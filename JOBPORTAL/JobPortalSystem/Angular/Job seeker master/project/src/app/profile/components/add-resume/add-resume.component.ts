import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../../services/profile.service';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { JobService } from 'src/app/jobs/services/job.service';

@Component({
  selector: 'app-add-resume',
  templateUrl: './add-resume.component.html',
  styleUrls: ['./add-resume.component.css']
})
export class AddResumeComponent implements OnInit {

  profiles: any[] = [];
  dropdownData: any[] = [];

  jobId: any;
  selectedProfileId: any;
  selectedFile!: File;

  constructor(
    private profileService: ProfileService,
    private route: ActivatedRoute,
    private jobService: JobService,
    private router: Router
  ) {}

  ngOnInit(): void {

    // jobId
    this.route.queryParams.subscribe(params => {
      this.jobId = params['jobId'];
    });

    // load profiles
    this.loadProfiles();
  }

  // =========================
  // LOAD PROFILES
  // =========================
  loadProfiles() {
    this.profileService.getAllProfile().subscribe({
      next: (res) => {
        this.profiles = res;
      }
    });
  }

  // =========================
  // PROFILE CHANGE
  // =========================
  onProfileChange(event: any) {

    this.selectedProfileId = event.target.value;

    this.profileService.getResume(this.selectedProfileId)
      .subscribe(res => {
        this.dropdownData = res;
      });
  }

  // =========================
  // FILE CHANGE
  // =========================
  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      this.selectedFile = event.target.files[0];
    }
  }

  // =========================
  // SUBMIT
  // =========================
  onSubmit(form: NgForm) {

    if (!form.valid) {
      alert('Fill all required fields');
      return;
    }

    const profileId = form.value.profileId;
    const resumeId = form.value.selectedOption;
    const coverLetter = form.value.coverLetter;

    // 🔥 If uploading new resume
    if (this.selectedFile) {

      const formData = new FormData();
      formData.append('file', this.selectedFile);

      this.profileService.uploadCV(
        profileId,
        'New Profile',
        'Uploaded from apply page',
        formData
      ).subscribe(() => {

        // get latest resume
        this.profileService.getResume(profileId).subscribe(data => {
          const latest = data[data.length - 1];

          this.applyJob(latest.id, coverLetter);
        });

      });

    } else {

      if (!resumeId) {
        alert('Select resume');
        return;
      }

      this.applyJob(resumeId, coverLetter);
    }
  }

  // =========================
  // APPLY JOB
  // =========================
  applyJob(resumeId: any, coverLetter: string) {

  const jobTitle = "Default Title"; // ❗ TEMP FIX

  this.jobService.applyJob(
    this.jobId,
    resumeId,
    coverLetter,
    jobTitle
  ).subscribe({
    next: () => {
      alert('Applied Successfully');
      this.router.navigate(['/jobseeker-home/appliedJobs']);
    },
    error: (err) => {
      console.error(err);
      alert('Apply failed');
    }
  });
}
}