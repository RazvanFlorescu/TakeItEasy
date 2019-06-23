import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import {} from '@agm/core/services/google-maps-types';
import { TripLocation, LocationType } from 'src/app/shared/models/Vacation';
import { VacationService } from 'src/app/shared/services/vacation.service';
import { WishItem } from 'src/app/shared/models/WishItem';
import { UserService } from 'src/app/shared/services/user.service';
import { Router } from '@angular/router';

declare const google: any;
@Component({
  selector: 'app-wish-list',
  templateUrl: './wish-list.component.html',
  styleUrls: ['./wish-list.component.scss']
})
export class WishListComponent implements OnInit, AfterViewInit {

  public autocompleteInput: string;
  public currentLocation: TripLocation;
  public showToastr = false;

  @ViewChild('address') addresstext: any;
  constructor(private vacationService: VacationService, private userService: UserService,  private router: Router) { }

  ngOnInit() {
    this.currentLocation = new TripLocation();
    this.autocompleteInput = '';
  }

  ngAfterViewInit() {
    this.getPlaceAutocomplete();
}

private getPlaceAutocomplete() {
    const autocomplete = new google.maps.places.Autocomplete(this.addresstext.nativeElement,
        {
            types: []
        });
    google.maps.event.addListener(autocomplete, 'place_changed', () => {
        const place = autocomplete.getPlace();
        console.log(place.vicinity);
        this.getTypedAddress(place);
    });
  }


  getTypedAddress($event) {
    if ($event.geometry === undefined || $event.geometry === null) {
      return;
    }
      this.currentLocation.latitude = $event.geometry.location.lat();
      this.currentLocation.longitude = $event.geometry.location.lng();
      this.currentLocation.placeId = $event.placeId;
      this.currentLocation.address = $event.vicinity;
      this.currentLocation.locationType = LocationType.wishPoint

      console.log(this.currentLocation);
  }

  cancel() {
    this.autocompleteInput = '';
  }

  sendRequest() {
    const wishItem: WishItem = {
      authorId: this.userService.getLoggedUser().entityId,
      location: this.currentLocation
    } 
    this.vacationService.addWishItem(wishItem).subscribe(
      res => {
        this.showToastr = true;
      },
      err => {
        console.log(err);
      }
    )
  }

  close() {
    this.showToastr = false;
    this.router.navigate(["/vacation"]);

  }

  isAddInWishlistDisabled() {
    return this.autocompleteInput === ''
  }
}
