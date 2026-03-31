import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserProfileService } from '../../services/user-profile.service';
import { UserProfile } from '../../models/user-profile';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  updateUsernameForm!: FormGroup;
  passwordResetForm!:FormGroup;
  userProfileData:UserProfile[]=[];
  constructor(private formBuilder:FormBuilder,private userProfile:UserProfileService){}

  ngOnInit(): void {
    this.updateUsernameForm = this.formBuilder.group({
      jobProviderName:[''],
      username:[''],
      email:[''],
      phone:['']
    }),

    this.passwordResetForm=this.formBuilder.group({
      id:[''],
      password:[''],
      newPassword:[],
      confirmPassword:['']
    })
    this.userProfile.getProviderProfile().subscribe((userProfile:UserProfile[])=>{
      this.userProfileData=userProfile;
      console.log(this.userProfileData[0]);
      this.updateUsernameForm.patchValue(this.userProfileData[0]);
      this.passwordResetForm.patchValue(this.userProfileData[0]);
    
    })
  }
  onSubmit(){
    console.log("hai");
    const formdata=this.updateUsernameForm.value;
    console.log(this.updateUsernameForm.value); 
    this.userProfile.changeUsername(formdata).subscribe((data)=>{
      console.log("updated successfully"+data);
      
    })
  }

  changePassword(){
    const formdata=this.passwordResetForm.get('confirmPassword')?.value ?? '';
    console.log(formdata);
    this.userProfile.changePassword(formdata).subscribe((data)=>{
      console.log("updated successfully"+data);
    })
  }
} 


