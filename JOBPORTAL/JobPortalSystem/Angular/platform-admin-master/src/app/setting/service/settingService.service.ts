import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { profile } from '../model/settings.model';


@Injectable({
  providedIn: 'root'
})
export class settingService {
  private profileUrl = 'http://localhost:3000/profile'; // Change the URL if your JSON Server is running on a different port

  constructor(private http: HttpClient) { }

  getProfile(): Observable<profile[]> {
    return this.http.get<profile[]>(this.profileUrl);
  }
//update the profile data in json server

updateProfile(ProfileData:any){
  const id = 1;
  return this.http.patch<any>(this.profileUrl+'/'+id,ProfileData)
}
}




