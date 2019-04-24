import { Component, Input, ViewChild, SimpleChanges, OnChanges, OnInit } from '@angular/core';
import { ModalDirective } from 'angular-bootstrap-md';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-in-modal',
  templateUrl: './sign-in-modal.component.html',
  styleUrls: ['./sign-in-modal.component.scss']
})
export class SignInModalComponent implements OnChanges, OnInit {

  private email: String = '';
  private password: String = '';
  userAccount: FormGroup;

  @Input() public signInEvent;

  @ViewChild ('frame') public formModal: ModalDirective;

  constructor( ) { }

  ngOnInit() {
    this.setUserAccountValidators();
  }

  ngOnChanges(changes: SimpleChanges) {
    // tslint:disable-next-line:forin
    for (const propName in changes) {
        const change = changes[propName];

        if ((change.currentValue || change.previousValue) && propName === 'signInEvent') {
          this.formModal.show();
        }
     }
  }

  closeSignInModal() {
     this.formModal.hide();
  }

  get emailField() { return this.userAccount.get('email'); }

  get passwordField() { return this.userAccount.get('password'); }

  private setUserAccountValidators() {
    this.userAccount = new FormGroup({
      email: new FormControl(this.email, [Validators.required, Validators.maxLength(30), Validators.pattern('[^ @]*@[^ @]*.*[+.].+')]),
      password: new FormControl(this.password, [Validators.required, Validators.minLength(6)]),
    });
  }

}
