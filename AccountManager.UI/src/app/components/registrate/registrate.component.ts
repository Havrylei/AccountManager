import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { RegistrateUser } from '../../core/models/user/registrate_user';
import { RegistrateError } from '../../core/models/user/registrate_error';
import { Gender } from '../../core/models/user/gender';
import { Country } from '../../core/models/user/country';

import 'rxjs/add/observable/throw';

@Component({
  selector: 'app-registrate',
  templateUrl: './registrate.component.html',
  styleUrls: ['./registrate.component.sass']
})
export class RegistrateComponent implements OnInit {
  errors: RegistrateError = <RegistrateError>{};
  user: RegistrateUser = <RegistrateUser>{};
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

  registrate() {
    this.service.registrate(this.user).subscribe(() => {
      this.router.navigate(['login']);   
    }, 
    (e:any) => {
      this.errors = e;
    });

    return false;
  }
}

