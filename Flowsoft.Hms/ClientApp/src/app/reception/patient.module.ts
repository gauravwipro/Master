import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { FetchPatientComponent } from './Patient/fetchpatient/fetchpatient.component';
import { CreatePatient } from './Patient/addpatient/addpatient.component';
import { PatientService } from './services/patientservice.service';
import { OpdService } from './services/opdservice.service';
import { PatientRoutingModule } from '../reception/patient-routing.module';
import { NgxPaginationModule } from 'ngx-pagination'; // <-- import the module
import { MatTabsModule } from '@angular/material/tabs';
import { MatDatepickerModule, MatNativeDateModule } from '@angular/material';
@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    PatientRoutingModule,
    NgxPaginationModule,
    MatTabsModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  declarations: [
    CreatePatient,
    FetchPatientComponent
  ],
  providers: [PatientService, MatDatepickerModule, OpdService]
})
export class PatientModule {
  constructor() {
    console.log('PatientModule loaded.');
  }
} 
