import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  public signUpClicked: boolean;
  public signInClicked: boolean;
  
  public onSignUp(event) {
    this.signUpClicked = event;
  }

  public onSignIn(event) {
    this.signInClicked = event;
  }
}
