import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  currentUser: any;

  constructor(private service: AccountService, private route: ActivatedRoute) { 
    this.service.user$.subscribe((user) => {
      this.currentUser = user;
    });
  }

  ngOnInit() {
    this.currentUser = this.route.snapshot.data.user;
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUser = null;
  }
}
