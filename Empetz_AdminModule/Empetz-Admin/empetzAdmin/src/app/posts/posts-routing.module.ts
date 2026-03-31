import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewAllPostComponent } from './components/view-all-post/view-all-post.component';
import { PostDetailsComponent } from './components/post-details/post-details.component';

const routes: Routes = [
  {
    path:'',component:ViewAllPostComponent
  },
  {path:'viewpost',component:ViewAllPostComponent},
  { path: 'post-details/:id', component: PostDetailsComponent },
  { path: '', redirectTo: '/view-all-posts', pathMatch: 'full' }
 
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PostsRoutingModule { }
