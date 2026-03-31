import { Injectable } from '@angular/core';
import { environment } from 'src/app/environment/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  url = environment.apiUrl;

  constructor(private http: HttpClient) { }
  
  totalUsers(): Observable<any> {
    return this.http.get(this.url + 'admin/total-users');
  }
  weekly_registered_users(): Observable<any> {
    return this.http.get(this.url + 'admin/weekly-registered-users');
  }
  monthly_registered_users(): Observable<any> {
    return this.http.get(this.url + 'admin/monthly-registered-users');
  }
  yearly_registered_users(): Observable<any> {
    return this.http.get(this.url + 'admin/yearly-registered-users');
  }
}
