import { Component, OnInit } from '@angular/core';
import { dashboardService } from '../../services/dashboard.service';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-dashboard-home',
  templateUrl: './dashboard-home.component.html',
  styleUrls: ['./dashboard-home.component.css']
})
export class DashboardHomeComponent implements OnInit {
  totalJobsPosted:any= [];
  jobseekers:any=[];
  totalCompanies:any;
  totalJobProviders:any;
  chart:any;
  constructor(private dashboardService: dashboardService) { }


  ngOnInit(): void {
    this.getTotaljobsPosted();
    this.getTotaljobSeekers();
    this.getTotalcompanies();
    this.getTotalJobProviders();
    
  }
  // ngAfterViewInit(): void {
  //   this.createChart();
  // }

  getTotaljobsPosted(){
    this.dashboardService.getTotaljobsPosted().subscribe((response:{count:number}) => {

       this.totalJobsPosted= response.count;
      
    },
      error => {
        console.error('Error fetching total count', error);
      }
    );
  
  }
  getTotaljobSeekers() {
    this.dashboardService.getTotaljobSeekers().subscribe((result:any[]) => {

      console.log(result);

      this.jobseekers= result;
     
     
    },
      error => {
        console.error('Error fetching total count', error);
      }
    );
   
  }
  getTotalcompanies() {
    this.dashboardService.getTotalcompanies().subscribe((response: { count: number }) => {

      console.log(response);
      this.totalCompanies = response.count;
      
    },
      error => {
        console.error('Error fetching total count', error);
      }
    );
  }
  getTotalJobProviders() {
    this.dashboardService.getTotalJobProvider().subscribe((response: { count: number }) => {
      this.totalJobProviders = response.count;
      console.log("totalJobProviders:",this.totalJobProviders);
      this.createChart();
    },
      error => {
        console.error('Error fetching total count', error);
      }
    );
  }
  createChart() {
    const ctx = document.getElementById('myChart') as HTMLCanvasElement;
    const myChart = new Chart(ctx, {
      type: 'bar',
      data: {
        labels: ['JobsPosted', 'JobSeekers', 'Companies',"JobProviders"],
        datasets: [{
          label: 'Total Count',
          data: [
            this.totalJobsPosted,        // Assuming this.totalJobsPosted is an array
            this.jobseekers.length,             // Assuming this.jobseekers is an array
            this.totalCompanies,
            this.totalJobProviders
            
            // Assuming this.totalCompanies is a number
          ],
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
          ],
          borderWidth: 1,
          barThickness: 50
        }]
       
      },
      options: {
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });
    console.log( "jobs"+this.totalCompanies  );
   
  }

  single = [
    {
      name: 'Category 1',
      value: 40
    },
    {
      name: 'Category 2',
      value: 60
    },
  ];

  view: [number, number] = [700, 400];
  showLegend = true;
  explodeSlices = false;

}