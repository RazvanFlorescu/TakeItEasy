import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProposalComponent } from './proposal.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AddLocationComponent } from './add-location/add-location.component';
import { AddDescriptionComponent } from './add-description/add-description.component';
import { SharedModule } from '../shared/shared.module';
import { AddImageComponent } from './add-image/add-image.component';
import { FileDropModule } from 'ngx-file-drop';
import { AgmCoreModule } from '@agm/core';
import { AgmDirectionModule } from 'agm-direction' 
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [ ProposalComponent, AddLocationComponent, AddDescriptionComponent, AddImageComponent ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    FileDropModule,
    AgmCoreModule.forRoot({
     // apiKey: 'AIzaSyA9bGZv1g2dvSGhbs4sc045YfT4RbaVwkI'
    }),
    AgmDirectionModule
  ],
  exports: [ ProposalComponent ]
})
export class ProposalModule { }
