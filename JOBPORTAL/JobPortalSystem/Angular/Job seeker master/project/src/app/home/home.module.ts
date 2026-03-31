import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { HomeNavComponent } from './components/home-nav/home-nav.component';
import { SharedModule } from '../shared/shared.module';
import { ExploreCategoryComponent } from './components/explore-category/explore-category.component';


@NgModule({
  declarations: [
    HomeComponent,
    HomeNavComponent,
    ExploreCategoryComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule
  ]
})
export class HomeModule { }
