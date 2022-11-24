import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AlbumService } from '../servicios/album.service';
import { Album } from '../tipos/album';
import { Cancion } from '../tipos/cancion';
import { obtenerFiltros } from '../utils';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.css']
})
export default class AlbumComponent {
  user!: any;
  showCanciones: boolean = false;
  showAlbumes: boolean = false;
  album!: Album;
  albumes!: Album[];
  canciones!: Cancion[];

  albumesForm = this.formBuilder.group({
    Nombre: '',
    AnioCreacion: '',
    GeneroMusical: ''
  });


  constructor(
    private appComponent: AppComponent,
    private albumService: AlbumService,
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit() {
    this.user = this.appComponent.user;
  }

  onSubmit(): void {
    this.showCanciones = false;
    const filtros: any = obtenerFiltros(this.albumesForm, ["GeneroMusical", "Nombre", "AnioCreacion"]);
      this.albumService.getAlbumesApi(filtros).subscribe(albumes => {
          this.showAlbumes = true;
          this.albumes = albumes
      });
    this.albumesForm.reset();
    }

    openCanciones(album: Album): void {
        this.showCanciones = true;
        this.album = album;
        this.albumService.getAlbumCancionesApi(album.Id).subscribe(canciones => {
            this.canciones = canciones;
        })
    }
}
