import { LocationService } from './../shared/services/location.service';
import { OnInit, Component } from '@angular/core';
import * as $ from 'jquery';
import { AuthenticationService } from '../shared/services/authentication.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
   public constructor(private locationService: LocationService, private authenticationService: AuthenticationService) {}

   public ngOnInit() {
       // this.authenticationService.login().subscribe(data =>
         // console.log(data));
        // this.locationService.getCurrentLocation();
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
}
