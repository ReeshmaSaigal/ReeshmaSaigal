import { Component,OnInit } from '@angular/core';
import { Companies } from '../../model/job.model';
import { jobService } from '../../service/jobService.service';



@Component({
  selector: 'app-providers-list',
  templateUrl: './providers-list.component.html',
  styleUrls: ['./providers-list.component.css']
})
export class ProvidersListComponent  implements OnInit {
  companies: Companies[] = [];
  searchTerm: string = '';

  constructor(private jobService: jobService) {}
  ngOnInit(): void {
 
    this.jobService.getCompanies().subscribe((result)=>{
      this.companies=result;
      console.log(this.companies);
      
  });
}
filterCompany() {
  this.jobService.filterJobs(this.searchTerm).subscribe((result)=>{
    this.companies=result;
  })
}
removeCompany(companyId:string){
  console.log(companyId);
this.jobService.removeCompany(companyId).subscribe((response)=>{
  console.log("Company Deleted",response);
  window.location.reload();
},
  error => {
    console.error('Error removing company', error);
  }
);
}

}

