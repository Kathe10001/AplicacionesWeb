import { HttpClient } from '@angular/common/http';
import { Cancion} from './canciones';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CancionService
{
  items: Cancion[] = [];

  constructor(
    private http: HttpClient
  ) { }

  CancionUrl: any = 'http://localhost:62462/api/cancion';

  //addToCart(cancion: Cancion) {
  //  this.items.push(cancion);
  //}

  getItems() {
    return this.items;
  }

  //clearCart() {
  //  this.items = [];
  //  return this.items;
  //}

  //getShippingPrices() {
  //  return this.http.get<{ type: string, price: number }[]>('http://localhost:62462/api/cancion');
  //}

  getCanciones(): Observable<Cancion[]> {
    return this.http.get<Cancion[]>('http://localhost:62462/api/cancion')

  }

  getCancion(id: number): Observable<Cancion> {
    const url = '${ this.CancionUrl }/${id}';
    return this.http.get<Cancion>(url)
  }
}
