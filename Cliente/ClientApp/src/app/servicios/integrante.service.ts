import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Integrante } from './tipos/integrante';

@Injectable({
  providedIn: 'root'
})
export class IntegranteService {
  integrantes: Integrante[] = [];

  constructor(
    private http: HttpClient
  ) {}


  getIntegrantes() {
    return this.integrantes;
  }

  getIntegrantesApi() {
    return this.http.get<Integrante[]>('http://localhost:62462/api/integrante');
  }
}
