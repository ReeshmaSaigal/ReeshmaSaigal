import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomeComponent } from './components/admin-home/admin-home.component';
import { AuthGuard } from '../core/auth.guard';
const routes: Routes = [{
  path:'',component:AdminHomeComponent,
  children:[

  {
    path: '',canActivate:[AuthGuard], loadChildren: () => import('../dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path: 'posts', loadChildren: () => import('../posts/posts.module').then(m => m.PostsModule)
  },
  {
    path: 'breed', loadChildren: () => import('../breed/breed.module').then(m => m.BreedModule)
  },
  {
    path: 'category', loadChildren: () => import('../category/category.module').then(m => m.CategoryModule)
  },
  {
    path: 'users', loadChildren: () => import('../users/users.module').then(m => m.UsersModule)
  },
  {
    path: 'notification', loadChildren: () => import('../notifications/notifications.module').then(m => m.NotificationsModule)
  },
  {
    path:'locations',loadChildren:()=>import('../location/location.module').then(m=>m.LocationModule)
  }
  ]
}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
