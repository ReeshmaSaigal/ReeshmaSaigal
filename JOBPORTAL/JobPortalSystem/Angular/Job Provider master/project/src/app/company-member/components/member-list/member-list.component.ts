import { Component, OnInit } from '@angular/core';
import { CompanyMemberService } from '../../services/company-member.service';
import { listMember } from '../../Models/company-member';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  companyId: string;
  companyMembers: listMember[] = [];

  constructor(private companyMemberService: CompanyMemberService) {}

  ngOnInit() {
    this.companyId = this.companyMemberService.companyId;
    this.listCompanyMember();
  }

  listCompanyMember() {
    this.companyMemberService.listCompanyMember().subscribe((data: listMember[]) => {
      this.companyMembers = data;
      console.log(this.companyMembers);
      
    });
  }

  removeCompanyMember(memberId: any) {
    const confirmation = window.confirm('Are you sure you want to proceed?');
    if (confirmation) {
      this.companyMemberService.removeCompanyMember(memberId).subscribe(response => {
        console.log(response);
        const message = response.message;
        if (message === 'deleted') {
          alert('Member deleted successfully.');
          this.listCompanyMember();
        } else {
          alert('Failed to delete member.');
        }
      });
    }
  }  
}
