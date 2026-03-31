import { Component } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { Breed } from '../../model/breed';
import { BreedService } from '../../service/breed.service';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from 'src/app/category/service/category.service';
import { Category } from 'src/app/category/model/category';

@Component({
  selector: 'app-add-breed',
  templateUrl: './add-breed.component.html',
  styleUrls: ['./add-breed.component.css']
})
export class AddBreedComponent {
 
  selectedCategory: string = '';
  filteredBreeds: Breed[]=[];
  isVisibleAddForm:boolean=false;
  
 
  CategoryOption: Category[] = [];
  categories: Category[] = [];

  breeds: Breed[] = [];
  isAddFormVisible: boolean = false;
  addBreedForm!: FormGroup;

  constructor(private breedService: BreedService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private categoryService: CategoryService) {}

  ngOnInit(): void {
    // Initialize the form with reactive form controls
    this.addBreedForm = this.fb.group({
      name: ['', Validators.required],
      category:['',Validators.required]
    });
    this.getCategory();
    this.getBreed();
  }
  getBreed() {
    this.breedService.getBreed().subscribe(breeds => {
      this.breeds = breeds;
      this.filteredBreeds=breeds;
      console.log(breeds);
    })
  }
  getCategory() {
    this.categoryService.getCategory().subscribe(
      categories => {
        console.log(categories);

        this.CategoryOption = categories;
        console.log(this.categories)
      },
      error => {
        console.error('Error fetching categories', error);
      }
    );
  }
  onCategoryChange(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedCategory = selectElement.value;
    console.log('Selected Category:', this.selectedCategory);
    if (this.selectedCategory == '') {
      this.getBreed();
    } else {
      this.breedService.searchBreed(this.selectedCategory).subscribe(breed => {
        console.log(breed);
        this.breeds = breed;
        console.log(this.breeds);
      })

    }

  }
  onSearchBreed(event: Event) {
    const searchTerm=(event.target as HTMLInputElement).value;

    if (searchTerm) {
      // Filter the breeds that contain the search value (case-insensitive)
      this.breeds = this.filteredBreeds.filter(breed =>
        breed.name.toLowerCase().includes(searchTerm.toLowerCase())
      );
    } else {
      // If search input is cleared, display all breeds
      this.breeds= this.filteredBreeds ;
    }
  }
  onAddSubmit() {
    const breedData = {
      name: this.addBreedForm.value.name,
      category: this.addBreedForm.value.category
    }
    this.categoryService.addBreed(breedData).subscribe(result => {
      console.log('Breed Added Successfully!', result)
      this.resetAddForm(); // Reset the form and hide it
      this.isVisibleAddForm =false;
    },
      error => {
        console.error('Error Adding Breed', error);
      }
    )
  }
  toggleForm() {
    this.isVisibleAddForm = !this.isVisibleAddForm;
  }
  resetAddForm() {
    this.addBreedForm.reset(); // Reset the form
    this.isVisibleAddForm = false; // Hide the form
  }
}
