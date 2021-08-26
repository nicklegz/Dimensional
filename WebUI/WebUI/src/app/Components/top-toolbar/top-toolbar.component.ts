import { Component, Output, EventEmitter, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { LeftSidenavService } from 'src/app/Services/left-sidenav.service';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-top-toolbar',
  templateUrl: './top-toolbar.component.html',
  styleUrls: ['./top-toolbar.component.css']
})
export class TopToolbarComponent {

  public toggled: boolean = false;

  constructor(public router: Router, private navService: LeftSidenavService, public auth: AuthService, @Inject(DOCUMENT) public document: Document) {
  }

  toggleLeftSidenav(){
    this.navService.toggle()
    this.toggled = !this.toggled;
  }

}
