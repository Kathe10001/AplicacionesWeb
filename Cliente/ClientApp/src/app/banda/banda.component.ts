import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { BandaService } from '../servicios/banda.service';
import { Banda } from '../tipos/banda';
import { obtenerFiltros } from '../utils';

@Component({
  selector: 'app-banda',
  templateUrl: './banda.component.html',
  styleUrls: ['./banda.component.css']
})
export default class BandaComponent {

  bandas!: Banda[];

  bandasForm = this.formBuilder.group({
    Nombre: '',
    GeneroMusical: ''
  });

  constructor(
    private bandaService: BandaService,
    private formBuilder: FormBuilder,
  ) { }

  onSubmit(): void {
    const filtros: any = obtenerFiltros(this.bandasForm, ["GeneroMusical", "Nombre"]);
    this.bandaService.getBandasApi(filtros).subscribe(bandas => this.bandas = bandas);
    this.bandasForm.reset();
  }

  open(): void {
  }
}
