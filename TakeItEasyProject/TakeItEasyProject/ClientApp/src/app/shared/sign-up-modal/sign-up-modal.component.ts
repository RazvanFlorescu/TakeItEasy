import { Component, ViewChild, AfterViewInit, OnInit, Input } from '@angular/core';
import { ModalDirective } from 'angular-bootstrap-md';
import { ModalService } from '../services/modal.service';


@Component({
  selector: 'app-sign-up-modal',
  templateUrl: './sign-up-modal.component.html',
  styleUrls: ['./sign-up-modal.component.scss']
})
export class SignUpModalComponent implements AfterViewInit  {

  fullName: String;
  email: String;
  password: String;
  @Input() public signUpEvent: boolean;

  @ViewChild ('frame') public formModal: ModalDirective;

  constructor(private modalService: ModalService ) { }

  ngAfterViewInit(): void {
    // this.formModal.show();
    if (this.signUpEvent === true) {
       this.formModal.show();
    }
  }

}
