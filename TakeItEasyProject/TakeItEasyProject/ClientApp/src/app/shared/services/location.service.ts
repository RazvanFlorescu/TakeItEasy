import { Injectable } from '@angular/core';

declare var H: any;

@Injectable()
export class LocationService {

   platform: any;

   public constructor() {
       this.platform = new H.service.Platform({
           'app_id': 'wi4qcYPPHSbF10M1H8OB',
           'app_code': 'hCXV_73fjQKbQQa5jxy-Bg'
       });
   }

   public getCurrentLocation() {
       const geocoder = this.platform.getGeocodingService();
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(position => {
                    geocoder.reverseGeocode(
                        {
                            mode: 'retrieveAddresses',
                            maxresults: 1,
                            prox: position.coords.latitude + ',' + position.coords.longitude
                        }, data => {
                            console.log(data);
                            alert('The nearest address to your location is:\n' + data.Response.View[0].Result[0].Location.Address.Label);
                        }, error => {
                            console.error(error);
                        }
                    );
                });
            } else {
                console.error('Geolocation is not supported by this browser!');
            }
    }
}
