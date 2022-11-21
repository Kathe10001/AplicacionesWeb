import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AlbumService } from '../servicios/album.service';
import { Album } from '../tipos/album';
import { obtenerFiltros } from '../utils';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.css']
})
export default class AlbumComponent {

  albumes!: Album[];

  albumesForm = this.formBuilder.group({
    Nombre: '',
    AnioCreacion: '',
    GeneroMusical: ''
  });


  constructor(
    private albumService: AlbumService,
    private formBuilder: FormBuilder,
  ) { }

  onSubmit(): void {
    const filtros: any = obtenerFiltros(this.albumesForm, ["GeneroMusical", "Nombre", "AnioCreacion"]);
    this.albumService.getAlbumesApi(filtros).subscribe(albumes => this.albumes = albumes);
    this.albumesForm.reset();
  }
}
