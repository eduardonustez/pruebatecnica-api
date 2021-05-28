import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { facturaViewerComponent } from './components/facturaviewer/facturaviewer.component';
import { HttpClientModule } from "@angular/common/http";
import { nuevaFacturaComponent } from './components/nueva-factura/nueva-factura.component';
import {FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    facturaViewerComponent,
    nuevaFacturaComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
