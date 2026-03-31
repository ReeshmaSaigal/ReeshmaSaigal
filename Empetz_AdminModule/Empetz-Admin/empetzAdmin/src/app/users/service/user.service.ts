import { Injectable } from '@angular/core';
import { environment } from 'src/app/environment/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  

  constructor(private http:HttpClient) { }

  userUrl=environment.apiUrl;

  getAllUsers():Observable<any>{
    return this.http.get(this.userUrl+'admin/publicusers');
  }
  searchUsers(query: string):Observable<any> {
    return this.http.get(this.userUrl + 'admin/search-user?searchTerm=' + query);
  }
  blockUser(id:string):Observable<any>{
    
    return this.http.post(` ${this.userUrl}admin/block-user/${id}`,id)
  }
}
