import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { CancionService } from '../servicios/cancion.service';
import { CalificacionService } from '../servicios/calificacion.service';
import { Cancion } from '../tipos/cancion';
import { Calificacion } from '../tipos/calificacion';
import { obtenerFiltros } from '../utils';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-cancion',
  templateUrl: './cancion.component.html',
  styleUrls: ['./cancion.component.css']
})
export default class CancionComponent {

  user!: any;
  show: boolean = false;
  cancion!: Cancion;
  calificacion!: Calificacion;
  canciones!: Cancion[];

  cancionesForm = this.formBuilder.group({
    Nombre: '',
    Anio: '',
    GeneroMusical: ''
  });

  calificacionForm = this.formBuilder.group({
    Puntaje: '',
    Comentario: ''
  });

  constructor(
    private appComponent: AppComponent,
    private cancionService: CancionService,
    private calificacionService: CalificacionService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.user = this.appComponent.user;
  }

  onSubmit(): void {
    const filtros: any = obtenerFiltros(this.cancionesForm, ["Anio", "GeneroMusical", "Nombre"]);
    this.cancionService.getCancionesApi(filtros).subscribe(canciones => this.canciones = canciones);
    this.cancionesForm.reset();
  }

  onSubmitCalificacion(): void {
    const filtros: any = obtenerFiltros(this.calificacionForm, ["Puntaje", "Comentario"]);
    this.calificacionService.postCalificacionApi(filtros).subscribe(calificacion => this.calificacion = calificacion);
  }

  open(cancion: Cancion): void {
    this.show = true;
    this.cancion = cancion;
    const filtros: any = obtenerFiltros(this.calificacionForm, ["Puntaje", "Comentario"]);
    this.calificacionService.getCalificacionApi(filtros).subscribe(calificacion => this.calificacion = calificacion);
  }

  close(): void {
    this.show = false;
  }
}
