import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  private isMenuOpen: boolean;

  constructor() { }
  
  ngOnInit() {
    this.isMenuOpen = false;
  }

  public openMenu(){
    this.isMenuOpen = true;
  }

  public closeMenu(){
    this.isMenuOpen = false;
  }
}
