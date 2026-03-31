import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../../services/profile.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-new-profile',
  templateUrl: './add-new-profile.component.html',
  styleUrls: ['./add-new-profile.component.css']
})
export class AddNewProfileComponent implements OnInit {

  profiles: any[] = [];

  // ✅ store file per profile
  selectedFiles: { [key: string]: File } = {};

  constructor(
    private router: Router,
    private profileService: ProfileService
  ) {}

  ngOnInit(): void {
    this.loadProfiles();
  }

  // =========================
  // LOAD PROFILES
  // =========================
  loadProfiles() {
    this.profileService.getAllProfile().subscribe({
      next: (data: any) => {
        this.profiles = data;
        console.log('Profiles:', this.profiles);
      },
      error: (err) => {
        console.error(err);
        alert('Failed to load profiles');
      }
    });
  }

  // =========================
  // NAVIGATION
  // =========================
  navigateToAddProfile() {
    this.router.navigate(['jobseeker-home/add-profile']);
  }

  viewProfile(profileId: string) {
    this.router.navigate(['jobseeker-home/profile-info', profileId]);
  }

  // =========================
  // FILE SELECT
  // =========================
  onFileChange(event: any, profileId: string) {
    const file = event.target.files[0];

    if (file) {
      this.selectedFiles[profileId] = file;
    }
  }

  // =========================
  // UPLOAD RESUME
  // =========================
  uploadResume(profile: any) {

    const file = this.selectedFiles[profile.id];

    if (!file) {
      alert("Please select a file first");
      return;
    }

    const formData = new FormData();
    formData.append('file', file);

    this.profileService.uploadCV(
      profile.id,
      profile.profileName,
      profile.profileSummary,
      formData
    ).subscribe({
      next: () => {
        alert("Resume uploaded successfully");

        // optional refresh
        this.loadProfiles();
      },
      error: (err) => {
        console.error(err);
        alert("Upload failed");
      }
    });
  }

  viewResume(profileId: string) {
  this.profileService.getResume(profileId).subscribe({
    next: (res: any) => {
      console.log("Resume:", res);

      if (res && res.length > 0) {
        alert("Resume exists ✅");
      } else {
        alert("No resume found ❌");
      }
    },
    error: (err) => {
      console.error(err);
      alert("Error fetching resume");
    }
  });
}
}