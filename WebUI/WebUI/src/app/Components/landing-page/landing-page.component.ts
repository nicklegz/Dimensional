import { Component, ElementRef, ViewChild } from '@angular/core';

export interface Service{
  service: string;
  image: string;
}


@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent {

  isActive = false;

  services: Service[] = [
    {service: '3D Printing Services', image: "/assets/Images/3D Printing Services.jpg"},
    {service: 'Product Design', image:"/assets/Images/Dremel Printer.jpg"},
    {service: 'Consulting', image: "/assets/Images/Prusa Mini Printer.jpg"},
    {service: 'Procurement', image: "/assets/Images/Maker Bot.jpg"}
  ];

}
