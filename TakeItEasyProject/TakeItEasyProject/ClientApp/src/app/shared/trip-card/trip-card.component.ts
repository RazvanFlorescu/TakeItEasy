import { Component, OnInit, Input } from '@angular/core';
import { Vacation } from '../models/Vacation';
import { ImageService } from '../services/image.service';
import { UserService } from '../services/user.service';
import { User } from '../models/User';


@Component({
  selector: 'app-trip-card',
  templateUrl: './trip-card.component.html',
  styleUrls: ['./trip-card.component.scss']
})
export class TripCardComponent implements OnInit {

  @Input() vacation: Vacation;
  public currentUser: User;

  constructor(private imageService: ImageService, private userService: UserService) { }

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

  private setCurrentUser() {
    const user = this.userService.getLoggedUser()
    if(user.entityId === this.vacation.authorId) {
      console.log("hei")
      this.currentUser = user
      console.log(user);
    }
  }

}
