import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { SkillRoutingModule } from './skill-routing.module';
import { SkillHomeComponent } from './Components/skill-home/skill-home.component';
import { SkillAddComponent } from './Components/skill-add/skill-add.component';
import { FormsModule } from '@angular/forms';
import { SkillViewComponent } from './Components/skill-view/skill-view.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [
    SkillHomeComponent,
    SkillAddComponent,
    SkillViewComponent,
    
  ],
  imports: [
    CommonModule,
    SkillRoutingModule,
    FormsModule,
    ReactiveFormsModule,
   MatInputModule ,
    MatFormFieldModule ,
    MatButtonModule,
    MatIconModule
  ] })
export class SkillModule { }
