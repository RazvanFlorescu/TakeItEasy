import { Component, Input, ViewChild, SimpleChanges, OnChanges, OnInit } from '@angular/core';
import { ModalDirective } from 'angular-bootstrap-md';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { User } from '../models/User';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-sign-in-modal',
  templateUrl: './sign-in-modal.component.html',
  styleUrls: ['./sign-in-modal.component.scss']
})
export class SignInModalComponent implements OnChanges, OnInit {

  public user: User;
  userAccount: FormGroup;
  errorMessage: string;

  @Input() public signInEvent;

  @ViewChild ('frame') public formModal: ModalDirective;

  constructor(private userService: UserService) { }

  get emailField() { return this.userAccount.get('email'); }

  get passwordField() { return this.userAccount.get('password'); }

  ngOnInit() {
    this.user = new User();
    this.setUserAccountValidators();
  }

  ngOnChanges(changes: SimpleChanges) {
    // tslint:disable-next-line:forin
    for (const propName in changes) {
        const change = changes[propName];

        if ((change.currentValue || change.previousValue) && propName === 'signInEvent') {
          console.log("am intrat")
          this.formModal.show();
        }
     }
  }

  closeSignInModal() {
     this.formModal.hide();
  }

  loginUser() {
    this.mapUserInputs();

    this.userService.login(this.user).subscribe(
      res => {
        this.userService.setLoggedUser(res);
        this.closeSignInModal();
      },
      err => {
        console.log(err);
        this.errorMessage = err.error;
      }
    );
  }

  private setUserAccountValidators() {
    this.userAccount = new FormGroup({
      email: new FormControl(this.user.email, [Validators.required, Validators.maxLength(30), Validators.pattern('[^ @]*@[^ @]*.*[+.].+')]),
      password: new FormControl(this.user.password, [Validators.required, Validators.minLength(6)]),
    });
  }

  private mapUserInputs(): void {
    this.user.email = this.emailField.value;
    this.user.password = this.passwordField.value;
}

}
