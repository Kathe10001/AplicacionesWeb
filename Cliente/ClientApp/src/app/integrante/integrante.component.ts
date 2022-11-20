import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { IntegranteService } from '../servicios/integrante.service';
import { Integrante } from '../tipos/integrante';
import { obtenerFiltros } from '../utils';

@Component({
  selector: 'app-integrante',
  templateUrl: './integrante.component.html',
  styleUrls: ['./integrante.component.css']
})
export default class CancionComponent {

  integrantes!: Observable<Integrante[]>;

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
    this.integrantes = this.integranteService.getIntegrantesApi(filtros);
    this.integrantesForm.reset();
  }
}
