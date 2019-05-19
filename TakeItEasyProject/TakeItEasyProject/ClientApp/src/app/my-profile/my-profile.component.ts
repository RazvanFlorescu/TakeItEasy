import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { User } from '../shared/models/User';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})
export class MyProfileComponent implements OnInit {

  constructor(private userService: UserService) { }

  public signInClicked: boolean;

  get user() {
    return this.userService.getLoggedUser();
  }
  
  ngOnInit() {
  }
}
