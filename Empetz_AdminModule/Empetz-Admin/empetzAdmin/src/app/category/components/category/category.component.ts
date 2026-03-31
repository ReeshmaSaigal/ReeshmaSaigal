import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from '../../model/category';
import { CategoryService } from '../../service/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  isBreedFormVisible: boolean = false;
  addBreedForm!: FormGroup;
  categoryIdToAddBreed: string = '';



  categories: Category[] = [];
  categoryForm!: FormGroup;
  isFormVisible: boolean = false;
  // selectedFile: any | null = null;
  CategoryOption: Category[] = [];
  selectedCategory: string = '';
  updateCategoryForm!: FormGroup;
  updateselectedFile: File | null = null;
  isUpdateFormVisible: boolean = false; // Control visibility of the update form
  updateSelectedCategory!: Category;
  ImageFile: any;
  selectedFile!: File;
  base64Image: string | ArrayBuffer | null = null;
  constructor(private fb: FormBuilder, private service: CategoryService) { }

  ngOnInit(): void {
    // Initialize the form with reactive form controls
    this.categoryForm = this.fb.group({
      Name: ['', Validators.required],
      ImageFile: [null, Validators.required]
    });


    // ---------------------------------------------------------------------------

    // Initialize the form with form controls
    this.updateCategoryForm = this.fb.group({
      Name: ['', Validators.required], // Category name is required
      ImageFile: [null], // Image file (optional in case of no change)
    });

    // ---------------------------------------------------------------------------

    this.addBreedForm = this.fb.group({
      name: ['', Validators.required],
    });


    // ---------------------------------------------------------------------------

    this.getCategory();
  }

  // Method to toggle the form visibility
  toggleForm() {
    this.isFormVisible = true;
  }


  
  // Handle file selection and convert the image to base64
  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      this.selectedFile = file;  // Store the selected file
    }
  }
  onSubmit() {
    // if (this.categoryForm.invalid || !this.base64Image) {
    //   return;
    // }

    const formData = new FormData();
    formData.append('Name', this.categoryForm.get('Name')?.value);
    formData.append('ImageFile', this.selectedFile,this.selectedFile.name);
      alert(this.categoryForm.get('Name')?.value);  
   
    // Call the service to send the data to the backend
    this.service.addCategory(formData).subscribe(
     ( response:any) => {
        console.log('Category added successfully', response);
        // Reset form and file input after successful submission
        this.categoryForm.reset();
        // this.selectedFile = null;
        // this.base64Image = null;
      },
      error => {
        console.error('Error adding category', error);
      }
    );
  }

resetCategoryForm() {
  this.categoryForm.reset(); // Reset the form
  this.isFormVisible = false; // Hide the form
}

  // ---------------------------------------------------------------------------

  // Fetch categories from the service
  getCategory() {
    this.service.getCategory().subscribe(
      categories => {
        console.log(categories);
        this.categories = categories;
        this.CategoryOption = categories;
        console.log(this.categories)
      },
      error => {
        console.error('Error fetching categories', error);
      }
    );
  }
  // ----------------------------------------------------------------------------------------------
  //Search categories

  onCategoryChange(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedCategory = selectElement.value;
    console.log('Selected Category:', this.selectedCategory);
    if (this.selectedCategory === '') {
      this.getCategory();
    } else {
      this.service.searchCategory(this.selectedCategory).subscribe(category => {
        console.log(category);
        this.categories = [category];
        console.log(this.categories);
      })

    }

  }
  //------------------------------------------------------------------------------------------------ 
  // Show update form with pre-filled category data
  onUpdateClick(category: Category) {

    this.updateSelectedCategory = category; // Store the category to be updated
    this.isUpdateFormVisible = true; // Show the form
    this.updateCategoryForm.patchValue({
      Name: category.name,// Pre-fill the name
      ImageFile: category.imagePath
    });
  }

  // Reset the update form and hide it
  resetUpdateForm() {
    this.updateCategoryForm.reset(); // Reset the form
    this.updateselectedFile = null; // Reset the file selection
    this.isUpdateFormVisible = false; // Hide the form
  }


  // Handle file selection
  onFileSelectedToUpdate(event: any) {
    if (event.target.files && event.target.files.length > 0) {
      this.updateselectedFile = event.target.files[0]; // Assign the selected file
      console.log('Selected file:', this.updateselectedFile);
    }

  }


  // Handle form submission for update
  onUpdateSubmit() {
    if (!this.updateCategoryForm.valid) {
      console.error('Category name is missing!');
      return;
    }

    const formData = new FormData();
    formData.append('Name', this.updateCategoryForm.get('Name')?.value); // Add the updated name

    // Add the updated image if selected
    if (this.updateselectedFile) {
      formData.append('ImageFile', this.updateselectedFile); // Add the new image file
    }

    // Call the service method to update the category
    this.service.updateCategory(this.updateSelectedCategory.id, formData).subscribe(
      response => {
        console.log('Category updated successfully!', response);
        this.getCategory(); // Refresh the category list after updating
        this.resetUpdateForm(); // Reset the form and hide it
      },
      error => {
        console.error('Error updating category', error);
      }
    );
  }


  // ---------------------------------------------------------------------------

  onAddBreedClick(category: Category) {
    this.categoryIdToAddBreed = category.id;
    this.isBreedFormVisible = true;
  }

  onAddBreedSubmit() {
    const breedData = {
      name: this.addBreedForm.value.name,
      category: this.categoryIdToAddBreed
    }
    this.service.addBreed(breedData).subscribe(result => {
      console.log('Breed Added Successfully!', result)
      this.resetAddBreedForm(); // Reset the form and hide it
    },
      error => {
        console.error('Error Adding Breed', error);
      }
    )
  }
  resetAddBreedForm() {
    this.addBreedForm.reset(); // Reset the form
    this.isBreedFormVisible = false; // Hide the form
  }


}
