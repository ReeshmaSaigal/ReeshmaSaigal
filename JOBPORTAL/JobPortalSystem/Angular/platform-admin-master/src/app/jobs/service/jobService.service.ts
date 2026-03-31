
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Jobs } from '../model/job.model';
import { environment } from 'src/environments/environments';


@Injectable({
  providedIn: 'root'
})
export class jobService {
  private jobsUrl = environment.baseurl+`alljobs`; // Change the URL if your JSON Server is running on a different port.
private jobFilterUrl=environment.baseurl=`admin/jobsName`;
  constructor(private http: HttpClient) { }

  getJobs(): Observable<Jobs[]> {
    return this.http.get<Jobs[]>(this.jobsUrl);
  }

  filterJobs(searchTerm: string): Observable<Jobs[]> {
    return this.http.get<Jobs[]>(this.jobFilterUrl+`?Title=${searchTerm}`);
  }
  
}