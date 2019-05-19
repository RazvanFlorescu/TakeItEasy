import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public isMenuOpen: boolean;

  @Output() public showSignUpModal = new EventEmitter();
  @Output() public showSignInModal = new EventEmitter();

  constructor(private userService: UserService) {
  }

  private triggerSignUp = true;
  private triggerSignIn = true;

  get user() {
    return this.userService.getLoggedUser();
  } 

  ngOnInit() {
    this.isMenuOpen = false;
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
  }
}
