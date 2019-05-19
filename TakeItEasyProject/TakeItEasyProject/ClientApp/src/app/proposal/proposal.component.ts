import { Component, OnInit } from '@angular/core';
import { Step } from '../shared/models/Step';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-proposal',
  templateUrl: './proposal.component.html',
  styleUrls: ['./proposal.component.scss']
})
export class ProposalComponent implements OnInit {
  public imageActive: boolean;
  public locationActive: boolean;
  public descriptionActive = true;

  constructor(private userService: UserService) { }

  get user() {
    return this.userService.getLoggedUser();
  }

  ngOnInit() {
  }

  openAddImagePage(): void {
    this.activateStep(Step.Image);
  }

  openAddLocationPage(): void {
    this.activateStep(Step.Location);
  }

  openAddDetailsPage(): void {
    this.activateStep(Step.Description);
  }

  private activateStep(step: Step) {
    if (step === Step.Image) {
      this.imageActive = true;
      this.locationActive = false;
      this.descriptionActive = false;
    } else if (step === Step.Description) {
      this.imageActive = false;
      this.locationActive = false;
      this.descriptionActive = true;
    } else {
      this.imageActive = false;
      this.locationActive = true;
      this.descriptionActive = false;
    }
  }
}
