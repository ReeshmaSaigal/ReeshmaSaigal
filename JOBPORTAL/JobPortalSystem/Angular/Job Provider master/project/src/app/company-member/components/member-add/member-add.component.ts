import { Component, OnInit } from '@angular/core';
import { CompanyMemberService } from '../../services/company-member.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-member-add',
  templateUrl: './member-add.component.html',
  styleUrls: ['./member-add.component.css']
})
export class MemberAddComponent implements OnInit {

  companyMemberForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private companymemberservice: CompanyMemberService
  ) { }
  submitted = false;
  showSuccessToast = false;
  showErrorToast = false;

  get f() {
    return this.companyMemberForm.controls;
  }
  ngOnInit(): void {
    this.companyMemberForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      userName: ['', Validators.required],
      phone: ['', Validators.required, Validators.pattern('^[0-9]{10}$')],
      password: ['', Validators.required,Validators.minLength(6)],
    });
  }

  addCompanyMember() {
    this.submitted = true;
    if (this.companyMemberForm.valid) {
      const formValues = this.companyMemberForm.value;
      this.companymemberservice.addCompanyMember(formValues).subscribe(
        (response) => {
          // alert('Company member added successfully!');

          this.showSuccessToast = true;
          setTimeout(() => this.showSuccessToast = false, 3000);

          this.companyMemberForm.reset();
          this.submitted = false;
        },
        (error) => {
          this.showErrorToast = true;
          setTimeout(() => this.showErrorToast = false, 3000);
          console.error('Error adding company member:', error);
        }
      );
    }
  }
}