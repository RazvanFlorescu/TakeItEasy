import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-up-modal',
  templateUrl: './sign-up-modal.component.html',
  styleUrls: ['./sign-up-modal.component.scss']
})
export class SignUpModalComponent implements OnInit {
  fullName: String;
  email: String = '';
  password: String;

  signupFormModalName = new FormControl(this.fullName, Validators.required);
  signupFormModalEmail = new FormControl(this.email, Validators.email);
  signupFormModalPassword = new FormControl(this.password, Validators.required);

  constructor( ) { }

  ngOnInit() {
    console.log(this.signupFormModalEmail.value);
  }

}
