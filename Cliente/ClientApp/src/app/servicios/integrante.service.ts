import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Integrante } from '../tipos/integrante';
import { Banda } from '../tipos/banda';
import { obtenerParametros } from '../utils';

@Injectable({
  providedIn: "root"
})
export class IntegranteService {
  integrantes: Integrante[] = [];

  constructor(
    private http: HttpClient
  ) {}


  getIntegrantes() {
    return this.integrantes;
  }

  getIntegrantesApi(filtros: any) {
    return this.http.get<Integrante[]>('http://localhost:62462/api/integrante'  + obtenerParametros(filtros));
  }

  getIntegranteBandasApi(idIntegrante: number) {
    return this.http.get<Banda[]>('http://localhost:62462/api/integrante/' + idIntegrante + '/bandas');
  }
}
