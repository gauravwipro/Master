import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FetchDoctorComponent } from './Doctors/fetchdoctor/fetchdoctor.component';
import { CreateDoctor } from './Doctors/adddoctor/adddoctor.component';
import { AuthGuard } from '../app.routing';
const countryRoutes: Routes = [
  {
    path: '',
    component: FetchDoctorComponent,
    children: [
      { path: 'doctor', component: FetchDoctorComponent, canActivate: [AuthGuard], pathMatch: "full" },
    ]
  },
  {
    path: '',
    component: CreateDoctor,
    children: [
      { path: 'create-doctor', component: CreateDoctor, canActivate: [AuthGuard], pathMatch: "full" },
    ]
  },
  {
    path: '',
    component: CreateDoctor,
    children: [
      { path: 'doctor/edit/:id', component: CreateDoctor, canActivate: [AuthGuard], pathMatch: "full" }
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(countryRoutes)],
  exports: [RouterModule]
})
export class DoctorRoutingModule { } 
