import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { TitlecardsComponent } from './titlecards/titlecards.component';
import { HeaderComponent } from './header/header.component';
import { SteamidComponent } from './steamid/steamid.component';
import { FooterComponent } from './footer/footer.component';

import {HttpClientModule } from '@angular/common/http'

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    TitlecardsComponent,
    HeaderComponent,
    SteamidComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
