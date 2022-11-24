import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { LoginService } from '../servicios/login.service';
import { obtenerFiltros, setLocalUsuario } from '../utils';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export default class LoginComponent {

    mensaje: string = '';
    activo: boolean = true;
    registrarForm = this.formBuilder.group({
      Nombre: '',
      Apellido: '',
      Email: '',
      Contrasenia: ''
    });

    ingresarForm = this.formBuilder.group({
        Email: '',
        Contrasenia: ''
    });

    constructor(
      private loginService: LoginService,
      private formBuilder: FormBuilder,
    ) { }

  activar() {
    this.mensaje = '';
        this.activo = !this.activo;
  }

  registrar(): void {
    const body: any = obtenerFiltros(this.registrarForm, ["Nombre", "Apellido", "Email", "Contrasenia"]);
    this.mensaje = '';
    this.loginService.postRegistrarApi(body).subscribe(id => {
      if (id === -1) {
        this.mensaje = "El mail ya existe";
      } else {
        setLocalUsuario({ ...body, Id: id });
        window.location.href = '';
      }
      }, error => this.mensaje = error);
      this.registrarForm.reset();
  }

  ingresar(): void {
      const filtros: any = obtenerFiltros(this.ingresarForm, ["Email"]);
      this.loginService.getIngresarApi(filtros.Email).subscribe(usuario => {
          const contrasenia = this.ingresarForm.get("Contrasenia")?.value;   
          if (contrasenia === usuario?.Contrasenia) {
              this.mensaje = '';
              setLocalUsuario(usuario);
              window.location.href = '';
          } else {
              this.mensaje = "Los datos no son válidos";
          }
      }, error => this.mensaje = error.status === 404 ? "Usuario no registrado" : "Hubo un error, intente más tarde");
  }
}
