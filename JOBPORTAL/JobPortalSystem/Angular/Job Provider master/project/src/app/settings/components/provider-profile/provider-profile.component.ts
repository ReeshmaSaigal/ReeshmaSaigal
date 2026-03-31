import { Component, OnInit } from '@angular/core';
import { UserProfile } from '../../models/user-profile';
import { UserProfileService } from '../../services/user-profile.service';
import { Profession } from '../../models/professional-info';

@Component({
  selector: 'app-provider-profile',
  templateUrl: './provider-profile.component.html',
  styleUrls: ['./provider-profile.component.css']
})
export class ProviderProfileComponent implements OnInit  {
jobProviderProfile:UserProfile[]=[];
providerProfession:Profession[]=[];
img1='../../../../assets/images/settings/light-bulb 1.png';
img2='../../../../assets/images/settings/portfolio 1.png';
img3='../../../../assets/images/settings/portfolio 2.png';
  constructor(private userProfile:UserProfileService){}

  ngOnInit(){
    this.userProfile.getProviderProfile().subscribe((jobProviderProfile:UserProfile[])=>
    {
      this.jobProviderProfile=jobProviderProfile;
      console.log(this.jobProviderProfile);
    
console.log("PROFILE DATA:", this.jobProviderProfile);
      
    });
  }

}
