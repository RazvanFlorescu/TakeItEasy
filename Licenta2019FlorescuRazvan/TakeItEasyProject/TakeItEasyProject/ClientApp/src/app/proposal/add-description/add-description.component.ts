import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Vacation, AvailableMode } from 'src/app/shared/models/Vacation';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-description',
  templateUrl: './add-description.component.html',
  styleUrls: ['./add-description.component.scss']
})
export class AddDescriptionComponent implements OnInit {

  public vacationForm: FormGroup;
  @Input() vacation: Vacation;
  @Output() vacationChange = new EventEmitter();
  @Output() saveState = new EventEmitter();

  constructor() {
    
   }

   symbols = AvailableMode;
   keys() : Array<string> {
        var keys = Object.keys(this.symbols);
        return keys.slice(keys.length / 2);
    }

  ngOnInit() {
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

  get availableMode() {
    return this.vacationForm.get('availableMode');
  }

  get endDate() {
    return this.vacationForm.get('endDate');
  }

  isValidDateInterval() {
    return !!this.startDate.value &&
           !!this.endDate.value &&
          (this.startDate.value <= this.endDate.value);
  }

  getErrorMessage() {
    if(!this.startDate.value || !this.endDate.value) {
      return '';
    }
    
    return !this.isValidDateInterval() ? 'The startdate should be lower than the enddate.' : '';
  }

  isValidForm() {
    return !this.vacationForm.invalid && this.isValidDateInterval();
  }

  save() {
    this.vacation.startDate = this.startDate.value;
    this.vacation.endDate = this.endDate.value;
    this.vacation.description = this.description.value;
    this.vacation.title = this.title.value;
    this.vacation.availableMode = this.availableMode.value;
    this.vacationChange.emit(this.vacation);
    this.saveState.emit('descriptionstep');
  }

  private setVacationFormValidators(): void {
    this.vacationForm = new FormGroup({
      startDate: new FormControl(this.vacation.startDate, [Validators.required]),
      endDate: new FormControl(this.vacation.endDate, [Validators.required]),
      title: new FormControl(this.vacation.title, [Validators.required, Validators.maxLength(20)]),
      availableMode: new FormControl(this.vacation.availableMode),
      // tslint:disable-next-line:max-line-length
      description: new FormControl(this.vacation.description, [Validators.required, Validators.maxLength(250)]),
    });
  }
}
