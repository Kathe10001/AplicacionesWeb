import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { CancionService } from '../cancion.service';
import { Cancion } from '../tipos/cancion';

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
    Duracion: ''
  });


  constructor(
    private cancionService: CancionService,
    private formBuilder: FormBuilder,
  ) { }

  onSubmit(): void {
    this.canciones = this.cancionService.getCancionesApi();
    this.cancionesForm.reset();
  }
}
