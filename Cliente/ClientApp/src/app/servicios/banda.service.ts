import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Banda } from '../tipos/banda';
import { obtenerParametros } from '../utils';

@Injectable({
  providedIn: 'root'
})
export class BandaService {
  bandas: Banda[] = [];

  constructor(
    private http: HttpClient
  ) {}


  getBandas() {
    return this.bandas;
  }

  getBandasApi(filtros: any) {
    return this.http.get<Banda[]>('http://localhost:62462/api/banda' + obtenerParametros(filtros));
  }
}
