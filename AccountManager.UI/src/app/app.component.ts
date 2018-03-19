import { Component, OnInit } from '@angular/core';
import { AccountService } from './services/account.service';

import 'rxjs/add/observable/throw';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  static currentUser:any;
  
  token:string = localStorage.getItem('token');
  
  constructor(private service: AccountService) {}

  ngOnInit() {
    if(this.token != null) {
      this.loadCurrectUser();
    }
  }

  logout() {
    this.token = null;
    AppComponent.currentUser = null;
    localStorage.removeItem('token');

    return false;
  }

  getCurrectUser() {
    return AppComponent.currentUser;
  }
 
  private loadCurrectUser() {
    this.service.getPersonalInfo(this.token).subscribe(user => {
      console.log(user);
      AppComponent.currentUser = user;
    }, 
    (e:any) => {
      this.token = null;
      localStorage.removeItem('token');
    });
  }
}
