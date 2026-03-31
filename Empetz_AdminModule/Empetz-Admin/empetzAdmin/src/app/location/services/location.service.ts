import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  locationUrl = environment.apiUrl + 'admin/location';

  constructor(private http: HttpClient) { }

  addLocation(data: any): Observable<any> {
    console.log (data)
    return this.http.post(this.locationUrl,data);
  }
  getLocation():Observable<any>{
    return this.http.get(this.locationUrl);
  }
}
