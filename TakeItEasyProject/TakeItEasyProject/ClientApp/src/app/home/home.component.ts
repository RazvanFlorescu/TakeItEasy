import { LocationService } from './../shared/services/location.service';
import { OnInit, Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
   public constructor(private locationService: LocationService) {}

   public ngOnInit() { 
        this.locationService.getCurrentLocation();
   }
}
