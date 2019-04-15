import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TourService } from '../shared/tour.service';
import { Tour } from '../shared/tour.model';
import { Subscription } from 'rxjs/Subscription';
import { DatePipe } from '@angular/common'

@Component({
  selector: 'app-tour-update',
  templateUrl: './tour-update.component.html',
  styleUrls: ['./tour-update.component.css']
})
export class TourUpdateComponent implements OnInit, OnDestroy {

  public tourForm: FormGroup;
  private tour: Tour;
  private tourId: string;
  private sub: Subscription;

  constructor(
    private tourService: TourService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
    ) {

  }

  ngOnInit(){

    this.tourForm = this.formBuilder.group({
      title: [''],
      description: [''],
      startDate:[],
      endDate: []
    });

    this.sub = this.route.params.subscribe(
      params => {
        this.tourId = params['tourId'];
        this.tourService.getTour(this.tourId)
          .subscribe(tour => {
            this.tour = tour;
            this.updateTourForm();
          });
      }
    );

  }

  private updateTourForm(){

    let datePipe = new DatePipe(navigator.language);
    let dateFormat = 'yyyy-MM-dd';

    this.tourForm.patchValue({
      title: this.tour.title,
      description: this.tour.description,
      startDate: datePipe.transform(this.tour.startDate, dateFormat),
      endDate: datePipe.transform(this.tour.endDate, dateFormat)
    });

  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  saveTour(): void{
    if(this.tourForm.dirty){}
  }

}
