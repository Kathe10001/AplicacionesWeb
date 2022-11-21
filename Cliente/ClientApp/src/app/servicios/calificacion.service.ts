import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Calificacion } from '../tipos/calificacion';
import { obtenerParametros } from '../utils';

@Injectable({
  providedIn: 'root'
})
export class CalificacionService {

  constructor(
    private http: HttpClient
  ) { }


  getCalificacionApi(filtros: any) {
    return this.http.get<Calificacion>('http://localhost:62462/api/calificacion' + obtenerParametros(filtros));
  }

  postCalificacionApi(filtros: any) {
    return this.http.get<Calificacion>('http://localhost:62462/api/calificacion' + obtenerParametros(filtros));
  }
}
