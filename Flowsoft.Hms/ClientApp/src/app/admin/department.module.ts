import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { FetchDepartmentComponent } from './Department/fetchdepartment/fetchdepartment.component';
import { CreateDepartment } from './Department/adddepartment/adddepartment.component';
import { DepartmentService } from './services/departmentservice.service';
import { DepartmentRoutingModule } from '../admin/department-routing.module';
import { NgxPaginationModule } from 'ngx-pagination'; // <-- import the module
@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    DepartmentRoutingModule,
    NgxPaginationModule
  ],
  declarations: [
    CreateDepartment,
    FetchDepartmentComponent   
  ],
  providers: [DepartmentService]
})
export class DepartmentModule {
  constructor() {
    console.log('DepartmentModule loaded.');
  }
} 
