import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Vacation } from '../models/Vacation';
import { ImageService } from '../services/image.service';
import { UserService } from '../services/user.service';
import { User } from '../models/User';
import { Router, NavigationExtras } from "@angular/router";

@Component({
  selector: 'app-trip-card',
  templateUrl: './trip-card.component.html',
  styleUrls: ['./trip-card.component.scss']
})
export class TripCardComponent implements OnInit {

  @Input() vacation: Vacation;
  @Output() imageIsLoaded: EventEmitter<any> = new EventEmitter();;
  public currentUser: User;

  constructor(private imageService: ImageService, private userService: UserService, private router:Router) { }

  ngOnInit() {
    if(this.vacation) {
      this.setCoverImage();
      this.setCurrentUser(this.vacation.authorId);
    }
  }

  isBiggerThan130(string: string) {
    return string.length > 130;
  }

  private setCoverImage() {
    this.imageService.getImageByEntityId(this.vacation.entityId).subscribe(
      res => {
        this.vacation.image = res!==null? res.content : undefined;
        this.imageIsLoaded.emit(true);
      },
      err => {
        console.log(err);
      }
    )
  }

  private setImageUser(entityId: string) {
    this.imageService.getImageByEntityId(entityId).subscribe(
      res => {
        console.log(res);
        this.currentUser.image = res!==null? res.content : undefined;
      },
      err => {
        console.log(err);
      }
    )
  }

  public onTap() {
    this.vacation.image = null;
    this.currentUser.image = null;
    let navigationExtras: NavigationExtras = {
        
        queryParams: {
          vacation: JSON.stringify(this.vacation),
          user: JSON.stringify(this.currentUser)
        }
    };
    this.router.navigate(['vacation/details'], navigationExtras);
}

  private setCurrentUser(authorId: string) {
    this.userService.getUserByEntityId(authorId).subscribe(
      res => {
        this.currentUser = res;
        console.log(res);
        this.setImageUser(this.currentUser.entityId);
      },
      err => {
        console.log(err);
      }
     );
  }
}
