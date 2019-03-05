import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LocationService } from './services/location.service';
import { MenuComponent } from './menu/menu.component';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [MenuComponent, HeaderComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [MenuComponent, HeaderComponent],
  providers: [LocationService]
})
export class SharedModule { }
