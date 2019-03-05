import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VacationComponent } from './vacation.component';

@NgModule({
  declarations: [ VacationComponent ],
  imports: [
    CommonModule
  ],
  exports: [ VacationComponent ]
})
export class VacationModule { }
