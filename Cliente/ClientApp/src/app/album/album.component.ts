import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { AlbumService } from '../servicios/album.service';
import { Album } from '../tipos/album';
import { obtenerFiltros } from '../utils';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.css']
})
export default class AlbumComponent {

  albumes!: Observable<Album[]>;

  albumesForm = this.formBuilder.group({
    Nombre: '',
    Anio: '',
    Genero: ''
  });


  constructor(
    private albumService: AlbumService,
    private formBuilder: FormBuilder,
  ) { }

  onSubmit(): void {
    const filtros: any = obtenerFiltros(this.albumesForm, ["Genero", "Nombre", "Anio"]);
    this.albumes = this.albumService.getAlbumesApi(filtros);
    this.albumesForm.reset();
  }
}
