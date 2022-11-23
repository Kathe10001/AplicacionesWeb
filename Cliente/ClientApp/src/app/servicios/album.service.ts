import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Album } from '../tipos/album';
import { Cancion } from '../tipos/cancion';
import { obtenerParametros } from '../utils';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {
  albumes: Album[] = [];

  constructor(
    private http: HttpClient
  ) { }


  getAlbumes() {
    return this.albumes;
  }

  getAlbumesApi(filtros: any) {
    return this.http.get<Album[]>('http://localhost:62462/api/album' + obtenerParametros(filtros));
  }

  getAlbumCancionesApi(idAlbum: number) {
    return this.http.get<Cancion[]>('http://localhost:62462/api/album/' + idAlbum + '/canciones');
  }
}
