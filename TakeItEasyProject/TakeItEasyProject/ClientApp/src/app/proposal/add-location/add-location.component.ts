import { Component, OnInit, ViewChild, ElementRef, NgZone } from '@angular/core';
import { MapsAPILoader, MouseEvent } from '@agm/core';
import {} from '@agm/core/services/google-maps-types';
import { Vacation, TripLocation } from 'src/app/shared/models/Vacation';

@Component({
  selector: 'app-add-location',
  templateUrl: './add-location.component.html',
  styleUrls: ['./add-location.component.scss']
})
export class AddLocationComponent implements OnInit {

  zoom: number;
  address: string;
  private geoCoder;
  event: any;

  defaultNumber = Number.MIN_SAFE_INTEGER;

  locations: TripLocation[] = [
    {
      latitude: this.defaultNumber,
      longitude: this.defaultNumber
    },
    {
      latitude: this.defaultNumber,
      longitude: this.defaultNumber
    }
  ];
  currentLocation: TripLocation;


  @ViewChild('search')
  public searchElementRef: ElementRef;

  constructor(
    private mapsAPILoader: MapsAPILoader,
    private ngZone: NgZone
  ) { }

  ngOnInit() {

    // load Places Autocomplete
     this.setCurrentLocation(this.locations[0]);
     this.geoCoder = new google.maps.Geocoder;
  }

  // Get Current Location Coordinates
  private setCurrentLocation(location: TripLocation) {
    if ('geolocation' in navigator) {
      this.currentLocation = location;
      navigator.geolocation.getCurrentPosition((position) => {
        this.locations.filter(item => item.latitude === this.currentLocation.latitude &&
                              item.longitude === this.currentLocation.longitude)[0].latitude = position.coords.latitude;
        this.locations.filter(item => item.latitude === this.currentLocation.latitude &&
                              item.longitude === this.currentLocation.longitude)[0].longitude = position.coords.longitude;
        this.zoom = 8;
       // this.getAddress(this.currentLocation.latitude, this.currentLocation.longitude);
      });
    }
  }

  markerDragEnd($event: MouseEvent) {
    console.log($event);
    this.currentLocation.latitude = $event.coords.lat;
    this.currentLocation.longitude = $event.coords.lng;
    this.getAddress(this.currentLocation.latitude, this.currentLocation.longitude);
  }

  getAddress(latitude, longitude) {
    this.geoCoder.geocode({ 'location': { lat: latitude, lng: longitude } }, (results, status) => {
      console.log(results);
      console.log(status);
      if (status === 'OK') {
        if (results[0]) {
          this.zoom = 12;
          this.address = results[0].formatted_address;
        } else {
          window.alert('No results found');
        }
      } else {
        window.alert('Geocoder failed due to: ' + status);
      }

    });
  }

  getTypedAddress(event) {
    if (event.geometry === undefined || event.geometry === null) {
      return;
    }
      console.log(event);
      this.currentLocation.latitude = event.geometry.location.lat();
      this.currentLocation.longitude = event.geometry.location.lng();
  }


}
