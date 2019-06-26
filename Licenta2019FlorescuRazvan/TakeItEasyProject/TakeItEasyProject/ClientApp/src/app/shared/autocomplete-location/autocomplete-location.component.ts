import { Component, ViewChild, EventEmitter, Output, OnInit, AfterViewInit, Input, SimpleChanges, OnChanges } from '@angular/core';
import {} from '@agm/core/services/google-maps-types';

declare const google: any;

@Component({
  selector: 'app-autocomplete-location',
  templateUrl: './autocomplete-location.component.html',
  styleUrls: ['./autocomplete-location.component.scss']
})
export class AutocompleteLocationComponent implements OnInit, OnChanges, AfterViewInit {
  @Input() addressType: string;
  @Input() latitude;
  @Input() longitude;
  @Input() placeId;
  @Input() inputIndex;
  @Input() title;
  @Output() setAddress: EventEmitter<any> = new EventEmitter();
  @ViewChild('addresstext') addresstext: any;

  autocompleteInput: string;
  queryWait: boolean;
  private geoCoder;

  constructor() {
    this.geoCoder = new google.maps.Geocoder;
  }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    for (const propName in changes) {
        const change = changes[propName];

        if ((change.currentValue || change.previousValue) && (propName === 'longitude'|| propName === 'latitude') && this.placeId ==='') {
            this.setAddressByCoordinates(this.latitude, this.longitude);
        }else if ((change.currentValue || change.previousValue) && propName === 'placeId') {
            this.setAddressByPlaceId(this.placeId);
        }
     }
  }

  ngAfterViewInit() {
      this.getPlaceAutocomplete();
  }

  private getPlaceAutocomplete() {
      const autocomplete = new google.maps.places.Autocomplete(this.addresstext.nativeElement,
          {
              types: [this.addressType]  // 'establishment' / 'address' / 'geocode'
          });
      google.maps.event.addListener(autocomplete, 'place_changed', () => {
          const place = autocomplete.getPlace();
          this.invokeEvent(place);
      });
  }

  setAddressByCoordinates(latitude, longitude) {
    this.geoCoder.geocode({ 'location': { lat: latitude, lng: longitude } }, (results, status) => {
      if (status === 'OK') {
        if (results[0]) {
          this.autocompleteInput = results[0].formatted_address;
        } else {
          console.log('No results found');
        }
      } else {
        console.log('Geocoder failed due to: ' + status);
      }
    });
  }

  setAddressByPlaceId(placeId) {
    this.geoCoder.geocode({'placeId': placeId}, (results, status) => {
      if (status === 'OK') {
        if (results[0]) {
          this.autocompleteInput = results[0].formatted_address;
        } else {
          window.alert('No results found');
        }
      } else {
        window.alert('Geocoder failed due to: ' + status);
      }

    });
  }

  isInputInUse() {
    return !!this.autocompleteInput &&
           this.autocompleteInput !== null &&
           this.autocompleteInput !== ''
  }


  invokeEvent(place: Object) {
      this.setAddress.emit(
          { 
              ...
              place,
              inputIndex: this.inputIndex
          }
        );
  }
}
