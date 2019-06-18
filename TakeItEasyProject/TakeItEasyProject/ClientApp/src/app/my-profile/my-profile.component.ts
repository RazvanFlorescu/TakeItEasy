import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { User } from '../shared/models/User';
import { VacationService } from '../shared/services/vacation.service';
import { Vacation } from '../shared/models/Vacation';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})
export class MyProfileComponent implements OnInit {

  constructor(private userService: UserService, private vacationService: VacationService) { }

  public signInClicked: boolean;
  public vacations: Vacation[];
  public joiningVacations: Vacation[];

  get user() {
    return this.userService.getLoggedUser();
  }
  
  ngOnInit() {
    if(this.user && this.user.entityId) {
       this.vacationService.getVacationsByUserId(this.user.entityId).subscribe(
        res => {
          this.vacations = res;
        },
        err => {
          console.log(err);
        }
       );

       this.vacationService.getVacationsByUserIdWhereThatUserIsJoinedThere(this.user.entityId).subscribe(
         res => {
           this.joiningVacations = res;
         },
         err => {
           console.log(err);
         }
       )
    }
  }
}
