import { Component } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { register } from '../../models/register';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  show:boolean=true;
  constructor(private authService: AuthService,private router:Router) { }

  signUp(signUpForm:NgForm){
    console.log(signUpForm.value);
    this.authService.signUp(signUpForm.value).subscribe(
      (response)=>{
        console.log(response);
       }
    )
    this.show =! this.show;
  }

}