import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { HeaderComponent } from './header/header.component';
import { SearchbarComponent } from './searchbar/searchbar.component';



@NgModule({
  declarations: [
    SidebarComponent,
    HeaderComponent,
    SearchbarComponent,
    HeaderComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    SidebarComponent,
    HeaderComponent,
    SearchbarComponent
  ]
})
export class SharedModule { }
