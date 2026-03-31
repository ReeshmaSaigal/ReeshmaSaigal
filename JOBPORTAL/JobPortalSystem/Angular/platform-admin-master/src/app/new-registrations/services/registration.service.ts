import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Registration } from '../model/registration.model';



@Injectable({
  providedIn: 'root',
})
export class RegistrationService {
  private apiUrl = 'http://localhost:3000/registrations'; 

  constructor(private http: HttpClient) {}

  getRegistrations(): Observable<Registration[]> {
    return this.http.get<Registration[]>(this.apiUrl).pipe(
      map((data: any[]) => {
        return data.map((item) => new Registration(item));
      })
    );
  }
}
