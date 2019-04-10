import { LocationService } from './../shared/services/location.service';
import { OnInit, Component } from '@angular/core';
import * as $ from "jquery";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
   public constructor(private locationService: LocationService) {}

   public ngOnInit() { 
        //this.locationService.getCurrentLocation();
        $('.carousel .carousel-item').each(function(){
          var next = $(this).next();
          if (!next.length) {
          next = $(this).siblings(':first');
          }
          next.children(':first-child').clone().appendTo($(this));
          
          if (next.next().length>0) {
          next.next().children(':first-child').clone().appendTo($(this));
          }
          else {
            $(this).siblings(':first').children(':first-child').clone().appendTo($(this));
          }
      });
   }
}
