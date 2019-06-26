import { Component, OnInit } from '@angular/core';
import { Step } from '../shared/models/Step';
import { UserService } from '../shared/services/user.service';
import { Vacation } from '../shared/models/Vacation';
import { VacationService } from '../shared/services/vacation.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-proposal',
  templateUrl: './proposal.component.html',
  styleUrls: ['./proposal.component.scss']
})
export class ProposalComponent implements OnInit {
  public imageActive: boolean;
  public locationActive: boolean;
  public descriptionActive = true;
  public vacation: Vacation;
  private isDescriptionCompleted = false;
  private isLocationCompleted = false;
  private isImageCompleted = false;
  public showToastr = false;

  constructor(private userService: UserService, 
    private vacationService: VacationService,
    private router: Router) {
    this.vacation = new Vacation();
   }

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

  onSave($event) {
    if ($event === 'descriptionstep') {
      this.isDescriptionCompleted = true;
      this.openAddLocationPage();
    } else if ($event === 'locationstep') {
      this.isLocationCompleted = true;
      this.openAddImagePage();
    } else if ($event === 'imagestep') {
      this.isImageCompleted = true;
      this.vacation.authorId = this.user.entityId;
      this.vacationService.propose(this.vacation).subscribe(
        res => {
         this.showToastr = true;
        },
        err => {
          console.log(err);
        }
      );
    }
  }

  goToMyProposals() {
    this.showToastr = true;
    this.router.navigate(["/my-profile"]);
  }

  get isStateCompleted() {
    return this.isDescriptionCompleted && this.isLocationCompleted;
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
