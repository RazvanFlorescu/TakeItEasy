import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LocationService } from './services/location.service';
import { MenuComponent } from './menu/menu.component';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { FooterComponent } from './footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { SignInModalComponent } from './sign-in-modal/sign-in-modal.component';
import { SignUpModalComponent } from './sign-up-modal/sign-up-modal.component';

@NgModule({
  declarations: [MenuComponent, HeaderComponent, FooterComponent, SignInModalComponent, SignUpModalComponent],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule
  ],
  exports: [MenuComponent, HeaderComponent, FooterComponent, SignInModalComponent, SignUpModalComponent],
  providers: [LocationService]
})
export class SharedModule { }
