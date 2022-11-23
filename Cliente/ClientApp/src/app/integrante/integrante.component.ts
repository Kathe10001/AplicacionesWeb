import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { IntegranteService } from '../servicios/integrante.service';
import { Integrante } from '../tipos/integrante';
import { Banda } from '../tipos/banda';
import { obtenerFiltros } from '../utils';

@Component({
  selector: 'app-integrante',
  templateUrl: './integrante.component.html',
  styleUrls: ['./integrante.component.css']
})
export default class IntegranteComponent {

  showIntegrantes: boolean = false;
  showBandas: boolean = false;
  integrante!: Integrante;
  integrantes!: Integrante[];
  bandas!: Banda[];

  integrantesForm = this.formBuilder.group({
    Nombre: '',
    Apellido: ''
  });


  constructor(
    private integranteService: IntegranteService,
    private formBuilder: FormBuilder,
  ) { }

  onSubmit(): void {
    const filtros: any = obtenerFiltros(this.integrantesForm, ["Nombre", "Apellido"]);
    this.integranteService.getIntegrantesApi(filtros).subscribe(integrantes => {
      this.showIntegrantes = true;
      this.showBandas = false;
      this.integrantes = integrantes
    });
    this.integrantesForm.reset();
  }

  openBandas(integrante: Integrante): void {
    this.showBandas = true;
    this.integrante = integrante;
    this.integranteService.getIntegranteBandasApi(integrante.Id).subscribe(bandas => {
      this.bandas = bandas;
    })
  }
}
