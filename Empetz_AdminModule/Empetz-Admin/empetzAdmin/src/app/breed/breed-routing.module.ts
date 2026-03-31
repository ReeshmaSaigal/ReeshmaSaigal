import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddBreedComponent } from './components/add-breed/add-breed.component';

const routes: Routes = [
  {path:'',component:AddBreedComponent},
  {path:'breed/:id',component:AddBreedComponent}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BreedRoutingModule { }
