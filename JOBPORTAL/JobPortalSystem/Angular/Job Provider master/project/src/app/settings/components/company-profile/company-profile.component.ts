import { Component, OnInit } from '@angular/core';
import { CompanyProfileService } from '../../services/company-profile.service';
import { CompanyProfile } from '../../models/company-profile';
import { startWith } from 'rxjs';

@Component({
  selector: 'app-company-profile',
  templateUrl: './company-profile.component.html',
  styleUrls: ['./company-profile.component.css']
})
export class CompanyProfileComponent implements OnInit {
 
  img1='../../../../assets/images/settings/binoculars 1.png';
  img2='../../../../assets/images/settings/bullseye 1.png';
  img3='../../../../assets/images/settings/receiver 1.png';
  constructor(private companyService: CompanyProfileService) { }
companyProfile!: CompanyProfile;

ngOnInit(): void {
  const jobProviderId = localStorage.getItem('jobProviderId');

  if (!jobProviderId) return;

  this.companyService.getCompanyProfile(jobProviderId)
    .subscribe({
      next: (data) => {
        this.companyProfile = data[0]; // 👈 FIX HERE
        console.log("Company Data ✅", data);
      }
    });
}

}
