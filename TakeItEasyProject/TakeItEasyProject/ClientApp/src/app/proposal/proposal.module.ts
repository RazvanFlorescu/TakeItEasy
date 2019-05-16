import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProposalComponent } from './proposal.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [ ProposalComponent ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [ ProposalComponent ]
})
export class ProposalModule { }
