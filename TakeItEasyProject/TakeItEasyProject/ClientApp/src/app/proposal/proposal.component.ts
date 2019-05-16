import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Vacation } from '../shared/models/Vacation';

@Component({
  selector: 'app-proposal',
  templateUrl: './proposal.component.html',
  styleUrls: ['./proposal.component.scss']
})
export class ProposalComponent implements OnInit {
  public vacationForm: FormGroup;
  public vacation: Vacation;

  constructor() { }

  ngOnInit() {
    this.vacation = new Vacation();
    this.setVacationFormValidators();
  }

  private setVacationFormValidators(): void {
    this.vacationForm = new FormGroup({
      description: new FormControl(this.vacation.description, [Validators.required, Validators.maxLength(250), Validators.pattern('[a-zA-Z0-9\s]+')]),
    });
  }
}
