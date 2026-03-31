import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/app/environment/environment';
import { Login } from '../model/login';
import { catchError, map, Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  loginUrl=environment.apiUrl+'user/login';
  private loggedIn = false;


  constructor(private http:HttpClient) { }

  isAuthenticated(): boolean {
    // Example check using a token in localStorage
    const token = localStorage.getItem('authToken');
    return !!token;
  }

  // Method to handle login
  login(credentials:any): Observable<any> {
    // Replace with your actual login API endpoint
    return this.http.post(this.loginUrl, credentials).pipe(
      map((response: any) => {
        // Store the token or user data
        if (response && response.token) {
          localStorage.setItem('authToken', response.token);
        }
        return response;
      }),
      catchError(error => {
        console.error('Login failed', error);
        return of(null);
      })
    );
  }

  // Method to logout
  logout(): void {
    localStorage.removeItem('authToken');
  }
  getToken():any{
    return localStorage.getItem('authToken');
  }
  

  isLoggedIn(): boolean {
    return this.loggedIn;
  }
}
