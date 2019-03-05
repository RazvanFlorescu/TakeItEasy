import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule }   from '@angular/forms';
import { HomeModule } from './home/home.module';
import { VacationModule } from './vacation/vacation.module';
import { ProposalModule } from './proposal/proposal.module';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HomeModule,
    VacationModule,
    ProposalModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
