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
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MDBBootstrapModule, ModalModule, ModalDirective } from 'angular-bootstrap-md';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { UploadUserImageComponent } from './upload-user-image/upload-user-image.component';
import { FileDropModule } from 'ngx-file-drop';
import { TripCardComponent } from './trip-card/trip-card.component';

@NgModule({
  declarations: [MenuComponent, HeaderComponent, FooterComponent, SignInModalComponent, SignUpModalComponent, UploadUserImageComponent, TripCardComponent],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule.forRoot(),
    MDBBootstrapModule,
    ModalModule,
    FileDropModule
  ],
  exports: [MenuComponent, HeaderComponent, FooterComponent, SignInModalComponent, SignUpModalComponent, TripCardComponent],
  providers: [LocationService, ModalDirective]
})
export class SharedModule { }
