import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

const BASE_URL:string = 'http://localhost:5000/api';

@Injectable()
export class AccountService {
  
  constructor(public http:Http) { 
    
  }

  authenticate(login:string, password:string): Observable<string> {
    return this.http.post(BASE_URL + '/Account/Token', { 'login': login, 'password': password })
      .map(res => res.text())
      .catch(e => Observable.throw(e.json()));
  }

  registrate(user:RegistrateUser) {
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

export interface Gender {
  ID:number,
  Name:string
}

export interface Country {
  ID:number,
  Name:string
}

export interface RegistrateUser {
  login:string;
  email:string,
  password:string;
  confirm:string;
  firstName:string;
  genderID:number;
  countryID: number;
  birthDate:Date;
}