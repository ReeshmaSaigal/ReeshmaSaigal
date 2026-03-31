import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environments';
import { Observable } from 'rxjs';
import { skill } from '../models/profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) {}

  private jobseekerId = sessionStorage.getItem('jobSeekerId');

  // =========================
  // PROFILE
  // =========================

  getProfile(): Observable<any> {
    return this.http.get(
      `${environment.baseurl}${this.jobseekerId}/profile`
    );
  }

  getAllProfile(): Observable<any> {
    return this.http.get(
      `${environment.baseurl}GetJobSeekerProfile/${this.jobseekerId}`
    );
  }

  getUserProfileById(id: any): Observable<any> {
    return this.http.get(
      `${environment.baseurl}${id}/profiledetails`
    );
  }

  addNewProfile(data: any): Observable<any> {
  return this.http.post(
    `${environment.baseurl}AddProfile`,
    data,
    { responseType: 'text' }   // ✅ FIX HERE
  );
}

  // =========================
  // RESUME
  // =========================

  uploadCV(
    profileId: any,
    profileName: string,
    profileSummary: string,
    formData: FormData
  ): Observable<any> {

    const title = 'cv';

    return this.http.post(
      `${environment.baseurl}job-seeker/upload-resume?jobSeekerId=${this.jobseekerId}&profileId=${profileId}&profileName=${profileName || ''}&profileSummary=${profileSummary || ''}&title=${title}`,
      formData   // ✅ DO NOT ADD HEADERS
    );
  }

  getResume(profileId: any): Observable<any[]> {
    return this.http.get<any[]>(
      `${environment.baseurl}job-seeker/getResume/${profileId}`
    );
  }

  // =========================
  // SKILLS
  // =========================

  getAllSkill(): Observable<any[]> {
    return this.http.get<any[]>(
      `${environment.baseurl}skills`
    );
  }

  getSkillByUser(profileId: any): Observable<skill[]> {
  return this.http.get<skill[]>(
    `${environment.baseurl}${this.jobseekerId}/profile/${profileId}/skills`
  );
}

  addSkill(skillIds: any[], profileId: any): Observable<any> {
    return this.http.post(
      `${environment.baseurl}${this.jobseekerId}/profile/${profileId}/skills`,
      skillIds
    );
  }

  // =========================
  // QUALIFICATION
  // =========================

  // ✅ Correct based on Swagger (NO jobseekerId here)
getQualification(profileId: any): Observable<any[]> {
  return this.http.get<any[]>(
    `https://localhost:7056/profile/${profileId}/Qualification`
  );
}

  addQualification(name: any, description: any, profileId: any) {
  const data = { name, description };

  return this.http.post(
    `${environment.baseurl}${this.jobseekerId}/profile/${profileId}/Qualification`,
    data
  );
}

  // =========================
  // EXPERIENCE
  // =========================

  // ⚠️ IMPORTANT: backend typo = Experince
 getExperience(profileId: any): Observable<any[]> {
  return this.http.get<any[]>(
    `${environment.baseurl}${this.jobseekerId}/profile/${profileId}/Experince`
  );
}
  addExperience(experience: any, profileId: any): Observable<any> {
    return this.http.post(
      `${environment.baseurl}${this.jobseekerId}/profile/${profileId}/Experience`,
      experience
    );
  }

  // =========================
  // UPDATE PROFILE
  // =========================

  updateJobSeekerProfile(values: any): Observable<any> {
    return this.http.patch(
      `${environment.baseurl}JobSeekerProfileUpdate`,
      values
    );
  }

}