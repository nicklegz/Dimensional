import { Component, ViewChild } from '@angular/core';
import { TopToolbarComponent } from '../top-toolbar/top-toolbar.component';


@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {

  username: string = "";
  password: string = "";

  @ViewChild(TopToolbarComponent) topToolbar: any;

  enabled: boolean | undefined;

  GetEnabled(){
    this.enabled = this.topToolbar.enabled
  }

  constructor() { }

  ngOnInit(): void {
  }

}
