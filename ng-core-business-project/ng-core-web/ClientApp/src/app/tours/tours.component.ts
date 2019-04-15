import { Component, OnInit } from '@angular/core';

import { Tour } from './shared/tour.model';
import { TourService } from './shared/tour.service';

@Component({
  selector: 'app-tours',
  templateUrl: './tours.component.html',
  styleUrls: ['./tours.component.css']
})
export class ToursComponent implements OnInit {
  title: string = 'Tour Overview';
  tours: Tour[] = [];

  constructor(private tourService: TourService) {
    console.log(tourService);
  }

  ngOnInit() {
    this.tourService.getTours()
      .subscribe(tours => {
        this.tours = tours;
      });
  }
}
