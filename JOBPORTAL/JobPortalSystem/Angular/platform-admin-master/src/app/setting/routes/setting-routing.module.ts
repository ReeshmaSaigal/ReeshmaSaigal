import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SettingHomeComponent } from '../components/setting-home/setting-home.component';
import { SettingUpdateComponent } from '../components/setting-update/setting-update.component';

const routes: Routes = [
//   {
//   path:'',component:SettingHomeComponent,
//   children:[
//     {
//       path:'update',component:SettingUpdateComponent
//     }
//   ]
// }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingRoutingModule { }
