import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';
import { CancionService } from '../cancion.service';
import { Cancion } from '../tipos/cancion';

@Component({
  selector: 'app-cancion',
  templateUrl: './cancion.component.html',
  styleUrls: ['./cancion.component.css']
})
export default class CancionComponent implements OnInit {

  canciones!: Observable<Cancion[]>;

  constructor(private cancionService: CancionService) { }

  ngOnInit(): void {
    const result = this.cancionService.getCancionesApi();
    this.canciones = result;
  }

}
