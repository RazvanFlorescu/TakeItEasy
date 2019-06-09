import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VacationComponent } from './vacation.component';
import { ClickOutsideModule } from 'ng-click-outside';
import { VacationFilterPipe } from '../shared/pipes/vacation-filter-pipe';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { VacationDetailsComponent } from './vacation-details/vacation-details.component';

@NgModule({
  declarations: [ VacationComponent, VacationFilterPipe, VacationDetailsComponent ],
  imports: [
    CommonModule,
    ClickOutsideModule,
    SharedModule,
    FormsModule
  ],
  exports: [ VacationComponent, VacationFilterPipe, VacationDetailsComponent ]
})
export class VacationModule { }
