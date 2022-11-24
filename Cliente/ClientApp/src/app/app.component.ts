import { Component, OnInit } from '@angular/core';
import { Usuario } from './tipos/usuario';
import { getLocalUsuario, setLocalUsuario } from './utils';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit  {

  showMenu: boolean = true;
  user!: Usuario;

  constructor(
  ) { }

  ngOnInit() {
      const usuario = getLocalUsuario();
      if (usuario && usuario.Email !== "NONE") {
          this.user = usuario;
          this.showMenu = true;
      } else {
          const usuarioDumy: Usuario = { Id: 0, Nombre: "NONE", Apellido: "NONE", Email: "NONE", Contrasenia: "NONE" }
          this.showMenu = false;
          setLocalUsuario(usuarioDumy);
          if (window.location.pathname !== '/login')
              window.location.href = '/login';
      }
  }
}
