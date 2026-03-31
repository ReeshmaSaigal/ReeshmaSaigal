import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/app/environment/environment';
import { Observable } from 'rxjs';
import { Breed } from '../model/breed';

@Injectable({
  providedIn: 'root'
})
export class BreedService {

  breedUrl=environment.apiUrl+'breed';
  constructor(private http:HttpClient) { }

  getBreed():Observable<any>{
    return this.http.get(this.breedUrl)
  }
  searchBreed(categoryId:string):Observable<any>{
    return  this.http.get(this.breedUrl+'/category/'+categoryId)
  }
}
