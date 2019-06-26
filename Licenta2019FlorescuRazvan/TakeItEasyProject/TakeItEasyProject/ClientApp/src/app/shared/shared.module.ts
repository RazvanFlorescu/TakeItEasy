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
import { AddTripCardComponent } from './add-trip-card/add-trip-card.component';
import { InfoComponent } from './info/info.component';
import { AutocompleteLocationComponent } from './autocomplete-location/autocomplete-location.component';
import { AgmCoreModule } from '@agm/core';
import { TimeAgoPipe } from 'time-ago-pipe';
import { ClickOutsideModule } from 'ng-click-outside';
import { NotificationPageComponent } from './notification-page/notification-page.component';
import { VacationFilterPipe } from './pipes/vacation-filter-pipe';

@NgModule({
  declarations: [MenuComponent, HeaderComponent, FooterComponent,
     SignInModalComponent, SignUpModalComponent, UploadUserImageComponent, TripCardComponent,
     AddTripCardComponent, InfoComponent, AutocompleteLocationComponent, TimeAgoPipe, NotificationPageComponent],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule.forRoot(),
    MDBBootstrapModule,
    ModalModule,
    FileDropModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyA9bGZv1g2dvSGhbs4sc045YfT4RbaVwkI'
    }),
    ClickOutsideModule,
  ],
  exports: [MenuComponent, HeaderComponent, FooterComponent,
     SignInModalComponent, SignUpModalComponent, TripCardComponent,
     AddTripCardComponent, InfoComponent, UploadUserImageComponent,
     AutocompleteLocationComponent, TimeAgoPipe],
  providers: [LocationService, ModalDirective, VacationFilterPipe]
})
export class SharedModule { }
