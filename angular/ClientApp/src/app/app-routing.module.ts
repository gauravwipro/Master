import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'department',
    loadChildren: './admin/department.module#DepartmentModule'
  },
  {
    path: 'doctor',
    loadChildren: './admin/doctor.module#DoctorModule'
  },
  {
    path: 'state',
    loadChildren: './admin/state.module#StateModule'
  },
  {
    path: 'patient',
    loadChildren: './reception/patient.module#PatientModule'
  },
  {
    path: 'opdDetails',
    loadChildren: './doctor/doctor.module#DoctorModule'
  },
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
