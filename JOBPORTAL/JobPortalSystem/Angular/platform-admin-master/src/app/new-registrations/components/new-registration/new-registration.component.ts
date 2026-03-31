import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Registration } from '../../model/registration.model';
import { RegistrationService } from '../../services/registration.service';

@Component({
  selector: 'app-new-registration',
  templateUrl: './new-registration.component.html',
  styleUrls: ['./new-registration.component.css']
})
export class NewRegistrationComponent implements OnInit {

  registrations: Registration[] = [];
  filteredRegistrations: Registration[] = []; 

  constructor(private registrationService: RegistrationService) {}

  ngOnInit(): void {
    this.registrationService.getRegistrations().subscribe(
      (registrations) => {
        this.registrations = registrations;
        this.filteredRegistrations = registrations; // Initialize the filteredRegistrations with all data initially
      },
      (error) => {
        console.error('Error fetching registrations:', error);
      }
    );
  }

  toggleCheckbox(registration: Registration): void {
    registration.checkbox = !registration.checkbox;
  }
  
  changeStatus(registration: Registration): void {
    if (registration.status === 'Approved') {
      registration.status = 'Pending';
    } else {
      registration.status = 'Approved';
    }
  }

  filterData(status: string): void {
    if (status === 'All') {
      this.filteredRegistrations = this.registrations; // Show all data
    } else {
      this.filteredRegistrations = this.registrations.filter(
        (reg) => reg.status === status
      ); // Filter based on the selected status
    }
  }
}
