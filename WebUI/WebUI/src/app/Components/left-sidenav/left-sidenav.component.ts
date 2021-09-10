import { FocusMonitor } from '@angular/cdk/a11y';
import { DOCUMENT } from '@angular/common';
import { AfterViewInit, Component, Inject, ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { AuthService } from '@auth0/auth0-angular';
import { LeftSidenavService } from 'src/app/Services/left-sidenav.service';

@Component({
  selector: 'app-left-sidenav',
  templateUrl: './left-sidenav.component.html',
  styleUrls: ['./left-sidenav.component.css']
})
export class LeftSidenavComponent implements AfterViewInit{

  @ViewChild('drawer') public leftDrawer: MatDrawer;

  constructor(private navService: LeftSidenavService, public auth: AuthService, @Inject(DOCUMENT) public document: Document){

  }

  ngAfterViewInit() {
    this.navService.setSidenav(this.leftDrawer);
  }

}
