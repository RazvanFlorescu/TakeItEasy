import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  private isMenuOpen: boolean;

  @Output() public showSignUpModal = new EventEmitter();
  @Output() public showSignInModal = new EventEmitter();

  constructor( ) {
  }
  
  private triggerSignUp: boolean = true;
  private triggerSignIn: boolean = true;

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
}
