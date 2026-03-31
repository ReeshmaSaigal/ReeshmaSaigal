import { Component } from '@angular/core';
import { UserService } from '../../service/user.service';
import { User } from '../../model/user';
import { Block } from '@angular/compiler';

@Component({
  selector: 'app-block-users',
  templateUrl: './block-users.component.html',
  styleUrls: ['./block-users.component.css']
})
export class BlockUsersComponent {
  userService: any;
  constructor(private service:UserService){
    this.getBlockUser();
  }
 
blockedUsers:User[]=[];



  getBlockUser() {
    this.service.getAllUsers().subscribe(user=>{

      this.blockedUsers=user.filter((user:any)=>user.status=='Blocked')
      console.log(this.blockedUsers);
    })
  }
}


