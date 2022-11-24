import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { CancionService } from '../servicios/cancion.service';
import { CalificacionService } from '../servicios/calificacion.service';
import { Cancion } from '../tipos/cancion';
import { Album } from '../tipos/album';
import { Calificacion } from '../tipos/calificacion';
import { obtenerFiltros, obtenerFiltrosCalificacion, obtenerBody, setCalificacion } from '../utils';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-cancion',
  templateUrl: './cancion.component.html',
  styleUrls: ['./cancion.component.css']
})
export default class CancionComponent {

  editar: boolean = false;
  user!: any;
  showCanciones: boolean = false;
  showAlbumes: boolean = false;
  cancion!: Cancion;
  canciones!: Cancion[];
  albumes!: Album[];
  calificacionParam: string[] = ["Puntaje", "Comentario"];
  mensaje!: string;
  error!: string;

  cancionesForm = this.formBuilder.group({
    Nombre: '',
    Anio: '',
    GeneroMusical: ''
  });

  calificacionForm = this.formBuilder.group({
    Puntaje: 0,
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
    this.error = '';
    this.mensaje = '';
    this.showCanciones = false;
    const filtros: any = obtenerFiltros(this.cancionesForm, ["Anio", "GeneroMusical", "Nombre"]);
    this.cancionService.getCancionesApi(filtros).subscribe(canciones => this.canciones = canciones);
    this.cancionesForm.reset();
  }

  onSubmitCalificacion(): void {
    this.error = '';
    this.mensaje = '';
    const body: any = obtenerBody(this.user.Id, this.cancion.Id, "CANCION", this.calificacionForm, this.calificacionParam)
    if (this.editar) {
      this.calificacionService.putCalificacionApi(body).subscribe(calificacion => this.mensaje = "Se guardó correctamente",
        error => this.error = "No se pudo enviar");
    } else {
      this.calificacionService.postCalificacionApi(body).subscribe(calificacion => this.mensaje = "Se guardó correctamente",
        error => this.error = "No se pudo enviar");
    }
  }

  openCalificacion(cancion: Cancion): void {
    this.error = '';
    this.mensaje = '';
    this.showCanciones = true;
    this.cancion = cancion;
    const filtros: any = obtenerFiltrosCalificacion(this.user.Id, cancion.Id, "CANCION");
    this.calificacionService.getCalificacionApi(filtros).subscribe(calificacion => {
      setCalificacion(this.calificacionForm, this.calificacionParam, calificacion);
      this.editar = !!calificacion?.Puntaje;
    })
  }

  close(): void {
    this.error = '';
    this.mensaje = '';
    this.showCanciones = false;
  }
}
