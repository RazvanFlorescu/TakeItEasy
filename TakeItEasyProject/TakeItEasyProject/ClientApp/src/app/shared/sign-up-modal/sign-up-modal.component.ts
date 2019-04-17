import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-up-modal',
  templateUrl: './sign-up-modal.component.html',
  styleUrls: ['./sign-up-modal.component.scss']
})
export class SignUpModalComponent implements OnInit {
  signupFormModalName = new FormControl('', Validators.required);
  signupFormModalEmail = new FormControl('', Validators.email);
  signupFormModalPassword = new FormControl('', Validators.required);

  constructor( ) { }

  ngOnInit() {
  }

}
