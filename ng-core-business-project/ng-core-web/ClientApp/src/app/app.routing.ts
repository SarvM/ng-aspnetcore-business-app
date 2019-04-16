import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { AboutComponent } from './about';
import { ToursComponent, TourUpdateComponent, TourDetailComponent, TourAddComponent } from './tours';
import { ShowAddComponent } from './tours/shows';

const routes: Routes = [
  { path: 'tours', component: ToursComponent },
  { path: 'about', component: AboutComponent },
  { path: 'tours/:tourId', component: TourDetailComponent },
  { path: 'tour-update/:tourId', component: TourUpdateComponent },
  { path: 'tour-add', component: TourAddComponent },
  { path: 'tours/:tourId/show-add', component: ShowAddComponent },
  { path: '**', redirectTo: 'tours'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
