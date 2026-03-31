import { Component, OnInit } from '@angular/core';
import { UserService } from '../../service/user.service';
import { User } from '../../model/user';

@Component({
  selector: 'app-userdetails',
  templateUrl: './userdetails.component.html',
  styleUrls: ['./userdetails.component.css']
})
export class UserdetailsComponent implements OnInit {
  users: any[] = [];
  searchUserTerm: string = '';
  fileteredUsers: any;

  constructor(private userService: UserService) { }

  // Mock data for users


  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getAllUsers().subscribe(users => {
      this.users = users;
      console.log(users);
      this.fileteredUsers = users;
    })

  }

  searchUsers(events: Event): void {
    const query = (events.target as HTMLInputElement).value;;
    this.userService.searchUsers(query).subscribe(users => {
      console.log(users);
      this.fileteredUsers = users;
    })
  }
  toggleBlock(user: any): void {
    // Determine the new status based on the current status
    const newStatus = user.status === 'Active' ? 'blocked' : 'Active';
  
    // Confirm the action with the user
    if (confirm(`Are you sure you want to ${newStatus === 'blocked' ? 'block' : 'unblock'} this user?`)) {
      // Update the user status locally
      user.status = newStatus;
  
      // Optionally, send a request to update the status on the server
      this.userService.blockUser(user.id).subscribe(
        (response) => {
          console.log(response); // Handle the plain text response here
          alert(`User ${newStatus === 'blocked' ? 'unblocked' : 'blocked'} successfully!`);
          this.loadUsers(); // Reload the users after the change
          console.log(this.fileteredUsers)
        },
        (error) => {
          console.error('Error:', error);
        }
      );
    }
  }
  

}
