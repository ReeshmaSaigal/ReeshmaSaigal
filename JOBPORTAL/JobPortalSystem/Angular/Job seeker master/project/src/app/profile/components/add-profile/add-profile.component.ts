import { Component } from '@angular/core';
import { animate, style, transition, trigger } from '@angular/animations';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProfileService } from '../../services/profile.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-profile',
  templateUrl: './add-profile.component.html',
  styleUrls: ['./add-profile.component.css'],
  animations: [
    trigger('borderAnimation', [
      transition('* => *', [
        style({ borderColor: 'transparent' }),
        animate('3s', style({ borderColor: '#990967' })),
        animate('3s', style({ borderColor: '#775d09' })),
        animate('3s', style({ borderColor: '#890707' })),
        animate('3s', style({ borderColor: '#07d326' })),
        animate('3s', style({ borderColor: '#0b4158' })),
      ]),
    ]),
  ],
})
export class AddProfileComponent {

  profileForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private profileService: ProfileService,
    private router: Router
  ) {
    this.profileForm = this.fb.group({
      profileName: ['', Validators.required],
      profileSummary: ['', Validators.required]
    });
  }

  addProfile() {

  if (this.profileForm.invalid) return;

  const data = {
    jobSeekerId: sessionStorage.getItem('jobSeekerId'),
    profileName: this.profileForm.value.profileName,
    profileSummary: this.profileForm.value.profileSummary
  };

  this.profileService.addNewProfile(data).subscribe({
  next: (res: any) => {

    console.log(res); // "Profile Added successfully"

    alert(res); // ✅ show backend message

    this.router.navigate(['/jobseeker-home/profile']);
  },
  error: (err) => {
    console.error(err);
    alert("Failed to add profile");
  }
});
  }
}