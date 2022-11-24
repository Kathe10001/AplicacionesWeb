import { Component, OnInit, NgModule } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { BandaService } from '../servicios/banda.service';
import { CalificacionService } from '../servicios/calificacion.service';
import { Banda } from '../tipos/banda';
import { Integrante } from '../tipos/integrante';
import { Album } from '../tipos/album';
import { Calificacion } from '../tipos/calificacion';
import { obtenerFiltros, obtenerFiltrosCalificacion, setCalificacion, obtenerBody } from '../utils';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-banda',
  templateUrl: './banda.component.html',
  styleUrls: ['./banda.component.css']
})

export default class BandaComponent implements OnInit {

  editar: boolean = false;
  user!: any;
  showAlbumes: boolean = false;
  showBandas: boolean = false;
  showIntegrantes: boolean = false;
  showCalificacion: boolean = false;
  banda!: Banda;
  bandas!: Banda[];
  integrantes!: Integrante[];
  albumes!: Album[];
  calificacionParam: string[] = ["Puntaje", "Comentario"];
  mensaje!: string;

  bandasForm = this.formBuilder.group({
    Nombre: '',
    GeneroMusical: ''
  });

  calificacionForm = this.formBuilder.group({
    Puntaje: 0,
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
    this.showBandas = true;
    this.showCalificacion = false;
    this.showIntegrantes = false;
    this.showAlbumes = false;
    const filtros: any = obtenerFiltros(this.bandasForm, ["GeneroMusical", "Nombre"]);
    this.bandaService.getBandasApi(filtros).subscribe(bandas => this.bandas = bandas);
    this.bandasForm.reset();
  }

  onSubmitCalificacion(): void {
    const body: any = obtenerBody(this.user.Id, this.banda.Id, "BANDA", this.calificacionForm, this.calificacionParam)
    if (this.editar) {
      this.calificacionService.putCalificacionApi(body).subscribe(calificacion => this.mensaje = "Se guardó correctamente");
    } else {
      this.calificacionService.postCalificacionApi(body).subscribe(calificacion => this.mensaje = "Se guardó correctamente");
    }
  }

  openCalificacion(banda: Banda): void {
    this.showCalificacion = true;
    this.showIntegrantes = false;
    this.showAlbumes = false;
    this.banda = banda;
    const filtros: any = obtenerFiltrosCalificacion(this.user.Id, banda.Id, "BANDA");
    this.calificacionService.getCalificacionApi(filtros).subscribe(calificacion => {
      setCalificacion(this.calificacionForm, this.calificacionParam, calificacion);
      this.editar = !!calificacion?.Puntaje;
    })
  }

  closeCalificacion(): void {
    this.showCalificacion = false;
  }

  openIntegrantes(banda: Banda): void {
    this.showIntegrantes = true;
    this.showCalificacion = false;
    this.showAlbumes = false;
    this.banda = banda;
    this.bandaService.getBandaIntegrantesApi(banda.Id).subscribe(integrantes => {
      this.showIntegrantes = true;
      this.integrantes = integrantes;
    })
  }

  openAlbumes(banda: Banda): void {
    this.showAlbumes = true;
    this.showIntegrantes = false;
    this.showCalificacion = false;
    this.banda = banda;
    this.bandaService.getBandaAlbumesApi(banda.Id).subscribe(albumes => {
      this.showAlbumes = true;
      this.albumes = albumes;
    })
  }
}
