import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CompanyProfile } from '../models/company-profile';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompanyProfileService {

  constructor(private http:HttpClient) { }
 getCompanyProfile(jobProviderId: string) {
  return this.http.get<CompanyProfile[]>(
    `${environment.baseurl}job-provider/${jobProviderId}/getCompany`
  );
}
}
