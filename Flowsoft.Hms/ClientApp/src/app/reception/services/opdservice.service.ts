import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { map, filter, catchError, mergeMap, retry } from 'rxjs/operators';
import { OpdData } from '../models/OpdData';
import { OpdShowData } from '../models/OpdShowData';
import { DropDownValues } from '../models/DropDownValues';

@Injectable()
export class OpdService {
  myAppUrl: string = "";

  constructor(private _http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.myAppUrl = _baseUrl;
  }
  getAll(): Observable<OpdData[]> {
    return this._http.get<OpdData[]>(this.myAppUrl + 'api/Opd/Index');
  }

  get(id: number): Observable<OpdData> {
    return this._http.get<OpdData>(this.myAppUrl + "api/Opd/Details/" + id);
  }
  getTodayAppointment(id: number): Observable<OpdShowData[]> {
    return this._http.get<OpdShowData[]>(this.myAppUrl + "api/Opd/Details/GetTodayAppointment/" + id);
  }

  save(patient): Observable<OpdData> {
    return this._http.post<OpdData>(this.myAppUrl + 'api/Opd/Create', patient);
  }

  update(patient): Observable<OpdData> {
    return this._http.put<OpdData>(this.myAppUrl + 'api/Opd/Edit', patient);

  }

  delete(id): Observable<OpdData> {
    return this._http.delete<OpdData>(this.myAppUrl + "api/Opd/Delete/" + id);
  }

  saveOpd(opd): Observable<OpdData> {
    return this._http.post<OpdData>(this.myAppUrl + 'api/Opd/Create', opd);
  }

}
