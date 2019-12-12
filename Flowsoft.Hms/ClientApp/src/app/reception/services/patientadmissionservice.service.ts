import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';
import { Router } from '@angular/router';
import { map, filter, catchError, mergeMap, retry } from 'rxjs/operators';
import { PatientAdmissionData } from '../models/PatientAdmissionData';
import { DropDownValues } from '../models/DropDownValues';



@Injectable()
export class PatientAdmissionService {
  myAppUrl: string = "";

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }
  getAll(): Observable<PatientAdmissionData[]> {
    return this._http.get<PatientAdmissionData[]>(this.myAppUrl + 'api/PatientAdmission/Index');
  }

  get(id: number): Observable<PatientAdmissionData> {
    return this._http.get<PatientAdmissionData>(this.myAppUrl + "api/PatientAdmission/Details/" + id);
  }

  save(patientAdmission): Observable<PatientAdmissionData> {
    return this._http.post<PatientAdmissionData>(this.myAppUrl + 'api/PatientAdmission/Create', patientAdmission);
  }

  update(patientAdmission): Observable<PatientAdmissionData> {
    return this._http.put<PatientAdmissionData>(this.myAppUrl + 'api/PatientAdmission/Edit', patientAdmission);
  }

  delete(id): Observable<PatientAdmissionData> {
    return this._http.delete<PatientAdmissionData>(this.myAppUrl + "api/PatientAdmission/Delete/" + id);
  }
}
