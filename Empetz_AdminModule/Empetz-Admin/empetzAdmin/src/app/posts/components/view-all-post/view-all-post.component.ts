import { Component, Output, Input, EventEmitter } from '@angular/core';
import { PostService } from '../../service/post.service';
import { Post } from '../../model/model';
import { Router } from '@angular/router';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { environment } from 'src/app/environment/environment';

@Component({
  selector: 'app-view-all-post',
  templateUrl: './view-all-post.component.html',
  styleUrls: ['./view-all-post.component.css']
})
export class ViewAllPostComponent {

  
  constructor(private postService: PostService, private router: Router) {}
  filteredPosts: Post[] = [];
  imageUrl=`http://192.168.0.103/resources/` 
  posts: Post[] = [];
  ngOnInit(): void {
    this.getAllPost();
  }

 
  getAllPost() {
    this.postService.getAllPosts().subscribe(posts => {
      console.log(posts);
  
  this.posts=posts;
      console.log(this.posts);
  
      // Assign transformed posts to filteredPosts
      this.filteredPosts = this.posts;
      console.log(this.filteredPosts);
    });
  }
  
  // Helper function to extract the image name from the URL
  getImageName(url: string): string {
    // Use split to get the last part after the last '/'
    const segments = url.split('/');
    return segments.pop() || ''; // Return the last segment which is the image name
  }
   filterPosts(events: Event): any {

    const query = (events.target as HTMLInputElement).value;
    this.postService.searchPet(query).subscribe(pet => {
      console.log (pet);
      this.filteredPosts = pet;
    })
    if(query==''||null){
      this.getAllPost();
    }

  }
  deletePost(petId:string){
    this.postService.deletePet(petId).subscribe(pet=>{
      alert(`Post with ID ${petId}  Deleted Succussfully...`);
    })
  }

  showDetails(id: string) {
    this.router.navigate(['posts/post-details', id]);
  }
}
