import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'angular-bootstrap-md';


@Component({
  selector: 'app-sign-up-modal',
  templateUrl: './sign-up-modal.component.html',
  styleUrls: ['./sign-up-modal.component.scss']
})
export class SignUpModalComponent implements OnInit {
  fullName: String;
  email: String;
  password: String;
   @ViewChild ('frame') public formModal: ModalDirective;

  constructor( ) { }

  ngOnInit() {
    // tslint:disable-next-line:no-unused-expression
    this.formModal.show();
  }

}
