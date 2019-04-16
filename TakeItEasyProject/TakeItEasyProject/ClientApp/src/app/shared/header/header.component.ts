import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SignUpModalComponent } from '../sign-up-modal/sign-up-modal.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  private isMenuOpen: boolean;

  constructor(private modalService: NgbModal) {
  }

  ngOnInit() {
    this.isMenuOpen = false;
    // this.openVerticallyCentered(SignUpModalComponent);
  }

  public openMenu() {
    this.isMenuOpen = true;
  }

  public closeMenu() {
    this.isMenuOpen = false;
  }


  openVerticallyCentered(content) {
    this.modalService.open(content, { centered: true });
  }
}
