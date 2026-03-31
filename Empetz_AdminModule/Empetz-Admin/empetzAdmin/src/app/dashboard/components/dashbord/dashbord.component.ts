import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../../service/dashboard.service';

@Component({
  selector: 'app-dashbord',
  templateUrl: './dashbord.component.html',
  styleUrls: ['./dashbord.component.css']
})
export class DashbordComponent implements OnInit {
  totalUsers: number = 0;
  weeklyUsers: number = 0;
  monthlyUsers: number = 0;
  yearlyUsers: number = 0;

  constructor(private service:DashboardService) { }

  ngOnInit(): void {
    // Replace these with actual data fetching logic
    this.total_users() ;
    this.weekly_users ();
    this.monthly_users();
    this.yearly_users();
  }
  total_users(){
    this.service.totalUsers().subscribe((users:any)=>{
      this.totalUsers=users;
    })
  }
  weekly_users(){
    this.service.weekly_registered_users().subscribe((users:any)=>{
      this.weeklyUsers=users;
    })
  }
  monthly_users(){
    this.service.monthly_registered_users().subscribe((users:any)=>{
      this.monthlyUsers=users;
    })
  }
  yearly_users(){
    this.service.yearly_registered_users().subscribe((users:any)=>{
      this.yearlyUsers=users;
    })
  }
}
