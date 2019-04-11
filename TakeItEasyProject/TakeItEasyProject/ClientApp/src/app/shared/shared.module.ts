import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LocationService } from './services/location.service';
import { MenuComponent } from './menu/menu.component';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { FooterComponent } from './footer/footer.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [MenuComponent, HeaderComponent, FooterComponent],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule
  ],
  exports: [MenuComponent, HeaderComponent, FooterComponent],
  providers: [LocationService]
})
export class SharedModule { }
