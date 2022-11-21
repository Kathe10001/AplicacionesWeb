import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { BandaService } from '../servicios/banda.service';
import { CalificacionService } from '../servicios/calificacion.service';
import { Banda } from '../tipos/banda';
import { Calificacion } from '../tipos/calificacion';
import { obtenerFiltros } from '../utils';
import { AppComponent } from '../app.component';
 
@Component({
  selector: 'app-banda',
  templateUrl: './banda.component.html',
  styleUrls: ['./banda.component.css']
})

export default class BandaComponent implements OnInit {

  user!: any;
  show: boolean = false;
  banda!: Banda;
  calificacion!: Calificacion;
  bandas!: Banda[];

  bandasForm = this.formBuilder.group({
    Nombre: '',
    GeneroMusical: ''
  });

  calificacionForm = this.formBuilder.group({
    Puntaje: '',
    Comentario: ''
  });

  constructor(
    private appComponent: AppComponent,
    private bandaService: BandaService,
    private calificacionService: CalificacionService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.user = this.appComponent.user;
  }

  onSubmit(): void {
    const filtros: any = obtenerFiltros(this.bandasForm, ["GeneroMusical", "Nombre"]);
    this.bandaService.getBandasApi(filtros).subscribe(bandas => this.bandas = bandas);
    this.bandasForm.reset();
  }

  onSubmitCalificacion(): void {
    const filtros: any = obtenerFiltros(this.calificacionForm, ["Puntaje", "Comentario"]);
    this.calificacionService.postCalificacionApi(filtros).subscribe(calificacion => this.calificacion = calificacion);
  }

  open(banda: Banda): void {
    this.show = true;
    this.banda = banda;
    const filtros: any = obtenerFiltros(this.calificacionForm, ["Puntaje", "Comentario"]);
    this.calificacionService.getCalificacionApi(filtros).subscribe(calificacion => this.calificacion = calificacion);
  }

  close(): void {
    this.show = false;
  }
}
