import { Component } from '@angular/core';

import { canciones } from '../canciones';

@Component({
  selector: 'app-canciones-list',
  templateUrl: './canciones-list.component.html',
  styleUrls: ['./canciones-list.component.css']
})
export class CancionesListComponent {

  canciones = [...canciones];

  share() {
    window.alert('The product has been shared!');
  }

  onNotify() {
    window.alert('You will be notified when the product goes on sale');
  }
}
