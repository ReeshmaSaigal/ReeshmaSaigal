// import { Component ,OnInit} from '@angular/core';
// import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import { profile } from '../../model/settings.model';
// import {settingService} from  '../../service/settingService.service';
// import { ActivatedRoute, Router } from '@angular/router';

// @Component({
//   selector: 'app-setting-update',
//   templateUrl: './setting-update.component.html',
//   styleUrls: ['./setting-update.component.css']
// })
// export class SettingUpdateComponent implements OnInit {
 
 
//   profile: profile[] = [];
 
//   profileForm!:FormGroup;
  

//   constructor(private settingService: settingService,private formBuilder: FormBuilder) {}

//    ngOnInit(): void {
//     this.profileForm = this.formBuilder.group({
//      fullname: ['', Validators.required],
//      email: ['', Validators.required],
//       username: ['', Validators.required],
//       password: ['', [Validators.required, Validators.minLength(6)]],
//       confirmPassword: ['', [Validators.required, Validators.minLength(6)]]
//     });
//     this.getProfile();
//   }

  
//   updateProfile(): void {
//     if (this.profileForm.invalid) {
//       return;
//     }

//     const updatedProfile: profile = this.profileForm.value;
//     this.settingService.updateProfile(updatedProfile).subscribe(
//       (response) => {
//         console.log('Profile updated successfully:', response);
//         this.getProfile();
//       },
//       (error) => {
//         console.error('Failed to update profile:', error);
//       }
//     );
//   }
//   getProfile(): void {
//     this.settingService.getProfile().subscribe((result) => {
//       this.profile = result;
      
//     });
// }

// }
// src/app/setting/components/setting-update/setting-update.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { profile } from '../../model/settings.model';
import { settingService } from '../../service/settingService.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-setting-update',
  templateUrl: './setting-update.component.html',
  styleUrls: ['./setting-update.component.css']
})
export class SettingUpdateComponent implements OnInit {
  profile: profile[] = [];
  profileForm!: FormGroup;
  router: any;

  constructor(
    private settingService: settingService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.profileForm = this.formBuilder.group({
      fullname: ['', Validators.required],
      email: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(6)]]
    });

    this.getProfile();
  }

  updateProfile(){

    const formdata=this.profileForm.value;
    console.log(this.profileForm.value); 
    this.settingService.updateProfile(formdata).subscribe((data)=>{
      alert("updated successfully");
      this.router.navigate(['/login']);
      
    })
  }

  // to get values 

  getProfile(): void {
    this.settingService.getProfile().subscribe((result) => {
      this.profile = result;
      // Set the form values after retrieving the profile data
      if (this.profile.length > 0) {
        this.profileForm.patchValue({
          fullname: this.profile[0].fullname,
          email: this.profile[0].email,
          username: this.profile[0].username,
          password: '', // Don't set password values in the form
          confirmPassword: '', // Don't set confirmPassword values in the form
        });
      }
    });
  }
}
