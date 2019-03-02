import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule }   from '@angular/forms';
import { HeaderSideModule } from './header-side/header-side.module';
import { HomeComponent } from './home/home.component';
import { VacationComponent } from './vacation/vacation.component';
import { ProposalComponent } from './proposal/proposal.component'

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    VacationComponent,
    ProposalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HeaderSideModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
