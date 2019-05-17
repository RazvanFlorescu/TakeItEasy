import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProposalComponent } from './proposal.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AddTimeComponent } from './add-time/add-time.component';
import { AddLocationComponent } from './add-location/add-location.component';
import { AddDescriptionComponent } from './add-description/add-description.component';

@NgModule({
  declarations: [ ProposalComponent, AddTimeComponent, AddLocationComponent, AddDescriptionComponent ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [ ProposalComponent ]
})
export class ProposalModule { }
