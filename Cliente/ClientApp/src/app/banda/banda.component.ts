import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { BandaService } from '../servicios/banda.service';
import { Banda } from '../tipos/banda';
import { obtenerFiltros } from '../utils';

@Component({
  selector: 'app-banda',
  templateUrl: './banda.component.html',
  styleUrls: ['./banda.component.css']
})
export default class BandaComponent {

  bandas!: Observable<Banda[]>;

  bandasForm = this.formBuilder.group({
    Nombre: '',
    Genero: ''
  });


  constructor(
    private bandaService: BandaService,
    private formBuilder: FormBuilder,
  ) { }

  onSubmit(): void {
    const filtros: any = obtenerFiltros(this.bandasForm, ["Genero", "Nombre"]);
    this.bandas = this.bandaService.getBandasApi(filtros);
    this.bandasForm.reset();
  }
}
