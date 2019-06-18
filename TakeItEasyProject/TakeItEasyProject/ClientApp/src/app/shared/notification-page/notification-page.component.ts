import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TripNotification, NotificationType } from '../models/TripNotification';
import { VacationService } from '../services/vacation.service';
import { Vacation, VacationJoining, StatusJoining } from '../models/Vacation';
import { ImageService } from '../services/image.service';
import { UserService } from '../services/user.service';
import { User } from '../models/User';
import { NotificationService } from '../services/notification.service';

@Component({
  selector: 'app-notification-page',
  templateUrl: './notification-page.component.html',
  styleUrls: ['./notification-page.component.scss']
})
export class NotificationPageComponent implements OnInit {
  currentNotification: TripNotification;
  vacation: Vacation;
  currentUser: User;
  author: User;
  vacationJoining: VacationJoining;

  constructor(private userService: UserService, private vacationService: VacationService, private route: ActivatedRoute, private imageService: ImageService, private notificationService: NotificationService) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.currentNotification = JSON.parse(params['notification']);
      this.setVacation(this.currentNotification.vacationId);
      this.setAuthor(this.currentNotification.authorId);
      this.setVacationJoining(this.currentNotification.vacationId, this.currentNotification.authorId);
  });
  }

  private setVacation(vacationId: string) {
    this.vacationService.getVacationByEntityId(vacationId).subscribe(
      res => {
        this.vacation = res;
        this.setUser(this.vacation.authorId);
        this.imageService.getImageByEntityId(res.entityId).subscribe(
          res => {
            this.vacation.image = res.content;
          },
          err => {
            console.log(err);
          }
        )
      },
      err => {
        console.log(err);
      }
    );
  }

  private setVacationJoining(vacationId: string, userId: string) {
    this.vacationService.getVacationJoiningByVacationIdAndUserId(vacationId, userId).subscribe(
      res => {
        this.vacationJoining = res;
      },
      err => {
        console.log(err);
      }
    )
  }

  isRequested() {
    return this.vacationJoining.statusJoining === StatusJoining.requested;
  }

  isAccepted() {
    return this.vacationJoining.statusJoining === StatusJoining.accepted;
  }

  
  isRejected() {
    return this.vacationJoining.statusJoining === StatusJoining.rejected;
  }

  private setUser(userId: string) {
    this.userService.getUserByEntityId(userId).subscribe(res => {
      this.currentUser = res;
      this.imageService.getImageByEntityId(res.entityId).subscribe(
        res => {
          this.currentUser.image = res.content;
        },
        err => {
          console.log(err);
        }
      )
    },
    err => {
      console.log(err);
    })
  }

  private setAuthor(userId: string) {
    this.userService.getUserByEntityId(userId).subscribe(res => {
      this.author = res;
      this.imageService.getImageByEntityId(res.entityId).subscribe(
        res => {
          this.author.image = res.content;
        },
        err => {
          console.log(err);
        }
      )
    },
    err => {
      console.log(err);
    })

  }

  isRequestVacationNotification() {
    return this.currentNotification && this.currentNotification.notificationType === NotificationType.requestVacation
  }

  isAcceptedVacationNotification() {
    return this.currentNotification && this.currentNotification.notificationType === NotificationType.acceptRequestVacation
  }

  isRejectedVacationNotification() {
    return this.currentNotification && this.currentNotification.notificationType === NotificationType.rejectRequestVacation
  }

  accept() {
    const vacationJoining: VacationJoining = {
      userId: this.author.entityId,
      vacationId:this.vacation.entityId,
      statusJoining: StatusJoining.accepted
    }
    this.vacationService.updateStatusJoining(vacationJoining).subscribe(
        res=> {
          const notification: TripNotification = {
            authorId: this.currentUser.entityId,
            vacationId: vacationJoining.vacationId,
            receiverId: this.author.entityId,
            text: this.currentUser.firstName + ' ' + this.currentUser.lastName + ' accepted your request',
            notificationType: NotificationType.acceptRequestVacation
          };
          this.notificationService.pushNotification(notification).subscribe( res => {
          },
          err => {
            console.log(err); 
          })
          location.reload();
        },
         err => console.log(err)
      );
  }

  reject() {
    const vacationJoining: VacationJoining = {
      userId: this.author.entityId,
      vacationId:this.vacation.entityId,
      statusJoining: StatusJoining.rejected
    }
    this.vacationService.updateStatusJoining(vacationJoining).subscribe(
        res=> {
          const notification: TripNotification = {
            authorId: this.currentUser.entityId,
            vacationId: vacationJoining.vacationId,
            receiverId: this.author.entityId,
            text: this.currentUser.firstName + ' ' + this.currentUser.lastName + ' rejected your request',
            notificationType: NotificationType.rejectRequestVacation
          };
          this.notificationService.pushNotification(notification).subscribe( res => {
          },
          err => {
            console.log(err); 
          })
          location.reload();
        },
         err => console.log(err)
      );
  }
}
