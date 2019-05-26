import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProposalComponent } from './proposal.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AddLocationComponent } from './add-location/add-location.component';
import { AddDescriptionComponent } from './add-description/add-description.component';
import { SharedModule } from '../shared/shared.module';
import { AddImageComponent } from './add-image/add-image.component';
import { FileDropModule } from 'ngx-file-drop';

@NgModule({
  declarations: [ ProposalComponent, AddLocationComponent, AddDescriptionComponent, AddImageComponent ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SharedModule,
    FileDropModule
  ],
  exports: [ ProposalComponent ]
})
export class ProposalModule { }
