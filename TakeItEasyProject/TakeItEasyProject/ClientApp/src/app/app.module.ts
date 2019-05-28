import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AgmCoreModule } from '@agm/core';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HomeModule } from './home/home.module';
import { VacationModule } from './vacation/vacation.module';
import { ProposalModule } from './proposal/proposal.module';
import { SharedModule } from './shared/shared.module';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { MyProfileModule } from './my-profile/my-profile.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HomeModule,
    VacationModule,
    ProposalModule,
    SharedModule,
    MyProfileModule,
    MDBBootstrapModule.forRoot(),
    AgmCoreModule.forRoot({
      apiKey:'AIzaSyA9bGZv1g2dvSGhbs4sc045YfT4RbaVwkI'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
