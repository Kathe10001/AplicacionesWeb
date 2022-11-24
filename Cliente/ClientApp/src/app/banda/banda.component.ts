import { Component, OnInit, NgModule } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { BandaService } from '../servicios/banda.service';
import { CalificacionService } from '../servicios/calificacion.service';
import { Banda } from '../tipos/banda';
import { Integrante } from '../tipos/integrante';
import { Calificacion } from '../tipos/calificacion';
import { obtenerFiltros, obtenerFiltrosCalificacion, setCalificacion, obtenerBody, validarCalificacion } from '../utils';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-banda',
  templateUrl: './banda.component.html',
  styleUrls: ['./banda.component.css']
})

export default class BandaComponent implements OnInit {
  activado: boolean = false;
  editar: boolean = false;
  user!: any;
  showBandas: boolean = false;
  showIntegrantes: boolean = false;
  showCalificacion: boolean = false;
  banda!: Banda;
  bandas!: Banda[];
  integrantes!: Integrante[];
  calificacionParam: string[] = ["Puntaje", "Comentario"];
  mensaje!: string;
  error!: string;
  calificacionForm!: any;

  bandasForm = this.formBuilder.group({
    Nombre: '',
    GeneroMusical: ''
  });

  constructor(
    private appComponent: AppComponent,
    private bandaService: BandaService,
    private calificacionService: CalificacionService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.user = this.appComponent.user;

    this.calificacionForm = new FormGroup({
      Puntaje: new FormControl(5),
      Comentario: new FormControl("")
    }); 
  }

  onSubmit(): void {
    this.error = '';
    this.showBandas = true;
    this.showCalificacion = false;
    this.showIntegrantes = false;
    const filtros: any = obtenerFiltros(this.bandasForm, ["GeneroMusical", "Nombre"]);
    this.bandaService.getBandasApi(filtros).subscribe(bandas => this.bandas = bandas);
    this.bandasForm.reset();
  }

  onSubmitCalificacion(): void {
    this.error = '';
    const body: any = obtenerBody(this.user.Id, this.banda.Id, "BANDA", this.calificacionForm, this.calificacionParam)
    if (this.editar) {
      this.calificacionService.putCalificacionApi(body).subscribe(calificacion => this.mensaje = "Se guardó correctamente",
      error => this.error = "No se pudo enviar");
    } else {
      this.calificacionService.postCalificacionApi(body).subscribe(calificacion => this.mensaje = "Se guardó correctamente",
       error => this.error = "No se pudo enviar");
    }
  }

  openCalificacion(banda: Banda): void {
    this.error = '';
    this.showCalificacion = true;
    this.showIntegrantes = false;
    this.mensaje = '';
    this.banda = banda;
    const filtros: any = obtenerFiltrosCalificacion(this.user.Id, banda.Id, "BANDA");
    this.calificacionService.getCalificacionApi(filtros).subscribe(calificacion => {
      setCalificacion(this.calificacionForm, this.calificacionParam, calificacion);
      this.editar = !!calificacion?.Puntaje;
    })
  }

  closeCalificacion(): void {
    this.error = '';
    this.mensaje = '';
    this.showCalificacion = false;
  }

  openIntegrantes(banda: Banda): void {
    this.showIntegrantes = true;
    this.showCalificacion = false;
    this.banda = banda;
    this.error = '';
    this.mensaje = '';
    this.bandaService.getBandaIntegrantesApi(banda.Id).subscribe(integrantes => {
      this.showIntegrantes = true;
      this.integrantes = integrantes;
    })
  }

  validarBoton() {
    const puntaje = this.calificacionForm.get('Puntaje')?.value;
    const comentario = this.calificacionForm.get('Comentario')?.value;
    this.activado = validarCalificacion(puntaje, comentario);
  }
}
