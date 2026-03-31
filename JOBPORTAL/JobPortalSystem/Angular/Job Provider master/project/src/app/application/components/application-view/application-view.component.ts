import { Component, OnInit } from '@angular/core';
import { Profession } from 'src/app/settings/models/professional-info';
import { UserProfile } from 'src/app/settings/models/user-profile';
import { UserProfileService } from 'src/app/settings/services/user-profile.service';
import { ApplicationService } from 'src/app/application/services/application.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-application-view',
  templateUrl: './application-view.component.html',
  styleUrls: ['./application-view.component.css']
})
export class ApplicationViewComponent implements OnInit {
  jobProviderProfile: any[] = []; 
  providerProfession:Profession[]=[];
  img1='../../../../assets/images/settings/light-bulb 1.png';
  img2='../../../../assets/images/settings/portfolio 1.png';
  img3='../../../../assets/images/settings/portfolio 2.png';
  
   constructor(
  private route: ActivatedRoute,
  private applicationService: ApplicationService,
  private router: Router
) {}
  
    ngOnInit() {

  const jobProviderId = localStorage.getItem('jobProviderId');
  const applicationId = this.route.snapshot.paramMap.get('id');

  console.log("Selected ID:", applicationId);

  if (!jobProviderId || !applicationId) {
    console.error("Missing ID");
    return;
  }

  this.applicationService.getApplicants(jobProviderId).subscribe((res: any) => {

    const allApplicants = res?.data || res || [];

    // 🔥 MAIN FIX → filter ONE applicant
    const selectedApplicant = allApplicants.find(
      (a: any) => a.id === applicationId
    );

    this.jobProviderProfile = selectedApplicant ? [selectedApplicant] : [];

    console.log("FINAL:", this.jobProviderProfile);
  });
}
  scheduleInterview(applicationId: string) {
  console.log("Scheduling for:", applicationId);

  // ✅ store selected applicant
  localStorage.setItem('selectedApplicationId', applicationId);

  // ✅ navigate
  this.router.navigate(['/interview/schedule']);
}
  }
  