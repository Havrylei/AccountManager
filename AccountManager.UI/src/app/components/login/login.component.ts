import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { AppComponent } from '../../app.component';

import 'rxjs/add/observable/throw';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})

export class LoginComponent implements OnInit {  
  errors: LoginError = <LoginError>{};

  constructor(private service: AccountService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    if(localStorage.getItem('token') != null) {
      this.router.navigate(['/']);
    }
  }

  authenticate(login: string, password: string) {
    this.service.authenticate(login, password)
      .subscribe(
        (token: string) => { 
          localStorage.setItem('token', token); 

          this.route.parent.snapshot.data.user = this.service.getPersonalInfo(localStorage.getItem('token'));

          this.router.navigate(['/']);      
        }, 
        (e:any) => {
          this.errors = e;
        });     

    return false;
  } 
}

interface LoginError {
  notice:string;
  login:string;
  password:string;
}