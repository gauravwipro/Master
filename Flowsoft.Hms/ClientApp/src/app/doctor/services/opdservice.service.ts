import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OpdMonthlyAppointmentData } from '../models/OpdMonthlyAppointmentData';
import { OpdDailyAppointmentData, OpdDoctorUpdateData } from '../models/OpdDailyAppointmentData';
import { OpdHistoryData } from '../models/OpdShowData';

@Injectable()
export class OpdService {
  myAppUrl: string = "";

  constructor(private _http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.myAppUrl = _baseUrl;
  }
  getMonthlyAppointments(id: number): Observable<OpdMonthlyAppointmentData[]> {
    return this._http.get<OpdMonthlyAppointmentData[]>(this.myAppUrl + 'api/Appointment/Monthly/' + id);
  }
  getDailyAppointments(id: number, opdDate: Date): Observable<OpdDailyAppointmentData[]> {
    return this._http.get<OpdDailyAppointmentData[]>(this.myAppUrl + 'api/Appointment/Daily/' + id + "/" + opdDate);
  }
  save(opdDoctor): Observable<OpdDoctorUpdateData> {
    return this._http.put<OpdDoctorUpdateData>(this.myAppUrl + 'api/Appointment/Edit', opdDoctor);
  }
  getDeatil(id: number): Observable<OpdDoctorUpdateData> {
    return this._http.get<OpdDoctorUpdateData>(this.myAppUrl + "api/Appointment/Details/" + id);
  }

  getPatientHistory(id: number): Observable<OpdHistoryData[]> {
    return this._http.get<OpdHistoryData[]>(this.myAppUrl + "api/Appointment/patient/Details/" + id);
  }

}
