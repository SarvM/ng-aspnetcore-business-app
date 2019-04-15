import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { AboutComponent } from './about';
import { ToursComponent } from './tours/tours.component';

const routes: Routes = [
  { path: 'tours', component: ToursComponent },
  { path: 'about', component: AboutComponent },
  { path: '**', redirectTo: 'tours'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
