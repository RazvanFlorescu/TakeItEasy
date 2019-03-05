import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProposalComponent } from './proposal.component';

@NgModule({
  declarations: [ ProposalComponent ],
  imports: [
    CommonModule
  ],
  exports: [ ProposalComponent ]
})
export class ProposalModule { }
