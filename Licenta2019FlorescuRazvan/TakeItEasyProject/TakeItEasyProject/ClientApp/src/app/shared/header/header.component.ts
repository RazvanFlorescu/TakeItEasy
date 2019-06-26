import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserService } from '../services/user.service';
import { NotificationService } from '../services/notification.service';
import { TripNotification, NotificationType } from '../models/TripNotification';
import { ImageService } from '../services/image.service';
import { Router, NavigationExtras, NavigationEnd } from '@angular/router';
import { VacationService } from '../services/vacation.service';
import { Vacation } from '../models/Vacation';
import { User } from '../models/User';
import { WishItem } from '../models/WishItem';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public isMenuOpen: boolean;
  public notifications: TripNotification[];
  public wishList: WishItem[];
  public showNotification = false;
  public showWishList = false;
  public showRemoveToastr = false;

  @Output() public showSignUpModal = new EventEmitter();
  @Output() public showSignInModal = new EventEmitter();

  constructor(private userService: UserService, private vacationService: VacationService,private notificationService: NotificationService, private imageService: ImageService, private router: Router) {
  }

  private triggerSignUp = true;
  private triggerSignIn = true;

  get user() {
    return this.userService.getLoggedUser();
  } 

  ngOnInit() {
    this.isMenuOpen = false;
    this.setNotifications();
    this.setWishList();
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
                if(this.notifications[i].authorId ==='01BAED71-9258-42B5-997F-4831FB06EEDB'.toLowerCase()){
                  this.notifications[i].userPicture = "./../../../assets/images/takeItEasy.jpg"
                }else {
                  this.notifications[i].userPicture = res.content;
                }
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

  public setWishList() {
    const userId =  this.userService.getLoggedUser().entityId;
    this.vacationService.getWishItemsByUserId(userId).subscribe(
      res => {
        console.log(res);
        this.wishList = res;
      },
      err => {
        console.log(err);
      }
    );
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

  public displayWishlist() {
    this.showWishList = !this.showWishList;
  }

  public hideNotifications() {
    this.showNotification = false;
  }

  public hideWishlist() {
    this.showWishList = false;
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
    console.log(notificationB.authorId);
    if(notificationB.authorId.toLowerCase() === '01BAED71-9258-42B5-997F-4831FB06EEDB'.toLowerCase()) {
      var vacation: Vacation;
      var user: User;
      this.vacationService.getVacationByEntityId(notificationB.vacationId).subscribe(
        res => {
          vacation = res;
           this.userService.getUserByEntityId(vacation.authorId).subscribe(
            res => {
              user = res;
              if(notificationB.notificationType === NotificationType.wishItem){
                let navigationExtras: NavigationExtras = {
                
                  queryParams: {
                    vacation: JSON.stringify(vacation),
                    user: JSON.stringify(user)
                  }
              };
              this.router.navigate(['vacation/details'], navigationExtras);
              return;
              }
              let navigationExtras: NavigationExtras = {
        
                queryParams: {
                  notification: JSON.stringify(notificationB),
                }
              };
              this.router.navigate(['notification'], navigationExtras);
            },
            err => {
              console.log(err);
            }
          )
        },
        err => {
          console.log(err);
        }
      )
      return;
    }

    let navigationExtras: NavigationExtras = {
        
        queryParams: {
          notification: JSON.stringify(notificationB),
        }
      };
      this.router.navigate(['notification'], navigationExtras);
  }

  public isBiggerThan34(text: string) {
    return text.length > 40; 
  }

  removeWishItem(wishItem: WishItem) {
    this.vacationService.removeWishItem(wishItem).subscribe(
      res => {
        this.showRemoveToastr = true;
        location.reload();
      },
      err => {
        console.log(err);
      }
    );
  }
}
