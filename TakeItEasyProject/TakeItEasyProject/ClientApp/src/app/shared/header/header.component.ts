import { Component, OnInit, Output, Input, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { User } from '../models/User';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnChanges {

  public isMenuOpen: boolean;

  @Output() public showSignUpModal = new EventEmitter();
  @Output() public showSignInModal = new EventEmitter();
  @Input() public userLoggedInEvent: User;

  constructor( ) {
  }

  private triggerSignUp = true;
  private triggerSignIn = true;

  ngOnInit() {
    this.isMenuOpen = false;
  }

  ngOnChanges(changes: SimpleChanges) {
    // tslint:disable-next-line:forin
    for (const propName in changes) {
      const change = changes[propName];
      if ((change.currentValue || change.previousValue) && propName === 'userLoggedInEvent') {
        console.log("asdasdasdasd");
      }
    }
  }

  public openMenu() {
    this.isMenuOpen = true;
  }

  public closeMenu() {
    this.isMenuOpen = false;
    console.log(this.userLoggedInEvent);
  }

  public openSignUpModal() {
    this.showSignUpModal.emit(this.triggerSignUp);
    this.triggerSignUp = !this.triggerSignUp;
  }

  public openSignInModal() {
    this.showSignInModal.emit(this.triggerSignIn);
    this.triggerSignIn = !this.triggerSignIn;
  }
}
