import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';
  public signUpClicked: boolean;

  public onSignUp(event) {
    console.log(event);
    console.log('here');
    // this.signUpClicked = event;
  }
}
