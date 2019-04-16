import { Component, OnInit } from '@angular/core';
import { Band } from '../../shared/band.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Subscription } from 'rxjs/Subscription';
import { TourService } from '../shared/tour.service';
import { Router } from '@angular/router';
import { MasterDataService } from '../../shared/master-data.service';

@Component({
  selector: 'app-tour-add',
  templateUrl: './tour-add.component.html',
  styleUrls: ['./tour-add.component.css']
})
export class TourAddComponent implements OnInit {

  public tourForm: FormGroup
  bands: Band[];

  constructor(
    private masterDataService: MasterDataService,
    private formBuilder: FormBuilder,
    private tourService: TourService
  ) {}

  ngOnInit() {

    this.tourForm = this.formBuilder.group({
      band: [''],
      title: [''],
      description: [''],
      startDate: [],
      endDate: []
    });

    this.masterDataService.getBands()
    .subscribe(bands => {
      this.bands = bands;
    });
  }

  addTour(): void {
    if(this.tourForm.dirty){

    }
    //todo
  }
}
