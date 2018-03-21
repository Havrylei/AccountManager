import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  currentUser: any;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.currentUser = this.route.snapshot.data.user;
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUser = null;
  }
}
