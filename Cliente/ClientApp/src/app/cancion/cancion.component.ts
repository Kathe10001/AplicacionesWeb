import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { CancionService } from '../servicios/cancion.service';
import { Cancion } from '../tipos/cancion';
import { obtenerFiltros } from '../utils';

@Component({
  selector: 'app-cancion',
  templateUrl: './cancion.component.html',
  styleUrls: ['./cancion.component.css']
})
export default class CancionComponent {

  canciones!: Observable<Cancion[]>;

  cancionesForm = this.formBuilder.group({
    Nombre: '',
    Anio: '',
    Genero: ''
  });


  constructor(
    private cancionService: CancionService,
    private formBuilder: FormBuilder,
  ) { }

  onSubmit(): void {
    const filtros: any = obtenerFiltros(this.cancionesForm, ["Anio", "Genero", "Nombre"]);
    this.canciones = this.cancionService.getCancionesApi(filtros);
    this.cancionesForm.reset();
  }
}
