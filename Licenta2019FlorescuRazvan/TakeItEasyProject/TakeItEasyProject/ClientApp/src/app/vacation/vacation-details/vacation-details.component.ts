import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/shared/models/User';
import { Vacation, TripLocation, VacationJoining, StatusJoining } from 'src/app/shared/models/Vacation';
import { ImageService } from 'src/app/shared/services/image.service';
import { UserService } from 'src/app/shared/services/user.service';
import { VacationService } from 'src/app/shared/services/vacation.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { TripNotification, NotificationType } from 'src/app/shared/models/TripNotification';

@Component({
  selector: 'app-vacation-details',
  templateUrl: './vacation-details.component.html',
  styleUrls: ['./vacation-details.component.scss']
})
export class VacationDetailsComponent implements OnInit {

  currentUser: User;
  vacation: Vacation;
  vacationJoining: VacationJoining;

  public renderOptions = {
    suppressMarkers: true,
  }
  
  public markerOptions = {
    origin: {
        icon: './../../../assets/images/location.png',
    },
    destination: {
        icon: './../../../assets/images/location.png',
    },
    waypoints: {
        icon: './../../../assets/images/point.png',
    }
  }

  origin;
  destination;
  wayPoints;

  showToastr = false;

  constructor(private vacationService: VacationService, private notificationService: NotificationService, private userService: UserService, private route: ActivatedRoute, private imageService: ImageService) { 
  }

  get user() {
    return this.userService.getLoggedUser();
  }
  
  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.currentUser = JSON.parse(params['user']);
      this.vacation = JSON.parse( params['vacation']);
      this.setCurrentLocation(this.vacation.vacationPoints);
      this.setImages();
      this.setJoining();
  });
  }

  setCurrentLocation(locations: TripLocation[]): void {
    console.log(locations);
    this.origin = {
      lat: Number(locations[0].latitude),
      lng: Number(locations[0].longitude),
    }

    this.destination = {
      lat: Number(locations[locations.length -1].latitude),
      lng: Number(locations[locations.length -1].longitude)
    }

    this.wayPoints = [];
    if(locations.length > 2) {
      for(let i = 1; i < locations.length-1; i++){
        this.wayPoints.push({
          location: {
            "lat": Number(locations[i].latitude),
            "lng": Number(locations[i].longitude)
          },
          stopover: false
        });
      }
    }
  }

private setImages() {
  this.imageService.getImageByEntityId(this.vacation.entityId).subscribe(
    res => {
      this.vacation.image = res!==null? res.content : undefined;
    },
    err => {
      console.log(err);
    }
  )

  this.imageService.getImageByEntityId(this.currentUser.entityId).subscribe(
    res => {
      this.currentUser.image = res!==null? res.content : undefined;
    },
    err => {
      console.log(err);
    }
  )
}

private setJoining() {
  this.vacationService.getVacationJoiningByVacationIdAndUserId(this.vacation.entityId, this.userService.getLoggedUser().entityId).subscribe(
    res => {
      this.vacationJoining = res
    },
    err => {
      console.log(err);
    }
  )
}

  showToaster() {
    this.showToastr = true;
  }

  cancel() {
    this.showToastr = false;
  }

  sendRequest() {
    const vacationJoining: VacationJoining = {
      userId: this.userService.getLoggedUser().entityId,
      vacationId: this.vacation.entityId
    }

    this.vacationService.join(vacationJoining).subscribe( res => {
      this.showToastr = false;
     },
     err => {
       console.log(err);
     }
    );

    const notification: TripNotification = {
      authorId: this.userService.getLoggedUser().entityId,
      vacationId: this.vacation.entityId,
      receiverId: this.currentUser.entityId,
      text: this.userService.getLoggedUser().firstName + ' ' + this.userService.getLoggedUser().lastName + ' sent you a request.',
      notificationType: NotificationType.requestVacation
    };
    this.notificationService.pushNotification(notification).subscribe( res => {
      this.setJoining();
    },
    err => {
      console.log(err); 
    })
  }

  isRequested() {
    return this.vacationJoining.statusJoining ===  StatusJoining.requested;
  }

  isAccepted() {
    return this.vacationJoining.statusJoining ===  StatusJoining.accepted;
  }

  isRejected() {
    return this.vacationJoining.statusJoining ===  StatusJoining.rejected;
  }

}
