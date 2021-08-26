import { Injectable } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';

@Injectable()
export class LeftSidenavService {

  private leftDrawer: MatDrawer;

	public setSidenav(drawer: MatDrawer) {
		this.leftDrawer = drawer;
	}

	public toggle(): void {
		this.leftDrawer.toggle();
	}

}
