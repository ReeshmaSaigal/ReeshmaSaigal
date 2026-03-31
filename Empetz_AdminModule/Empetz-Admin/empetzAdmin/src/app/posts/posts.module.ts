import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PostsRoutingModule } from './posts-routing.module';
import { ViewAllPostComponent } from './components/view-all-post/view-all-post.component';
import { FormsModule } from '@angular/forms';
import { PostDetailsComponent } from './components/post-details/post-details.component';


@NgModule({
  declarations: [
    ViewAllPostComponent,
    PostDetailsComponent,
  ],
  imports: [
    CommonModule,
    PostsRoutingModule,
    FormsModule
  ]
})
export class PostsModule { }
