import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BreedRoutingModule } from './breed-routing.module';
import { AddBreedComponent } from './components/add-breed/add-breed.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AddBreedComponent
  ],
  imports: [
    CommonModule,
    BreedRoutingModule,
    FormsModule,ReactiveFormsModule
  ]
})
export class BreedModule { }
