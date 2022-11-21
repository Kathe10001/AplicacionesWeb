import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { IntegranteService } from '../servicios/integrante.service';
import { Integrante } from '../tipos/integrante';
import { obtenerFiltros } from '../utils';

@Component({
  selector: 'app-integrante',
  templateUrl: './integrante.component.html',
  styleUrls: ['./integrante.component.css']
})
export default class IntegranteComponent {

  integrantes!: Integrante[];

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
    this.integranteService.getIntegrantesApi(filtros).subscribe(integrantes => this.integrantes = integrantes);
    this.integrantesForm.reset();
  }
}
