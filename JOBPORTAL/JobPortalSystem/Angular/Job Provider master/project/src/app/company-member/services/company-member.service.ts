import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { companyMember, listMember } from '../Models/company-member';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyMemberService {
  baseurl = environment.baseurl;
  jobProviderId=localStorage.getItem('jobProviderId');
  companyId=localStorage.getItem('companyId');


  constructor(private http: HttpClient) {}

  addCompanyMember(data:companyMember):Observable<any>{
     return this.http.post<any>(this.baseurl+'Company/job-provider/company/'+this.companyId+'/addcompanymember',data);
   }

   listCompanyMember(): Observable<listMember[]> {
    return this.http.get<listMember[]>(this.baseurl + 'Company/job-provider/company/' + this.companyId + '/listcompanymember');
  }

  removeCompanyMember(companyMemberId: string): Observable<any> {
    return this.http.delete<any>(this.baseurl + 'Company/job-provider/company/' + companyMemberId + '/RemoveCompanyMember/');
  }







}
