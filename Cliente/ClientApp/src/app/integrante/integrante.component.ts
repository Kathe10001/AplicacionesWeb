import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { IntegranteService } from '../servicios/integrante.service';
import { Integrante } from '../tipos/integrante';
import { obtenerFiltros } from '../utils';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-integrante',
  templateUrl: './integrante.component.html',
  styleUrls: ['./integrante.component.css']
})

export default class IntegranteComponent {
  user!: any;
  showIntegrantes: boolean = false;
  integrante!: Integrante;
  integrantes!: Integrante[];

  integrantesForm = this.formBuilder.group({
    Nombre: '',
    Apellido: ''
  });


  constructor(
    private appComponent: AppComponent,
    private integranteService: IntegranteService,
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit() {
    this.user = this.appComponent.user;
  }

  onSubmit(): void {
    const filtros: any = obtenerFiltros(this.integrantesForm, ["Nombre", "Apellido"]);
    this.integranteService.getIntegrantesApi(filtros).subscribe(integrantes => {
      this.showIntegrantes = true;
      this.integrantes = integrantes
    });
    this.integrantesForm.reset();
  }
}
