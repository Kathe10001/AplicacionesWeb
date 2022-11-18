import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cancion } from './tipos/cancion';

@Injectable({
  providedIn: 'root'
})
export class CancionService {
  canciones: Cancion[] = [];

  constructor(
    private http: HttpClient
  ) {}


  getCanciones() {
    return this.canciones;
  }

  getCancionesApi() {
    return this.http.get<Cancion[]>('http://localhost:62462/api/cancion');
  }
}
