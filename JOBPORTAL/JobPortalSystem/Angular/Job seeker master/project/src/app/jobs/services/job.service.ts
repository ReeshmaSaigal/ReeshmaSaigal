import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { forkJoin, mergeMap } from 'rxjs';

import { job } from '../models/job';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private http:HttpClient) { }
   jobSeekerId=sessionStorage.getItem('jobSeekerId');
   getJobs<response>(page: number, limit: number, query?: string){
    let params = new HttpParams()
    .set('page', page.toString())
    .set('limit', limit.toString());

     // If a query is provided, add it to the parameters
    //  if (query) {
    //   params = params.set('search', query);
    // }
    // return this.http.get(environment.baseurl +'/jp/api/v1/jobs',{params})
    return this.http.get(environment.baseurl+'jobs')
  }

  getAppliedJobs() {
    return this.http.get<any[]>(environment.baseurl +'job-seeker/'+this.jobSeekerId+'/job-application')
    
  }
unSaveJob(jobId: string) {
  const userId = sessionStorage.getItem('jobSeekerId');

  return this.http.delete(
    `${environment.baseurl}job-seeker/remove-saved-job?seekerId=${userId}&jobId=${jobId}`,
    { responseType: 'text' } // ✅ IMPORTANT
  );
}
getSavedJobs(userId: any) {
  return this.http.get(
    `${environment.baseurl}job-seeker/${userId}/savedjobs`
  );
}
  getJobsById(id: string) {
    return this.http.get<any[]>(environment.baseurl +'/jobs/'+id)
  }
  applyJob(jobId: any, resumeId: any, coverLetter: string, jobTitle: string) {

  const body = {
    resumeId: resumeId,
    coverLetter: coverLetter,
    jobTitle: jobTitle   // 🔥 REQUIRED
  };

  return this.http.post<any>(
    `${environment.baseurl}job-seeker/job-application/${jobId}`,
    body
  );
}
 saveJob(id: any) {
  return this.http.post(
    `${environment.baseurl}job-seeker/SaveJob/${id}`,
    {},
    { responseType: 'text' }  // ✅ IMPORTANT
  );
}
  cancelJob(JobApplicationId:any){
   return this.http.delete<any>(environment.baseurl +'job-seeker/'+this.jobSeekerId+'/job-application/'+JobApplicationId+'/cancel');
  }
 
}
