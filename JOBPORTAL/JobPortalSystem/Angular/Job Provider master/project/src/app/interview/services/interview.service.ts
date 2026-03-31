import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Interview } from '../models/interview';
import { environment } from 'src/environments/environment';
import { EMPTY } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class InterviewService {
  baseurl=environment.baseurl;
  constructor(private http:HttpClient) { }

getInterviewList() {

  const companyUserId = localStorage.getItem("companyId"); // ✅ HARDCODED FOR NOW

  return this.http.get(
    `${this.baseurl}Interview/company/company-user/${companyUserId}/Interviewlist`
  );
}
scheduleInterview(companyUserId: string, payload: any) {
  return this.http.post(
    `${this.baseurl}Interview/company/company-user/${companyUserId}/Interview`,
    payload
  );
}
CancelInterview(id: string) {
  return this.http.delete(`${this.baseurl}interview/company/company-user/${id}/cancel`);
}
}
