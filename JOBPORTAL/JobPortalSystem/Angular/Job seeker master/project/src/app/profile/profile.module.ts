import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfileRoutingModule } from './profile-routing.module';
import { ProfileComponent } from './profile.component';
import { SharedModule } from "../shared/shared.module";
import { ProfileInfoComponent } from './components/profile-info/profile-info.component';
import { AddResumeComponent } from './components/add-resume/add-resume.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { AddNewProfileComponent } from './components/add-new-profile/add-new-profile.component';
import { AddProfileComponent } from './components/add-profile/add-profile.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
    declarations: [
        ProfileComponent,
        ProfileInfoComponent,
        AddResumeComponent,
        AddNewProfileComponent,
        AddProfileComponent
    ],
    imports: [
        CommonModule,
        ProfileRoutingModule,
        SharedModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatCardModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatIconModule,
        ReactiveFormsModule
    ]
})
export class ProfileModule { }
