import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { map, filter, catchError, mergeMap, retry } from 'rxjs/operators';
import { DepartmentData } from '../models/DepartmentData'


@Injectable()
export class DepartmentService {
  myAppUrl: string = "";

  constructor(private _http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.myAppUrl = _baseUrl;
  }
  getDepartments(): Observable<DepartmentData[]> {
    return this._http.get<DepartmentData[]>(this.myAppUrl + 'api/Department/Index');
  }

  getDepartmentById(id: number): Observable<DepartmentData> {
    return this._http.get<DepartmentData>(this.myAppUrl + "api/Department/Details/" + id);
  }

  saveDepartment(doctor): Observable<DepartmentData> {
    return this._http.post<DepartmentData>(this.myAppUrl + 'api/Department/Create', doctor);
  }

  updateDepartment(doctor): Observable<DepartmentData> {
    return this._http.put<DepartmentData>(this.myAppUrl + 'api/Department/Edit', doctor);
  }

  deleteDepartment(id): Observable<DepartmentData> {
    return this._http.delete<DepartmentData>(this.myAppUrl + "api/Department/Delete/" + id);
  }


}
