import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retryWhen } from 'rxjs';
import { Breed } from 'src/app/breed/model/breed';
import { environment } from 'src/app/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

categoryUrl=environment.apiUrl+'category';
breedUrl=environment.apiUrl+'breed'

  constructor(private http:HttpClient) { }
  getCategory():Observable<any>{
   return this.http.get(this.categoryUrl)
  }
  addCategory(data: any):Observable<any>{
    // const headers = {
    //   'Name': data.Name,
     
    // };

return this.http.post(this.categoryUrl,data);
  }
  searchCategory(id:string):Observable<any>{
    return this.http.get(this.categoryUrl+'/'+id)
  }
  updateCategory(id:string,data:FormData):Observable<any>{
    
    return this.http.patch(this.categoryUrl+'/'+id,data)
  }
  addBreed(breedData:Breed):Observable<any>{
    return this.http.post(this.breedUrl,breedData)
  }
 
}
