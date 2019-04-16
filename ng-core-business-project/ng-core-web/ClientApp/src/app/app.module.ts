import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app.routing';
import { AppComponent } from './app.component';
import { AboutComponent } from './about';
import { ToursComponent, TourUpdateComponent, TourDetailComponent, TourAddComponent } from './tours';
import { ShowAddComponent } from './tours/shows';

import { TourService } from './tours/shared/tour.service';
import { MasterDataService } from './shared/master-data.service';

@NgModule({
  declarations: [
    AppComponent,
    AboutComponent,
    ToursComponent,
    TourUpdateComponent,
    TourDetailComponent,
    ShowAddComponent,
    TourAddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [TourService, MasterDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
