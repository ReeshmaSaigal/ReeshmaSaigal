import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JobseekerSidenavComponent } from './components/jobseeker-sidenav/jobseeker-sidenav.component';
import { FooterComponent } from './components/footer/footer.component';
import { RouterModule } from '@angular/router';
import { JobseekerHeaderComponent } from './components/jobseeker-header/jobseeker-header.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    JobseekerSidenavComponent,
    FooterComponent,
    JobseekerHeaderComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  exports:[JobseekerSidenavComponent,FooterComponent,JobseekerHeaderComponent, FormsModule]
})
export class SharedModule { }
