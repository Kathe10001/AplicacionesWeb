import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import HomeComponent from './home/home.component';
import CancionComponent from './cancion/cancion.component';
import IntegranteComponent from './integrante/integrante.component';
import BandaComponent from './banda/banda.component';
import AlbumComponent from './album/album.component';
import MenuComponent from './menu/menu.component';
import LoginComponent from './login/login.component';

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'login', component: LoginComponent },
      { path: 'integrantes', component: IntegranteComponent },
      { path: 'bandas', component: BandaComponent },
      { path: 'albumes', component: AlbumComponent },
      { path: 'canciones', component: CancionComponent }
    ])
  ],
  declarations: [
    AppComponent,
    MenuComponent,
    LoginComponent,
    HomeComponent,
    CancionComponent,
    BandaComponent,
    IntegranteComponent,
    AlbumComponent
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
