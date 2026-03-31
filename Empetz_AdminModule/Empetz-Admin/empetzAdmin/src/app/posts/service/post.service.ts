import { Injectable } from '@angular/core';
import { environment } from 'src/app/environment/environment';
import { HttpClient } from '@angular/common/http';
import {  Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Post } from '../model/model';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';


@Injectable({
  providedIn: 'root'
})
export class PostService {


  constructor(private http:HttpClient,private sanitizer: DomSanitizer) { }

  getUrl=environment.apiUrl+'Admin/posts';
deleteUrl=environment.apiUrl+'Admin/pets';
searchUrl=environment.apiUrl+'Admin/search-pet?searchTerm=';

getAllPosts(): Observable<any[]> {
  return this.http.get<any[]>(this.getUrl);
  // return this.http.get<any[]>(this.getUrl).pipe(
  //   map(posts => {
  //     return posts.map(post => {
  //       // Sanitize the imagePath for safe use in the DOM
  //       post.imagePath = this.sanitizer.bypassSecurityTrustUrl(post.imagePath) as SafeUrl;
  //       return post;
  //     });
  //   })
  // );
}

  deletePet(id:string):Observable<any>{
    return this.http.delete(`${this.deleteUrl}+/${id}`);
  }
  searchPet(searchTerm:string):Observable<any>{
    return this.http.get(this.searchUrl+searchTerm)
  }
  
}