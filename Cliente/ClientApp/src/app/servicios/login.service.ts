import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../tipos/usuario';
import { obtenerParametros } from '../utils';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  usuario!: Usuario;

  constructor(
    private http: HttpClient
  ) { }

  getIngresarApi(email: string) {
      return this.http.get<Usuario>('http://localhost:62462/api/usuario?Email=' + email);
  }

  postRegistrarApi(body: any) {
      return this.http.post<Usuario>('http://localhost:62462/api/usuario', body);
  }
}
