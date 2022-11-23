import { Component, OnInit } from '@angular/core';
import { getCookie, setCookie } from './utils';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit  {

  showMenu: boolean = true;
  user: any = {
    Email: ''
  }

  constructor(
  ) { }

  ngOnInit() {
      const cookie = getCookie("session", document.cookie);
      if (cookie && cookie !== "NONE") {
          this.user.Email = cookie;
          this.showMenu = true;
      } else {
          this.showMenu = false;
          setCookie("session", "NONE");
          if (window.location.pathname !== '/login')
              window.location.href = '/login';
      }
  }
}
