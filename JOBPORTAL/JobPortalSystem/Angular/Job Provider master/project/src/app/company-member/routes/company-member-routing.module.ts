import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MemberHomeComponent } from '../components/member-home/member-home.component';
import { MemberAddComponent } from '../components/member-add/member-add.component';
import { MemberListComponent } from '../components/member-list/member-list.component';

const routes: Routes = [
  {
    path: '', component: MemberHomeComponent,
    children: [{
      path: 'add', component: MemberAddComponent
    },
  {
    path:'list',component:MemberListComponent
  }]

  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyMemberRoutingModule { }
