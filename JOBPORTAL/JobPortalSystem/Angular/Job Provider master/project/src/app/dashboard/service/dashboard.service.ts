import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(private http: HttpClient) { }
  
 CountOfJobs(): Observable<any> {
  return this.http.get(`${environment.baseurl}admin/GetJobCount`);
}

CountOfApplications(jobProviderId: string): Observable<any> {
  return this.http.get(`${environment.baseurl}job-provider/${jobProviderId}/getJobApplicants`);
}

CountOfInterviews(companyId: string): Observable<any> {
  return this.http.get(`${environment.baseurl}Interview/company/company-user/${companyId}/Interviewlist`);
}
}
