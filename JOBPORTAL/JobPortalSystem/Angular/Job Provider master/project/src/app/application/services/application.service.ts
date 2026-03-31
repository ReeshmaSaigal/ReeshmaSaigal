import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Application } from '../models/application';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {

  private baseUrl = `${environment.baseurl}job-provider`;

  constructor(private http: HttpClient) {}

  // ✅ Get Applicants
  getApplicants(jobProviderId: string): Observable<Application[]> {

    const token = localStorage.getItem('token');

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token || ''}`
    });

    return this.http.get<Application[]>(
      `${this.baseUrl}/${jobProviderId}/getJobApplicants`,
      { headers }
    );
  }

  getProviderProfile(jobProviderId: string) {

  const token = localStorage.getItem('token');

  return this.http.get<any>(
    `${environment.baseurl}job-provider/${jobProviderId}/getCompany`,
    {
      headers: {
        Authorization: `Bearer ${token}`
      }
    }
  );
}

}