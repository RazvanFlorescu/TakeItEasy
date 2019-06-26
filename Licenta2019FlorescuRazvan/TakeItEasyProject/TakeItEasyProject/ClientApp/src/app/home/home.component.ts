import { LocationService } from './../shared/services/location.service';
import { OnInit, Component } from '@angular/core';
import * as $ from 'jquery';
import { AuthenticationService } from '../shared/services/authentication.service';
import { VacationService } from '../shared/services/vacation.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public vacations;
  constructor(private vacationService: VacationService) {}

   ngOnInit() {
     this.startCarousel();
     this.setMostWanted();
   }

   private startCarousel() {
    $('.carousel .carousel-item').each(function() {
      let next = $(this).next();
      if (!next.length) {
      next = $(this).siblings(':first');
      }
      next.children(':first-child').clone().appendTo($(this));

      if (next.next().length > 0) {
      next.next().children(':first-child').clone().appendTo($(this));
      } else {
        $(this).siblings(':first').children(':first-child').clone().appendTo($(this));
      }
  });
   }

   private setMostWanted() {
     this.vacationService.getMostWanted().subscribe(
       res => {
         this.vacations = res;
       },
       err => {
         console.log(err);
       }
     )
   }
}
