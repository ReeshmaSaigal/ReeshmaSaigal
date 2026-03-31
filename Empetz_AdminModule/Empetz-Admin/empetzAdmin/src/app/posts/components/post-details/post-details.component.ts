import { Component, Input } from '@angular/core';
import { PostService } from '../../service/post.service';
import { Post } from '../../model/model';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.css']
})
export class PostDetailsComponent {
  constructor(private service: PostService,private route:ActivatedRoute,private router:Router) { }

  posts: Post[] = [];
  pet: any;
postId!:any;
  ngOnInit(): void {
    this.postId = this.route.snapshot.paramMap.get('id');
    this.service.getAllPosts().subscribe(posts => {
      this.posts = posts;
      this.pet=this.posts.filter(post=>post.id===this.postId);
      console.log(this.pet)
    })

  }
  backPost(): void {
     this.router.navigate(['posts/viewpost'])
  }

 
}