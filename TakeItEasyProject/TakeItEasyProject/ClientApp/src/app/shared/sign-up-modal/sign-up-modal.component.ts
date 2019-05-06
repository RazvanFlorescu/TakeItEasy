import { Component, ViewChild, Input, OnChanges, SimpleChanges, OnInit} from '@angular/core';
import { ModalDirective } from 'angular-bootstrap-md';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { User } from '../models/User';


@Component({
  selector: 'app-sign-up-modal',
  templateUrl: './sign-up-modal.component.html',
  styleUrls: ['./sign-up-modal.component.scss']
})
export class SignUpModalComponent implements OnChanges, OnInit  {

  userAccount: FormGroup;

  @Input() public signUpEvent;
  @Input() public user: User;

  @ViewChild ('frame') public formModal: ModalDirective;

  constructor( private userService: UserService ) { }

  ngOnInit() {
    this.user = new User();
    this.setUserAccountValidators();
  }

  ngOnChanges(changes: SimpleChanges) {
    // tslint:disable-next-line:forin
    for (const propName in changes) {
      const change = changes[propName];
      if ((change.currentValue || change.previousValue) && propName === 'signUpEvent') {
        this.formModal.show();
      }
    }
  }

  closeSignUpModal() {
     this.formModal.hide();
  }

  private setUserAccountValidators() {
    this.userAccount = new FormGroup({
      firstName: new FormControl(this.user.firstName, [Validators.required, Validators.maxLength(20), Validators.pattern('[a-zA-Z0-9\s]+')]),
      lastName: new FormControl(this.user.lastName, [Validators.required, Validators.maxLength(20), Validators.pattern('[a-zA-Z0-9\s]+')]),
      email: new FormControl(this.user.email, [Validators.required, Validators.maxLength(30), Validators.pattern('[^ @]*@[^ @]*.*[+.].+')]),
      password: new FormControl(this.user.password, [Validators.required, Validators.minLength(6)]),
    });
  }

  get firstNameField() { return this.userAccount.get('firstName'); }

  get lastNameField() { return this.userAccount.get('lastName'); }

  get emailField() { return this.userAccount.get('email'); }

  get passwordField() { return this.userAccount.get('password'); }

}
