import { Component, ViewChild, Input, OnChanges, SimpleChanges } from '@angular/core';
import { ModalDirective } from 'angular-bootstrap-md';


@Component({
  selector: 'app-sign-up-modal',
  templateUrl: './sign-up-modal.component.html',
  styleUrls: ['./sign-up-modal.component.scss']
})
export class SignUpModalComponent implements OnChanges  {

  fullName: String;
  email: String;
  password: String;
  @Input() public signUpEvent;

  @ViewChild ('frame') public formModal: ModalDirective;

  constructor( ) { }

  ngOnChanges(changes: SimpleChanges) {
    for (let propName in changes) {  
        let change = changes[propName];
      
        if ((change.currentValue || change.previousValue) && propName === "signUpEvent") {
          this.formModal.show();
        } 
     }
  }

  closeSignUpModal() {
     this.formModal.hide();  
  }

}
