import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';
import { ProfileService } from '../../services/profile.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import { skill } from '../../models/profile';

@Component({
  selector: 'app-profile-info',
  templateUrl: './profile-info.component.html',
  styleUrls: ['./profile-info.component.css'],
  providers: [DatePipe]
})
export class ProfileInfoComponent implements OnInit {

  user: any;
  profile: any;
  profileId: any;

  resumeFile: any;
qualification: any[] = [];


  addedSkill: skill[] = [];
  dropDownData: any[] = [];

  
  experience: any[] = [];

  // UI Toggles
  isEditMode = false;
  isEditMode2 = false;
  isEditMode3 = false;

  skillSection: any = '';
  errorMessage: string = '';

  qualificationForm!: FormGroup;
  experienceForm!: FormGroup;

  constructor(
    private authService: AuthService,
    private profileService: ProfileService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {

    const userId = sessionStorage.getItem('jobSeekerId');
 this.profileId = sessionStorage.getItem('profileId');

  
    // ✅ Load user
    this.authService.getUserProfileById(userId).subscribe((res: any[]) => {
      this.user = res[0];
    });

    // ✅ Load dropdown skills
    this.getSkill();

    // ✅ Get profileId and load all data AFTER that
    this.route.params.subscribe(params => {
      this.profileId = params['id'];
        this.loadProfile();
      this.getProfile();
      this.getSkillByUser();
      this.getQualification();
      this.getExperience();
    });

    // Forms
    this.qualificationForm = this.fb.group({
      qualificationName: ['', Validators.required],
      description: ['', Validators.required]
    });

    this.experienceForm = this.fb.group({
      jobTitle: ['', Validators.required],
      companyName: ['', Validators.required],
      summary: ['', Validators.required],
      serviceStart: [null, Validators.required],
      serviceEnd: [null, Validators.required]
    });
  }

  // =========================
  // FILE UPLOAD
  // =========================
  onFileSelect(event: any) {
    this.resumeFile = event.target.files[0];
  }

  uploadResume() {
  if (!this.resumeFile) {
    alert('Please select a file');
    return;
  }

  const formData = new FormData();
  formData.append('file', this.resumeFile);

  // ✅ FALLBACK VALUES (IMPORTANT)
  const profileName = this.profile?.profileName || 'Default Profile';
  const profileSummary = this.profile?.profileSummary || 'Default Summary';

  this.profileService.uploadCV(
    this.profileId,
    profileName,
    profileSummary,
    formData
  ).subscribe({
    next: () => {
      alert('✅ Resume uploaded successfully');
    },
    error: (err) => {
      console.error(err);
      alert('❌ Upload failed');
    }
  });
}

  // =========================
  // SKILLS
  // =========================
  getSkill() {
    this.profileService.getAllSkill().subscribe(res => {
      this.dropDownData = res;
    });
  }

  getSkillByUser() {
    this.profileService.getSkillByUser(this.profileId).subscribe(res => {
      this.addedSkill = res;
    });
  }

  addSkill() {
    if (!this.skillSection) return;

    const skillIds = [this.skillSection];

    this.profileService.addSkill(skillIds, this.profileId).subscribe({
      next: () => {
        this.getSkillByUser();
        this.isEditMode = false;
      },
      error: () => {
        this.errorMessage = 'Skill already added';
      }
    });
  }

  // =========================
  // QUALIFICATION
  // =========================
  addQualification() {
    if (this.qualificationForm.invalid) return;

    const { qualificationName, description } = this.qualificationForm.value;

    this.profileService.addQualification(
      qualificationName,
      description,
      this.profileId
    ).subscribe(() => {
      this.getQualification();
      this.qualificationForm.reset();
      this.isEditMode2 = false;
    });
  }

  loadProfile() {
  const jobSeekerId = sessionStorage.getItem('jobSeekerId');

  this.profileService.getUserProfileById(jobSeekerId).subscribe(res => {
    console.log('PROFILE RESPONSE:', res);

    // 🔥 FIX: backend returns array
    this.profile = res[0];

    console.log('PROFILE:', this.profile);
  });
}
  getQualification() {
  this.profileService.getQualification(this.profileId)
    .subscribe((res: any[]) => {
      console.log(res);
      this.qualification = res;
    });
}
  // =========================
  // EXPERIENCE
  // =========================
  addExperience() {
    if (this.experienceForm.invalid) return;

    const form = this.experienceForm.value;

    const experience = {
      jobTitle: form.jobTitle,
      companyName: form.companyName,
      summary: form.summary,
      serviceStart: this.formatDate(form.serviceStart),
      serviceEnd: this.formatDate(form.serviceEnd)
    };

    this.profileService.addExperience(experience, this.profileId)
      .subscribe(() => {
        this.getExperience();
        this.experienceForm.reset();
        this.isEditMode3 = false;
      });
  }

  getExperience() {
    this.profileService.getExperience(this.profileId).subscribe(res => {
      this.experience = res;
    });
  }

  // =========================
  // PROFILE
  // =========================
  getProfile() {
    this.profileService.getProfile().subscribe(res => {
      this.profile = res[0];
       console.log('PROFILE:', this.profile);
    });
  }

  // =========================
  // UTIL
  // =========================
  formatDate(date: any): string {
    return this.datePipe.transform(date, 'yyyy-MM-dd') || '';
  }

  toggleEditMode() {
    this.isEditMode = !this.isEditMode;
  }

  toggleEditMode2() {
    this.isEditMode2 = !this.isEditMode2;
  }

  toggleEditMode3() {
    this.isEditMode3 = !this.isEditMode3;
  }
}