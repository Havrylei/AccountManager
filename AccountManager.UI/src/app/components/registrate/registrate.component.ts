import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { RegistrateUser, Gender, Country } from '../../services/account.service';

import 'rxjs/add/observable/throw';

@Component({
  selector: 'app-registrate',
  templateUrl: './registrate.component.html',
  styleUrls: ['./registrate.component.sass']
})
export class RegistrateComponent implements OnInit {
  errors: RegistrateError = <RegistrateError>{};
  genders: Gender[];
  countries: Country[];

  constructor(private service: AccountService, private router: Router) { }

  ngOnInit() {
    this.service.getGenders().subscribe((genders) => {
      this.genders = genders;
    });

    this.service.getCountries().subscribe((countries) => {
      this.countries = countries;
    })
  }

  registrate(login: string, email: string, password: string, confirm: string, firstName: string, genderID: number, countryID: number, birthDate: Date) {
    let user: RegistrateUser = {
      login,
      email,
      password,
      confirm,
      firstName,
      birthDate,
      genderID,
      countryID
    };

    console.log(user);

    this.service.registrate(user).subscribe(() => {
      this.router.navigate(['login']);   
    }, 
    (e:any) => {
      this.errors = e;
    });

    return false;
  }
}

interface RegistrateError {
  login: string;
  email: string;
  password: string;
  confirm: string;
  genderid: string;
  countryid:string;
  birthdate: string;
  firstname: string;
}