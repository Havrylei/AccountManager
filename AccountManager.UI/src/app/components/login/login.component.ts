import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { AppComponent } from '../../app.component';
import { LoginError } from '../../core/models/user/login_error';
import { LoginUser } from '../../core/models/user/login_user';

import 'rxjs/add/observable/throw';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})

export class LoginComponent implements OnInit {  
  errors: LoginError = <LoginError>{};
  user: LoginUser = <LoginUser>{};

  constructor(private service: AccountService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    if(localStorage.getItem('token') != null) {
      this.router.navigate(['/']);
    }
  }

  authenticate() {
    this.service.authenticate(this.user)
      .subscribe(
        (token: string) => { 
          localStorage.setItem('token', token); 
          this.service.getPersonalInfo(token).subscribe(user => {
            this.service.user$.next(user);
          });         

          this.router.navigate(['/']);      
        }, 
        (e:any) => {
          this.errors = e;
        });     

    return false;
  } 
}

