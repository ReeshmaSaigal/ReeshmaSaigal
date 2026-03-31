import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserProfile } from '../models/user-profile';
import { environment } from 'src/environments/environment';
import { CompanyProfile } from '../models/company-profile';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {

  constructor(private http:HttpClient) { }
 getProviderProfile() {
  const id = localStorage.getItem('jobProviderId');

  return this.http.get<any>(
    `${environment.baseurl}job-provider/${id}/getCompany`
  );
}

getCompanyProfile(jobProviderId: string) {
  return this.http.get<CompanyProfile[]>(
    `${environment.baseurl}job-provider/${jobProviderId}/getCompany`
  );
}
changeUsername(providerProfileData:any){
  const id = localStorage.getItem("jobProviderId");
  return this.http.patch<any>(`${environment.baseurl}jobProviderProfile`+'/'+id,providerProfileData)
}

changePassword(formData:any){
  const id = 1;
  return this.http.patch<any>(`${environment.baseurl}jobProviderProfile`+'/'+id,formData)
}
}
