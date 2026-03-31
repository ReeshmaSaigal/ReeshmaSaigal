import { Component } from '@angular/core';
import { LocationService } from '../../services/location.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Location } from '../../model/location';

@Component({
  selector: 'app-locations',
  templateUrl: './locations.component.html',
  styleUrls: ['./locations.component.css']
})
export class LocationsComponent {

 
   
    selectedLocation: string = '';
    filteredLocation: Location[]=[];
    isVisibleAddForm:boolean=false;
    locations: Location[] = [];
    addLocationForm!: FormGroup;
 
  
    constructor(private locationService: LocationService, private fb: FormBuilder){}
  
    ngOnInit(): void {
      // Initialize the form with reactive form controls
      this.addLocationForm = this.fb.group({
        name: ['', Validators.required]
      });
      // this.getLocation();
    }
    // getLocation() {
    //   this.locationService.addLocation(this.addLocationForm.value).subscribe(location => {
    //     this.locations= location;
    //     this.filteredLocation=location;
    //     console.log(this.locations);
    //   })
    // }
    // getCategory() {
    //   this.locationService.getLocation().subscribe(
    //     location => {
    //       console.log(location);
  
    //       console.log(this.locations)
    //     },
    //     error => {
    //       console.error('Error fetching Locations', error);
    //     }
    //   );
    // }
    //
    // onSearchLocation(event: Event) {
    //   const searchTerm=(event.target as HTMLInputElement).value;
  
    //   if (searchTerm) {
    //     // Filter the breeds that contain the search value (case-insensitive)
    //     this.locations = this.filteredLocation.filter(location =>
    //       location.name.toLowerCase().includes(searchTerm.toLowerCase())
    //     );
    //   } else {
    //     // If search input is cleared, display all breeds
    //     this.locations= this.filteredLocation ;
    //   }
    // }
    onAddSubmit() {
      const locationData = {
        name: this.addLocationForm.value.name,
      }
      this.locationService.addLocation(this.addLocationForm.value).subscribe(result => {
        console.log('Location Added Successfully!', result)
        this.resetAddForm(); // Reset the form and hide it
        this.isVisibleAddForm =false;
      },
        (error: any) => {
          console.error('Error Adding Location', error);
        }
      )
    }
    toggleForm() {
      this.isVisibleAddForm = !this.isVisibleAddForm;
    }
    resetAddForm() {
      this.addLocationForm.reset(); // Reset the form
      this.isVisibleAddForm = false; // Hide the form
    }
  }
  

