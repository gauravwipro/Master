import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
// Doctor component
import { FetchDoctorComponent } from './Doctors/fetchdoctor/fetchdoctor.component';
import { CreateDoctor } from './Doctors/adddoctor/adddoctor.component';
import { DoctorService } from './services/doctorservice.service';


import { DoctorRoutingModule } from '../admin/doctor-routing.module';
import { NgxPaginationModule } from 'ngx-pagination'; // <-- import the module
@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    DoctorRoutingModule,
    NgxPaginationModule
  ],
  declarations: [
    FetchDoctorComponent,
    CreateDoctor
  ],
  providers: [ DoctorService]
})
export class DoctorModule {
  constructor() {
    console.log('DoctorModule loaded.');
  }
} 
