import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../models/user';

@Injectable()
export class UserService {
  myAppUrl: string = "";

  constructor(private _http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.myAppUrl = _baseUrl;
  }
  getAll() {
    return this._http.get<User[]>(this.myAppUrl + 'api/users');
  }

  getById(id: number) {
    return this._http.get<User>(this.myAppUrl +'/users/${id}');
  }
}
