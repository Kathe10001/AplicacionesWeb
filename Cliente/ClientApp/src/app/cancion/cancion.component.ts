import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { CancionService } from '../servicios/cancion.service';
import { Cancion } from '../tipos/cancion';
import { obtenerFiltros } from '../utils';

@Component({
  selector: 'app-cancion',
  templateUrl: './cancion.component.html',
  styleUrls: ['./cancion.component.css']
})
export default class CancionComponent {

  canciones!: Cancion[];

  cancionesForm = this.formBuilder.group({
    Nombre: '',
    Anio: '',
    GeneroMusical: ''
  });


  constructor(
    private cancionService: CancionService,
    private formBuilder: FormBuilder,
  ) { }

  onSubmit(): void {
    const filtros: any = obtenerFiltros(this.cancionesForm, ["Anio", "GeneroMusical", "Nombre"]);
    this.cancionService.getCancionesApi(filtros).subscribe(canciones => this.canciones = canciones);
    this.cancionesForm.reset();
  }
}
