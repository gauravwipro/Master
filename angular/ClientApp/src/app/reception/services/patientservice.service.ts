import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { map, filter, catchError, mergeMap, retry } from 'rxjs/operators';
import { PatientData } from '../models/PatientData';
import { OpdData } from '../models/OpdData';
import { DropDownValues } from '../models/DropDownValues';
import { DoctorData } from '../../admin/models/DoctorData';
import { DepartmentData } from '../../admin/models/DepartmentData';

@Injectable()
export class PatientService {
  myAppUrl: string = "";

  constructor(private _http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.myAppUrl = _baseUrl;
  }
  getAll(): Observable<PatientData[]> {
    return this._http.get<PatientData[]>(this.myAppUrl + 'api/Patient/Index');
  }

  get(id: number): Observable<PatientData> {
    return this._http.get<PatientData>(this.myAppUrl + "api/Patient/Details/" + id);
  }

  save(patient): Observable<PatientData> {
    return this._http.post<PatientData>(this.myAppUrl + 'api/Patient/Create', patient);
  }

  update(patient): Observable<PatientData> {
    return this._http.put<PatientData>(this.myAppUrl + 'api/Patient/Edit', patient);

  }

  delete(id): Observable<PatientData> {
    return this._http.delete<PatientData>(this.myAppUrl + "api/Patient/Delete/" + id);
  }

  saveOpd(opd): Observable<OpdData> {
    return this._http.post<OpdData>(this.myAppUrl + 'api/Patient/Create', opd);
  }

  getStateList(): Observable<DropDownValues[]> {
    return this._http.get<DropDownValues[]>(this.myAppUrl + 'api/Doctor/GetStateList');
  }



  getDepartmentList(): Observable<DepartmentData[]> {
    return this._http.get<DepartmentData[]>(this.myAppUrl + 'api/Doctor/GetDepartmentList');
  }

  getDoctorList(id): Observable<DoctorData[]> {
    return this._http.get<DoctorData[]>(this.myAppUrl + 'api/Doctor/GetDoctorsList/' + id);
  }

  getGenderList(): Observable<DropDownValues[]> {
    return this._http.get<DropDownValues[]>(this.myAppUrl + 'api/Doctor/GetGenderList');
  }
}
