import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Album } from './tipos/album';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {
  albumes: Album[] = [];

  constructor(
    private http: HttpClient
  ) {}


  getAlbumes() {
    return this.albumes;
  }

  getAlbumesApi() {
    return this.http.get<Album[]>('http://localhost:62462/api/album');
  }
}
