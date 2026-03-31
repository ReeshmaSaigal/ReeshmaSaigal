import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { data } from '../model/job-seeker-list.model';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private DataUrl = environment.baseurl+'admin/GetJobSeekers';// Assuming the JSON file is in the "assets" folder

  constructor(private http: HttpClient) { }

  getData(): Observable<data[]> {
    return this.http.get<data[]>(this.DataUrl);
  }
}
