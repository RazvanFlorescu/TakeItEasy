import { Component, OnInit } from '@angular/core';
import { Vacation } from 'src/app/shared/models/Vacation';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import * as $ from 'jquery';

@Component({
  selector: 'app-add-description',
  templateUrl: './add-description.component.html',
  styleUrls: ['./add-description.component.scss']
})
export class AddDescriptionComponent implements OnInit {

  public vacationForm: FormGroup;
  public vacation: Vacation;

  constructor() { }

  ngOnInit() {
    this.vacation = new Vacation();
    this.setVacationFormValidators();
  }

  get title() {
    return this.vacationForm.get('title');
  }

  get description() {
    return this.vacationForm.get('description');
  }

  get startDate() {
    return this.vacationForm.get('startDate');
  }

  get endDate() {
    return this.vacationForm.get('endDate');
  }

  isValidDateInterval() {
    return this.startDate.value > this.endDate.value;
  }
  
  private setVacationFormValidators(): void {
    this.vacationForm = new FormGroup({
      startDate: new FormControl(this.vacation.startDate, [Validators.required]),
      endDate: new FormControl(this.vacation.endDate, [Validators.required]),
      title: new FormControl(this.vacation.title, [Validators.required, Validators.maxLength(20)]),
      // tslint:disable-next-line:max-line-length
      description: new FormControl(this.vacation.description, [Validators.required, Validators.maxLength(250), Validators.pattern('[a-zA-Z0-9\s]+')]),
    });
  }
}
