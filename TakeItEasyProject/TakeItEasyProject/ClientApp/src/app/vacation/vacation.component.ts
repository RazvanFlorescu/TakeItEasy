import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { VacationService } from '../shared/services/vacation.service';
import { Vacation, LocationType } from '../shared/models/Vacation';
import { VacationFilterPipe } from '../shared/pipes/vacation-filter-pipe';

@Component({
  selector: 'app-vacation',
  templateUrl: './vacation.component.html',
  styleUrls: ['./vacation.component.scss']
})
export class VacationComponent implements OnInit {

  constructor(private userService: UserService, private vacationService: VacationService, private vacationpipe: VacationFilterPipe) { }

  vacations: Vacation[];
  @ViewChild('divToScroll') divToScroll: ElementRef;
  showDropDown = false;
  searchString = '';

  ngOnInit() {
    this.vacationService.getAllPublicVacations().subscribe(
      res => {
        this.vacations = res;
      },
      err => {
        console.log(err);
      }
    );
  }

  toggleDropDown() {
    setTimeout( () => { this.showDropDown = !this.showDropDown; }, 20 );;
  }

  selectVacation(address: string) {
    this.searchString = address;
    this.showDropDown = false;
  }

  getDestinationAddress(vacation: Vacation) {
    return vacation.vacationPoints.filter(point => point.locationType === LocationType.destination)[0].address;
  }

  goToVacations() {
   document.getElementById('scrollHere').scrollIntoView({behavior: "smooth", block: "start", inline: "nearest"});
  }

  getVacationsFiltred() {
    return this.vacationpipe.transform(this.vacations, this.searchString) 
  }
}
