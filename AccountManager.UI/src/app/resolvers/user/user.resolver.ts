import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class UserResolver implements Resolve<any> {
  constructor(private service: AccountService) {}

  resolve() : Observable<any> {
    if(localStorage.getItem('token') != null) {
      return this.service.getPersonalInfo(localStorage.getItem('token'));
    }else {
      return null;
    }
  }
}
