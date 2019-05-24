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


    $(function () {
     ( <any>$('#datetimepicker11')).datetimepicker({
          daysOfWeekDisabled: [0, 6]
      });
    });
  }

  get description() {
    return this.vacationForm.get('description');
  }
  private setVacationFormValidators(): void {
    this.vacationForm = new FormGroup({
      // tslint:disable-next-line:max-line-length
      description: new FormControl(this.vacation.description, [Validators.required, Validators.maxLength(250), Validators.pattern('[a-zA-Z0-9\s]+')]),
    });
  }

}
