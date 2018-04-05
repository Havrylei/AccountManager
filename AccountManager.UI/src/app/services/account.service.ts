import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from "rxjs/Subject";
import { RegistrateUser } from '../core/models/user/registrate_user';
import { LoginUser } from '../core/models/user/login_user';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

const BASE_URL:string = 'http://localhost:5000/api';

@Injectable()
export class AccountService {
  public user$ = new Subject();

  constructor(private http:Http) { 
    
  }

  authenticate(user: LoginUser): Observable<string> {
    return this.http.post(BASE_URL + '/Account/Token', user)
      .map(res => res.text())
      .catch(e => Observable.throw(e.json()));
  }

  registrate(user: RegistrateUser) {
    return this.http.post(BASE_URL + '/Account', user)
      .catch(e => Observable.throw(e.json()));
  }

  getPersonalInfo(token:string): Observable<any> {
    let headers = new Headers();
    headers.append('Authorization', 'Bearer ' + token);

    let requestOptions = new RequestOptions({headers});

    return this.http.get(BASE_URL + '/Account/Personal', requestOptions)
      .map(res => res.json())
      .catch(e => Observable.throw(e.json()));
  }

  getGenders() {
    return this.http.get(BASE_URL + '/Gender')
      .map(res => res.json())
      .catch(e => Observable.throw(e.json()));
  }

  getCountries() {
    return this.http.get(BASE_URL + '/Country')
      .map(res => res.json())
      .catch(e => Observable.throw(e.json()));
  }
}



