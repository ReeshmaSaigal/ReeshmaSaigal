import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserLogin } from '../models/UserLogin';
import { environment } from 'src/environments/environments';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  
  getAllUsers() {
    return this.http.get<any[]>(environment.baseurl + '/users')
  }

 signUp(user: any) {
    return this.http.post(environment.baseurl +'job-seeker/signup', user)
  }

  verifyEmail(jobSeekerSignupRequestId:any){
    
    return this.http.get(environment.baseurl +'job-seeker/signup/'+jobSeekerSignupRequestId+'/verify-email')
  }

  getUserProfileById(id: any):Observable<any>{
  
    return this.http.get<any>(environment.baseurl+id+'/profiledetails')
  }
  signIn(user:UserLogin){

    return this.http.post(environment.baseurl + 'job-seeker/login', user)
  }
  getToken(): any {
    return localStorage.getItem('accessToken') // Return an empty string if the token is null or undefined
  }


 setNewPassword(password: string, signupId: string) {
  return this.http.post(
    `${environment.baseurl}job-seeker/signup/${signupId}/set-password`,
    `"${password}"`,
    {
      headers: {
        'Content-Type': 'application/json'
      },
      responseType: 'text' // ✅ THIS IS THE FIX
    }
  );
}
    
}
