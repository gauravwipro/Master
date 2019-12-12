import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FetchDepartmentComponent } from './Department/fetchdepartment/fetchdepartment.component';
import { CreateDepartment } from './Department/adddepartment/adddepartment.component';
import { AuthGuard } from '../app.routing';
const countryRoutes: Routes = [
  {
    path: '',
    component: FetchDepartmentComponent,
    children: [
      { path: 'department', component: FetchDepartmentComponent, canActivate: [AuthGuard], pathMatch: "full" },
    ]
  },
  {
    path: '',
    component: CreateDepartment,
    children: [
      { path: 'create-department', component: CreateDepartment, canActivate: [AuthGuard], pathMatch: "full" },
    ]
  },
  {
    path: '',
    component: CreateDepartment,
    children: [
      { path: 'department/edit/:id', component: CreateDepartment, canActivate: [AuthGuard], pathMatch: "full" }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(countryRoutes)],
  exports: [RouterModule]
})
export class DepartmentRoutingModule { } 
