import { Component, Input, ViewChild, SimpleChanges, OnChanges } from '@angular/core';
import { ModalDirective } from 'angular-bootstrap-md';

@Component({
  selector: 'app-sign-in-modal',
  templateUrl: './sign-in-modal.component.html',
  styleUrls: ['./sign-in-modal.component.scss']
})
export class SignInModalComponent implements OnChanges {

  email: String;
  password: String;
  @Input() public signInEvent;

  @ViewChild ('frame') public formModal: ModalDirective;

  constructor( ) { }

  ngOnChanges(changes: SimpleChanges) {
    for (let propName in changes) {  
        let change = changes[propName];
      
        if ((change.currentValue || change.previousValue) && propName === "signInEvent") {
          this.formModal.show();
        } 
     }
  }

  closeSignInModal() {
     this.formModal.hide();  
  }

}
