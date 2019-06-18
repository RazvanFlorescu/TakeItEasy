import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserService } from '../services/user.service';
import { NotificationService } from '../services/notification.service';
import { TripNotification } from '../models/TripNotification';
import { ImageService } from '../services/image.service';
import { Router, NavigationExtras, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public isMenuOpen: boolean;
  public notifications: TripNotification[];
  public showNotification = false;

  @Output() public showSignUpModal = new EventEmitter();
  @Output() public showSignInModal = new EventEmitter();

  constructor(private userService: UserService, private notificationService: NotificationService, private imageService: ImageService, private router: Router) {
  }

  private triggerSignUp = true;
  private triggerSignIn = true;

  get user() {
    return this.userService.getLoggedUser();
  } 

  ngOnInit() {
    this.isMenuOpen = false;
    this.setNotifications();
  }

  public setNotifications() {
    this.notificationService.getNotificationsByUserId(this.userService.getLoggedUser().entityId).subscribe(
      res => {
        console.log(res);
        this.notifications = res;
        if(this.notifications.length > 0) {
          for(let i = 0; i < this.notifications.length; i++){
            this.imageService.getImageByEntityId(this.notifications[i].authorId).subscribe(
              res =>{
                this.notifications[i].userPicture = res.content;
              },
              err => {
                console.log(err);
              }
            );  
          }
        }
      },
      err => {
        console.log(err);
      }
    )
  }

  public openMenu() {
    this.isMenuOpen = true;
  }

  public closeMenu() {
    this.isMenuOpen = false;
  }

  public openSignUpModal() {
    this.showSignUpModal.emit(this.triggerSignUp);
    this.triggerSignUp = !this.triggerSignUp;
  }

  public openSignInModal() {
    this.showSignInModal.emit(this.triggerSignIn);
    this.triggerSignIn = !this.triggerSignIn;
  }

  public logOut() {
    this.userService.logOut();
    location.reload();
  }

  public displayNotifications() {
    this.showNotification = !this.showNotification;
  }

  public hideNotifications() {
    this.showNotification = false;
  }

  public showRedPiontNotification() {
    return this.notifications && this.notifications.find(n=> n.isViewed !== true);
  }

  public openNotification(notification: TripNotification) {
    if(notification.isViewed === false)
    {
      notification.isViewed = true;
      this.notificationService.updateNotification(notification).subscribe(
        err => console.log(err)
      );
    }
      
    var notificationB: TripNotification = {
      authorId: notification.authorId,
      entityId: notification.entityId,
      vacationId: notification.vacationId,
      userPicture: null,
      receiverId: notification.receiverId,
      lastChangedDate: notification.lastChangedDate,
      notificationType: notification.notificationType,
      isViewed: notification.isViewed,
      text: notification.text
    };

    let navigationExtras: NavigationExtras = {
        
        queryParams: {
          notification: JSON.stringify(notificationB),
        }
      };
      this.router.navigate(['notification'], navigationExtras);
  }
}
