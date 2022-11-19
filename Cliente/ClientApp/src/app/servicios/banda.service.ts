import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Banda } from './tipos/banda';

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

  getBandasApi() {
    return this.http.get<Banda[]>('http://localhost:62462/api/banda');
  }
}
