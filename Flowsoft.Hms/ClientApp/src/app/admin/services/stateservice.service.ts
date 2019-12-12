import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, filter, catchError, mergeMap, retry, debounce } from 'rxjs/operators';
import { StateData } from '../models/StateData'

@Injectable()
export class StateService {
  myAppUrl: string = "";

  constructor(private _http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.myAppUrl = _baseUrl;
  }
  getAll(): Observable<StateData[]> {
    return this._http.get<StateData[]>(this.myAppUrl + 'api/State/Index');
  }

  get(id: number): Observable<StateData> {
    return this._http.get<StateData>(this.myAppUrl + "api/State/Details/" + id);
  }

  save(state): Observable<StateData> {
    return this._http.post<StateData>(this.myAppUrl + 'api/State/Create', state);
  }

  update(state): Observable<StateData> {
    return this._http.put<StateData>(this.myAppUrl + 'api/State/Edit', state);
  }

  delete(id): Observable<StateData> {
    return this._http.delete<StateData>(this.myAppUrl + "api/State/Delete/" + id);
  }

}
