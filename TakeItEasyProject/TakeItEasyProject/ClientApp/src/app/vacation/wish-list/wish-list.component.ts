import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import {} from '@agm/core/services/google-maps-types';
import { TripLocation } from 'src/app/shared/models/Vacation';

declare const google: any;
@Component({
  selector: 'app-wish-list',
  templateUrl: './wish-list.component.html',
  styleUrls: ['./wish-list.component.scss']
})
export class WishListComponent implements OnInit, AfterViewInit {

  public autocompleteInput: string;
  public currentLocation: TripLocation;

  @ViewChild('address') addresstext: any;
  constructor() { }

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
      this.currentLocation.address = $event.formatted_address;

      console.log(this.currentLocation);
  }

  cancel() {
    this.autocompleteInput = '';
  }

  isAddInWishlistDisabled() {
    return this.autocompleteInput === ''
  }
}
