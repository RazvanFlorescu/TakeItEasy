import { Component } from '@angular/core';
import { User } from './shared/models/User';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  public signUpClicked: boolean;
  public signInClicked: boolean;
  public userLoggedIn: User;

  public onSignUp(event) {
    this.signUpClicked = event;
  }

  public onSignIn(event) {
    this.signInClicked = event;
  }

  public onUserLoggedIn(event) {
    this.userLoggedIn = event;
  }
}
