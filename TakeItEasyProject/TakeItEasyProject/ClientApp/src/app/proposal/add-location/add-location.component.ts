import { Component, OnInit, ViewChild, ElementRef, Input, EventEmitter, Output } from '@angular/core';
import { InfoWindow } from '@agm/core/services/google-maps-types';
import { TripLocation, Vacation, LocationType } from 'src/app/shared/models/Vacation';

declare const google: any;

@Component({
  selector: 'app-add-location',
  templateUrl: './add-location.component.html',
  styleUrls: ['./add-location.component.scss']
})
export class AddLocationComponent implements OnInit {

  defaultNumber = Number.MIN_SAFE_INTEGER;
  isClosedSearchSide = false;
  @Input() vacation: Vacation;
  @Output() vacationChange = new EventEmitter();
  @Output() saveState = new EventEmitter();
  
  locations: TripLocation[];
  defaultLocactions = [
    {
      latitude: this.defaultNumber,
      longitude: this.defaultNumber,
      address: ''
    },
    {
      latitude: this.defaultNumber,
      longitude: this.defaultNumber,
      address: ''
    }
  ];
  isAvailableRoad = true;
  address;
  destination;
  origin;
  wayPoints = [];

  public renderOptions = {
    suppressMarkers: true,
  }
  
  public markerOptions = {
    origin: {
        draggable: true,
        icon: './../../../assets/images/location.png',
    },
    destination: {
        draggable: true,
        icon: './../../../assets/images/location.png',
    },
    waypoints: {
        icon: './../../../assets/images/point.png',
    }
  }
  private geoCoder;

  @ViewChild('search')
  public searchElementRef: ElementRef;

  constructor() { this.geoCoder = new google.maps.Geocoder; }

  ngOnInit() {
    this.locations = this.vacation.vacationPoints? this.vacation.vacationPoints: this.defaultLocactions;
    this.setCurrentLocation();
  }

 setCurrentLocation(): void {
        this.origin = {
          lat: this.locations[0].latitude,
          lng: this.locations[0].longitude
        }

        this.destination = {
          lat: this.locations[this.locations.length -1].latitude,
          lng: this.locations[this.locations.length -1].longitude
        }

        this.wayPoints = [];
        if(this.locations.length > 2) {
          for(let i = 1; i < this.locations.length-1; i++){
            this.wayPoints.push({
              location: {
                "lat": this.locations[i].latitude,
                "lng":this.locations[i].longitude
              },
              stopover: false
            });
          }
        }
  }

  addDestination() {
    this.wayPoints.push({
      location: {
        "lat": this.locations[this.locations.length-1].latitude,
        "lng":this.locations[this.locations.length-1].longitude
      },
      stopover: false
    })

    this.locations.push({
      latitude: this.defaultNumber,
      longitude: this.defaultNumber,
      address:''
    });
  }

  getTypedAddress($event) {
    if ($event.geometry === undefined || $event.geometry === null) {
      return;
    }
    console.log($event);
      this.locations[$event.inputIndex].latitude = $event.geometry.location.lat();
      this.locations[$event.inputIndex].longitude = $event.geometry.location.lng();
      this.locations[$event.inputIndex].placeId = $event.placeId;
      this.locations[$event.inputIndex].address = $event.formatted_address;
      this.setCurrentLocation();
  }

  areMoreThanTwoLocations() {
    return this.locations.length > 2
  }

  setAddressByCoordinates(latitude, longitude, index) {
    this.geoCoder.geocode({ 'location': { lat: latitude, lng: longitude } }, (results, status) => {
      if (status === 'OK') {
        if (results[0]) {
          this.locations[index].address = results[0].formatted_address;
        } else {
          console.log('No results found');
        }
      } else {
        console.log('Geocoder failed due to: ' + status);
      }
    });
  }

  getTitle(index) {
    if (index === 0) {
      return 'Origin'
    } else if (index === this.locations.length-1) {
      return 'Destinaton'
    } else {
      return 'Way Point'
    }
  }

 removeLocation(location) {
  const index = this.locations.indexOf(location, 0);
  if (index > -1) {
     this.locations.splice(index, 1);
  }
  this.setCurrentLocation();
 }

 closeSearchSide() {
  this.isClosedSearchSide = true;
 }

 showSearchSide() {
   this.isClosedSearchSide = false;
 }

 areValidLocations() {
  for(let i = 0; i < this.locations.length; i++){
    if(this.locations[i].latitude === this.defaultNumber || this.locations[i].longitude === this.defaultNumber) {
      return false;
    }
  }

  return true;
 }

 public getStatus(status: any){
   console.log(status)
  if(status === "ZERO_RESULTS") {
    this.isAvailableRoad = false;
  } else {
    this.isAvailableRoad = true;
  }
}

save() {
  this.locations[0].locationType = LocationType.origin;
  this.locations[this.locations.length-1].locationType = LocationType.destination;
  if(this.locations.length > 2) {
    for(let i = 1; i < this.locations.length-1; i++){
      this.locations[i].locationType = LocationType.wayPoint;
    }
  }

  this.vacation.vacationPoints = this.locations;
  this.vacationChange.emit(this.vacation);
  this.saveState.emit('locationstep')
}

 onChange($event) {
    console.log($event);
    this.destination = $event.request.destination.location;
    this.origin = $event.request.origin.location;

    this.locations[0].latitude = $event.request.origin.location.lat();
    this.locations[0].longitude = $event.request.origin.location.lng();
    this.locations[0].placeId = '';
    this.setAddressByCoordinates(
            $event.request.origin.location.lat(),
            $event.request.origin.location.lng(),
            0);

    this.locations[this.locations.length-1].latitude =  $event.request.destination.location.lat();
    this.locations[this.locations.length-1].longitude =  $event.request.destination.location.lng();
    this.locations[this.locations.length-1].placeId = '';
    this.setAddressByCoordinates(
      $event.request.destination.location.lat(),
      $event.request.destination.location.lng(),
      this.locations.length-1);

  }
}