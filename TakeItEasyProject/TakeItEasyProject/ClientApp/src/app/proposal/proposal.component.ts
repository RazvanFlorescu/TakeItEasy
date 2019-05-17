import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Vacation } from '../shared/models/Vacation';
import { Step } from '../shared/models/Step';

@Component({
  selector: 'app-proposal',
  templateUrl: './proposal.component.html',
  styleUrls: ['./proposal.component.scss']
})
export class ProposalComponent implements OnInit {
  public vacationForm: FormGroup;
  public vacation: Vacation;

  public timeActive = true;
  public locationActive: boolean;
  public descriptionActive: boolean;

  constructor() { }

  ngOnInit() {
    this.vacation = new Vacation();
    this.setVacationFormValidators();
  }

  openAddDateIntervalPage(): void {
    this.activateStep(Step.Time);
  }

  openAddLocationPage(): void {
    this.activateStep(Step.Location);
  }

  openAddDetailsPage(): void {
    this.activateStep(Step.Description);
  }

  private setVacationFormValidators(): void {
    this.vacationForm = new FormGroup({
      // tslint:disable-next-line:max-line-length
      description: new FormControl(this.vacation.description, [Validators.required, Validators.maxLength(250), Validators.pattern('[a-zA-Z0-9\s]+')]),
    });
  }

  private activateStep(step: Step) {
    if (step === Step.Time) {
      this.timeActive = true;
      this.locationActive = false;
      this.descriptionActive = false;
    } else if (step === Step.Description) {
      this.timeActive = false;
      this.locationActive = false;
      this.descriptionActive = true;
    } else {
      this.timeActive = false;
      this.locationActive = true;
      this.descriptionActive = false;
    }
  }
}
