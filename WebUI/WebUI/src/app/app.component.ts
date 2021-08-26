import { Component, Input, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { LeftSidenavService } from './Services/left-sidenav.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Dimensional';

  @ViewChild('leftSidenav') public sidenav: MatSidenav;

  constructor(private sidenavService: LeftSidenavService, public router: Router, public auth: AuthService){

  }
}
