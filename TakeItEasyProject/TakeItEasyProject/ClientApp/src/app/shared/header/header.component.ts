import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ModalService } from '../services/modal.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  private isMenuOpen: boolean;

  @Output() public showSignUpModal = new EventEmitter();

  constructor(private modalService: ModalService) {
  }

  ngOnInit() {
    this.isMenuOpen = false;
  }

  public openMenu() {
    this.isMenuOpen = true;
  }

  public closeMenu() {
    this.isMenuOpen = false;
  }

  public openSignUpModal() {
    this.showSignUpModal.emit({'ceva': 'tralala'});
  }
}
