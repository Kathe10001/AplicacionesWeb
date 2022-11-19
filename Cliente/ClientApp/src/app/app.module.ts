import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
/*import { ProductListComponent } from './product-list/product-list.component';
import { ProductAlertsComponent } from './product-alerts/product-alerts.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CartComponent } from './cart/cart.component';*/
import CancionComponent from './cancion/cancion.component';


@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: CancionComponent },
      { path: 'integrantes', component: CancionComponent },
      { path: 'bandas', component: CancionComponent },
      { path: 'albunes', component: CancionComponent },
      { path: 'canciones', component: CancionComponent }
    ])
  ],
  declarations: [
    AppComponent,
    TopBarComponent,
    CancionComponent
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
