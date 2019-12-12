import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FetchPatientComponent } from './Patient/fetchpatient/fetchpatient.component';
import { CreatePatient } from './Patient/addpatient/addpatient.component';
import { AuthGuard } from '../app.routing';
const countryRoutes: Routes = [
  {
    path: '',
    component: FetchPatientComponent,
    children: [
      { path: 'patient', component: FetchPatientComponent, canActivate: [AuthGuard], pathMatch: "full" },
    ]
  },
  {
    path: '',
    component: CreatePatient,
    children: [
      { path: 'create-patient', component: CreatePatient, canActivate: [AuthGuard], pathMatch: "full" },
    ]
  },
  {
    path: '',
    component: CreatePatient,
    children: [
      { path: 'patient/edit/:id', component: CreatePatient, canActivate: [AuthGuard], pathMatch: "full" }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(countryRoutes)],
  exports: [RouterModule]
})
export class PatientRoutingModule { } 
