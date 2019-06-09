import { Component, OnInit, Input } from '@angular/core';
import { Vacation } from '../models/Vacation';
import { ImageService } from '../services/image.service';
import { UserService } from '../services/user.service';
import { User } from '../models/User';
import {Router, NavigationExtras} from "@angular/router";

@Component({
  selector: 'app-trip-card',
  templateUrl: './trip-card.component.html',
  styleUrls: ['./trip-card.component.scss']
})
export class TripCardComponent implements OnInit {

  @Input() vacation: Vacation;
  public currentUser: User;

  constructor(private imageService: ImageService, private userService: UserService, private router:Router) { }

  ngOnInit() {
    if(this.vacation) {
      this.setCoverImage();
      this.setCurrentUser();
    }
  }

  isBiggerThan130(string: string) {
    return string.length > 130;
  }

  private setCoverImage() {
    this.imageService.getImageByEntityId(this.vacation.entityId).subscribe(
      res => {
        this.vacation.image = res!==null? res.content : undefined;
      },
      err => {
        console.log(err);
      }
    )
  }

  public onTap() {
    let navigationExtras: NavigationExtras = {
        queryParams: {
          vacation: JSON.stringify(this.vacation),
          user: JSON.stringify(this.currentUser)
        }
    };
    this.router.navigate(['vacation/details'], navigationExtras);
}

  private setCurrentUser() {
    const user = this.userService.getLoggedUser()
    if(user.entityId === this.vacation.authorId) {
      console.log("hei")
      this.currentUser = user
      console.log(user);
    }
  }

}
