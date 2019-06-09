import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VacationComponent } from './vacation.component';
import { ClickOutsideModule } from 'ng-click-outside';
import { VacationFilterPipe } from '../shared/pipes/vacation-filter-pipe';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [ VacationComponent, VacationFilterPipe ],
  imports: [
    CommonModule,
    ClickOutsideModule,
    SharedModule,
    FormsModule
  ],
  exports: [ VacationComponent, VacationFilterPipe ]
})
export class VacationModule { }
