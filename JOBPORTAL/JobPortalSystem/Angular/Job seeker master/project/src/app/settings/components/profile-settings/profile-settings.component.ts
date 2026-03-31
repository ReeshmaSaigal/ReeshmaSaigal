import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpHeaders } from '@angular/common/http';
import { AuthService } from 'src/app/auth/services/auth.service';
import { ProfileService } from 'src/app/profile/services/profile.service';

@Component({
  selector: 'app-profile-settings',
  templateUrl: './profile-settings.component.html',
  styleUrls: ['./profile-settings.component.css']
})
export class ProfileSettingsComponent implements OnInit {
  settingsForm!: FormGroup;
  jobSeekerId: any = sessionStorage.getItem('jobSeekerId');
  seeker = [{ firstName: '', lastName: '', userName: '', password: '', email: '', image: '', phone: '' }];
  imagePreview: string | ArrayBuffer | null = null;
  imgsrc : any = '';
  file!: File ;
  //  formData = new FormData();
//  formData:FormData = new FormData();
  constructor(private formBuilder: FormBuilder, private profileService: ProfileService, private authService: AuthService) {}

  ngOnInit() {
    this.settingsForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      userName: ['', Validators.required],
      password: ['', Validators.required],
      phone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      profileImage: [null]
    });
    
    this.getProfileData();
  }

  getProfileData() {
    const jobSeekerId = sessionStorage.getItem('jobSeekerId');
    this.profileService.getUserProfileById(jobSeekerId).subscribe(data => {
      this.seeker = data;
      this.settingsForm.patchValue({
        firstName: this.seeker[0].firstName,
        lastName: this.seeker[0].lastName,
        userName: this.seeker[0].userName,
        password: this.seeker[0].password,
        phone: this.seeker[0].phone,
        email: this.seeker[0].email,
      });
      this.imagePreview = this.seeker[0].image;
      console.log('Form Data:', this.settingsForm.value);

    });
  }

  onSubmit() {
    if (this.settingsForm.valid) {
      // alert(this.file?.name );
      const base64String = this.imgsrc.split(',')[1];
      // alert(base64String);
      const formData = new FormData();
      if (this.file) {
        formData.append('file', this.file, this.file.name);
      }
  
      const imageFile = this.settingsForm.value.profileImage;
      // const imageBlob = new Blob([imageFile], { type: 'image/png' });

 
      // this.formData.append('Image', imageBlob, 'OOPs.png')
     
      // formData.append('Image',this.file,this.file.name);
      // formData.append('Image',base64String);
      // if(this.file !== null){
      // formData.append('Image', this.file ,this.file?.name);
      // }
          // const updateSeeker={
          //   "jobseekerId": this.jobSeekerId,
          //   "userName":this.settingsForm.value.userName,
          //   "firstName":this.settingsForm.value.firstName,
          //   "lastName":this.settingsForm.value.lastName,
          //   "image":base64String,
          //   "phone":this.settingsForm.value.phone,
          //   "password":this.settingsForm.value.password
          // }
          // const profileData = {
          //   JobseekerId: 'a9679895-e2e9-46c6-8c95-08dbf8904001',
          //   UserName: 'Pranav',
          //   FirstName: 'pran',
          //   LastName: 'ki',
          //   Image: null,
          //   Phone: '890987678',
          //   Password: null
          // };
           formData.append('JobseekerId',this.jobSeekerId );
          formData.append('UserName', this.settingsForm.value.userName);
          formData.append('FirstName', this.settingsForm.value.firstName);
          formData.append('LastName', this.settingsForm.value.lastName);
         
          formData.append('Phone', this.settingsForm.value.phone);
          formData.append('Password',this.settingsForm.value.password);
       
      this.profileService.updateJobSeekerProfile(formData).subscribe(
        (data: any) => {
          console.log('Profile updated successfully', data);
          this.settingsForm.reset();
        },
        (error) => {
          console.error('Error updating profile', error);
  
          // Check the error response for additional details
          if (error.error && error.error.detail) {
            console.error('Error detail:', error.error.detail);
          }
         // Handle other error cases as needed
        }
        );
    } else {
      alert('Invalid form');
    }
  }
  
  onFileChange(event: any) {
    this.file = event.target.files[0];
    // this.formData.append('image',file,file.name);
    // alert(file.name);
    // alert(this.file);
    // this.settingsForm.patchValue({
    //  profileImage: this.file,
    // });

    const reader = new FileReader();
    reader.onload = (e:any) => {
      this.imgsrc = e.target.result;
    };
    reader.readAsDataURL(this.file);

    // this.formData.append('Image', file,'worker.png');
    // alert(this.formData)
  }
  
}
