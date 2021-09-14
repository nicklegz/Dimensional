import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Inject, AfterViewInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';

export interface FileData{
  name: string;
  uploaded: string;
  checked: boolean;
}

@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrls: ['./my-account.component.css']
})

export class MyAccountComponent implements AfterViewInit {

  constructor(private http: HttpClient, public auth: AuthService, @Inject(DOCUMENT) public document: Document) { }

  fileName = "";
  formData = new FormData();
  checked = false;

  //dummy data replace with http to backend
  listOfFiles: FileData[] = [
    {name: "hello.txt", uploaded: "Sep 15, 2020", checked: false},
    {name: "world.txt", uploaded: "Nov 15, 2020", checked: false},
    {name: "ok.txt", uploaded: "Jan 15, 2020", checked: false},
    {name: "wow.txt", uploaded: "Mar 15, 2020", checked: false},
  ]
  onFileSelected(event) {

    this.fileName = "";
    const file:File = event.target.files[0]

    if(file)
    {
      this.formData.append("thumbnail", file);
      this.fileName = file.name;
      console.log(file.name);
    }
  }

  //http post to the backend
  saveFile(){
    const fileData: FileData =  {name: this.fileName, uploaded: "Sep 15, 2020", checked: false };
    this.listOfFiles.push(fileData);
    const upload$ = this.http.post("", this.formData);
    upload$.subscribe();
  }

  deleteFiles(){
      this.listOfFiles.forEach(e => {
        if(e.checked)
        {
          const index = this.listOfFiles.indexOf(e);
          delete this.listOfFiles[index];
        }

      this.checked = false;
    });
    
    //add delete to the backend
  }

  setCheckboxChange(value: FileData) {
    const index = this.listOfFiles.indexOf(value);
    this.listOfFiles[index].checked = !this.checked;
    this.checked = !this.checked;
  }

  profileJson: string = null;

  ngAfterViewInit(): void {
    this.auth.user$.subscribe(
      (profile) => (this.profileJson = JSON.stringify(profile, null, 2))
    );
  }

}
