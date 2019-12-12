import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { map, filter, catchError, mergeMap, retry } from 'rxjs/operators';
import { DoctorData } from '../models/DoctorData';
import { StateData } from '../models/StateData';
import { DropDownValues } from '../models/DropDownValues';


@Injectable()
export class DoctorService {
  myAppUrl: string = "";

  constructor(private _http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.myAppUrl = _baseUrl;
  }

  getStateList(): Observable<DropDownValues[]> {
    return this._http.get<DropDownValues[]>(this.myAppUrl + 'api/Doctor/GetStateList');
  }
  getDepartmentList(): Observable<DropDownValues[]> {
    return this._http.get<DropDownValues[]>(this.myAppUrl + 'api/Doctor/GetDepartmentList');
  }
  getGenderList(): Observable<DropDownValues[]> {
    return this._http.get<DropDownValues[]>(this.myAppUrl + 'api/Doctor/GetGenderList');
  }
  getDoctors(): Observable<DoctorData[]> {
    return this._http.get<DoctorData[]>(this.myAppUrl + 'api/Doctor/Index');
  }
  getDoctorById(id: number): Observable<DoctorData> {
    return this._http.get<DoctorData>(this.myAppUrl + "api/Doctor/Details/" + id);
  }
  saveDoctor(doctor): Observable<DoctorData> {
    return this._http.post<DoctorData>(this.myAppUrl + 'api/Doctor/Create', doctor);
  }
  updateDoctor(doctor): Observable<DoctorData> {
    return this._http.put<DoctorData>(this.myAppUrl + 'api/Doctor/Edit', doctor);
  }
  deleteDoctor(id): Observable<DoctorData> {
    return this._http.delete<DoctorData>(this.myAppUrl + "api/Doctor/Delete/" + id);
  }
}
