import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JobProvidersHomeComponent } from './components/job-providers-home/job-providers-home.component';
import { ProvidersListComponent } from './components/providers-list/providers-list.component';
import { JobProvidersRoutingModule } from './routes/job-providers-routing.module';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
// import { SearchbarComponent } from '../shared/searchbar/searchbar.component';


@NgModule({
  declarations: [
    JobProvidersHomeComponent,
    ProvidersListComponent
    
  ],
  imports: [
    CommonModule,
    RouterModule,
    JobProvidersRoutingModule,
    SharedModule,
    FormsModule
  ]
})
export class JobProvidersModule { }
