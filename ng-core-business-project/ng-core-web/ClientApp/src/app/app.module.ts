import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app.routing';
import { AppComponent } from './app.component';
import { AboutComponent } from './about';
import { ToursComponent } from './tours/tours.component';

import { TourService } from './tours/shared/tour.service'

@NgModule({
  declarations: [
    AppComponent,
    AboutComponent,
    ToursComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [TourService],
  bootstrap: [AppComponent]
})
export class AppModule { }
