import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Skill } from '../../model/skill';
import { SkillService } from '../../service/skill.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-skill-add',
  templateUrl: './skill-add.component.html',
  styleUrls: ['./skill-add.component.css']
})
export class SkillAddComponent {

  skillForm: FormGroup;
  successMessage!: string;
  errorMessage: string='';
  constructor(
    private formBuilder: FormBuilder,
    private skillService: SkillService,
    private router: Router
  ) {
    this.skillForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

onSubmit() {
  if (this.skillForm.valid) {
    const skillData = this.skillForm.value;

    this.skillService.addSkill(skillData).subscribe(
      (response) => {

        // ✅ Proper reset
        this.skillForm.reset();

        this.successMessage = 'Skill added successfully!';
        // this.errorMessage = '';

        console.log('Skill added successfully:', response);

        setTimeout(() => {
          this.successMessage = '';
        }, 3000);
      },
      (error) => {
        console.log(error);
        
        this.errorMessage = 'Failed to add skill';
        this.successMessage = '';
      }
    );
  }
}
  navigateToSkillsView() {
    // Navigate to the 'viewSkill' route
    this.router.navigate(['/admin-home/skill/viewSkill']);
  }
}