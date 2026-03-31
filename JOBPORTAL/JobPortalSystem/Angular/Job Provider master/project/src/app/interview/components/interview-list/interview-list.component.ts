import { Component } from '@angular/core';
import { InterviewService } from '../../services/interview.service';
import { Interview } from '../../models/interview';

@Component({
  selector: 'app-interview-list',
  templateUrl: './interview-list.component.html',
  styleUrls: ['./interview-list.component.css']
})
export class InterviewListComponent {
  interviewList :Interview[]=[];
  showSuccessToast =false;
  showErrorToast=false;
  constructor(private interviewService:InterviewService){}
  
  
  ngOnInit()
  {
    this.getInterviewList();
  }
  getInterviewList() {
  this.interviewService.getInterviewList().subscribe({
    next: (res: any) => {
      console.log("INTERVIEW LIST:", res);
      this.interviewList = res;
    },
    error: (err) => {
      console.error("LIST ERROR:", err);
    }
  });
}
CancelInterview(id: string) {
  this.interviewService.CancelInterview(id).subscribe({
    next: (res) => {
     this.getInterviewList();
      // ✅ Success Toast
      this.showSuccessToast = true;
      setTimeout(() => this.showSuccessToast = false, 3000);
    },

    error: (err) => {
      console.error("Error:", err);

      // ❌ Error Toast
      this.showErrorToast = true;
      setTimeout(() => this.showErrorToast = false, 3000);
    }
  });
}

}
