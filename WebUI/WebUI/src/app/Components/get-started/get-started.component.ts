import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

export interface Choice{
  buttonText: string;
  text: string;
  type: string;
  image: string;
}

@Component({
  selector: 'app-get-started',
  templateUrl: './get-started.component.html',
  styleUrls: ['./get-started.component.css']
})
export class GetStartedComponent {

  constructor(public auth: AuthService){}

  isActive = false;

  consume: Choice = {buttonText: 'Create an Account', text: 'Consumers of a service can upload an STL or VRML file to be 3D printed.', type:"Consume", image:"/assets/Images/test.jpg"}
  create: Choice = {buttonText: 'Browse the Marketplace', text: 'Creators of a service can post details about their printer and materials to the Dimensional Marketplace.', type: "Browse the Marketplace", image: "/assets/Images/test 2.jpg"}

}
