import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { LoginService } from '../servicios/login.service';
import { obtenerFiltros, setCookie } from '../utils';

@Component({
  selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export default class LoginComponent {

    mensaje: string = '';
    activo: boolean = true;
    registrarForm = this.formBuilder.group({
      Nombre: '',
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
        this.activo = !this.activo;
    }

    registrar(): void {
        const body: any = obtenerFiltros(this.registrarForm, ["Nombre", "Email", "Contrasenia"]);
        this.loginService.postRegistrarApi(body).subscribe(usuario => {
            console.log("registrar", usuario)  
        });
        this.registrarForm.reset();
    }

    ingresar(): void {
        const filtros: any = obtenerFiltros(this.ingresarForm, ["Email"]);
        this.loginService.getIngresarApi(filtros.Email).subscribe(usuario => {
            const contrasenia = this.ingresarForm.get("Contrasenia")?.value;   
            if (contrasenia === usuario?.Contrasenia) {
                this.mensaje = '';
                setCookie("session", usuario.Email);
                window.location.href = '';
            } else {
                this.mensaje = "Los datos no son válidos";
            }
        });
   
    }
}
