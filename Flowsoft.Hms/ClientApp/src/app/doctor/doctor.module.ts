import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import { FetchOpdComponent } from './Opd/fetchopd/fetchopd.component';
import { FetchOpdDetailComponent, EditOpdDetail, PatientOpdHistory } from './OpdDetail/fetchopddetail/fetchopddetail.component';

import { OpdService } from './services/opdservice.service';
import { DoctorRoutingModule } from '../doctor/doctor-routing.module';
import { NgxPaginationModule } from 'ngx-pagination'; // <-- import the module
import { MatTabsModule } from '@angular/material/tabs';
import {
  MatDatepickerModule, MatNativeDateModule, MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  MatRippleModule,

} from '@angular/material';
import { MatDialogModule } from '@angular/material/dialog';
import { FullCalendarModule } from '@fullcalendar/angular';
@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    DoctorRoutingModule,
    NgxPaginationModule,
    MatTabsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    FullCalendarModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
    MatDialogModule,
    FormsModule,
  ],
  exports: [
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
  ],
  declarations: [
    FetchOpdDetailComponent,
    FetchOpdComponent, EditOpdDetail, PatientOpdHistory],
  entryComponents: [EditOpdDetail, PatientOpdHistory],
  providers: [MatDatepickerModule, OpdService]
})
export class DoctorModule {
  constructor() {
    console.log('DoctorModule loaded.');
  }
} 
