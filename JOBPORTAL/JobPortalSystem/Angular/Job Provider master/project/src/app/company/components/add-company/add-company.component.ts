import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyService } from '../../services/company.service';

@Component({
  selector: 'app-add-company',
  templateUrl: './add-company.component.html',
  styleUrls: ['./add-company.component.css']
})
export class AddCompanyComponent implements OnInit {

  companyForm!: FormGroup;
  industries: any[] = [];
  locations: any[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private companyService: CompanyService
  ) {}

  ngOnInit(): void {
    this.initForm();
    this.loadIndustries();
    this.loadLocations();
  }

  // ✅ FORM INIT
  initForm() {
    this.companyForm = this.formBuilder.group({
      legalName: ['', Validators.required],
      summary: ['', Validators.required],
      industryId: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required , Validators.pattern('^[6-9][0-9]{9}$')],
      website: ['', Validators.required,Validators.pattern('^(https?:\\/\\/)?([\\w\\-])+\\.([a-zA-Z]{2,})(\\/[\\w\\-._~:/?#[\\]@!$&\'()*+,;=]*)?$')],
      address: ['', Validators.required],
      location: ['', Validators.required] // ✅ matches HTML
    });
  }
  submitted = false;
  showToast = false;
  showErrorToast=false;
get f() {
  return this.companyForm.controls;
}
  // ✅ SUBMIT
  addCompany() {
 this.submitted = true;
    if (this.companyForm.invalid) {
      this.companyForm.markAllAsTouched();
       this.showErrorToast = true;

    setTimeout(() => {
      this.showErrorToast = false;
    }, 3000);

      return;
    }

    const formValues = this.companyForm.value;

    console.log("Sending:", formValues);

    this.companyService.addCompany(formValues).subscribe({
      next: (response: any) => {
        console.log("Response:", response);

        // ✅ handle different response structures
        const companyId = response.id || response.data?.id;

        if (companyId) {
          localStorage.setItem('companyId', companyId);

  // ✅ Show Toast
  this.showToast = true;

  // ✅ Hide toast after 3 sec
  setTimeout(() => {
    this.showToast = false;
  }, 3000);

  // ✅ Reset form
  this.companyForm.reset();
  this.submitted = false;
         
        } else {
          console.error("Company ID not found in response");
        }
      },
      error: (err) => {
        console.error("Error:", err);
      }
    });
  }

  // ✅ LOAD INDUSTRIES
  loadIndustries() {
    this.companyService.getIndustries().subscribe({
      next: (data: any[]) => {
        console.log("Industries:", data);
        this.industries = data;
      },
      error: (err) => console.error(err)
    });
  }

  // ✅ LOAD LOCATIONS
  loadLocations() {
    this.companyService.getLocations().subscribe({
      next: (data: any[]) => {
        console.log("Locations:", data);
        this.locations = data;
      },
      error: (err) => console.error(err)
    });
  }

}