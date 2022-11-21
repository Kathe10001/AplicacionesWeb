import { Component, OnInit } from '@angular/core';
import { Nav } from '../tipos/nav';

const updateMenu = (menu: Nav[], link: string) => (menu.map((nav: Nav) => ({ ...nav, Activo: nav.Link === link })));

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})

export default class MenuComponent implements OnInit {

  menu: Nav[] = [
    { Titulo: "Home", Link: "/", Activo: false },
    { Titulo: "Integrantes", Link: "/integrantes", Activo: false },
    { Titulo: "Bandas", Link: "/bandas", Activo: false },
    { Titulo: "Álbumes", Link: "/albumes", Activo: false },
    { Titulo: "Canciones", Link: "/canciones", Activo: false }
  ];

  constructor(
  ) { }

  ngOnInit() {
    this.menu = updateMenu(this.menu, window.location.pathname);
  }

  onChange(link: string) {
    this.menu = updateMenu(this.menu, link);
  }
}
