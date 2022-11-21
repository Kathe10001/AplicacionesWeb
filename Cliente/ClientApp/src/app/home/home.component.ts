import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export default class HomeComponent implements OnInit {

  user!: any;

  constructor(
    private appComponent: AppComponent
  ) { }

  ngOnInit() {
    this.user = this.appComponent.user;
  }
}
