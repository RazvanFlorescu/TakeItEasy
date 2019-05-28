import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-location',
  templateUrl: './add-location.component.html',
  styleUrls: ['./add-location.component.scss']
})
export class AddLocationComponent implements OnInit {

  constructor() { }

  query = '';
  ajaxRequest = new XMLHttpRequest();
  suggestionsContainer;
  mapContainer;
  bubble;

  ngOnInit() {
    this.attachEventListenersToXMLHttpRequestObject();
    this.setUpContainers();
  }

   autoCompleteListener(textBox, event) {
    if (this.query !== textBox.value) {
      if (textBox.value.length >= 1) {

        /**
        * A full list of available request parameters can be found in the Geocoder Autocompletion
        * API documentation.
        *
        */
        const params = '?' +
          'query=' +  encodeURIComponent(textBox.value) +   // The search text which is the basis of the query
          '&beginHighlight=' + encodeURIComponent('<mark>') + //  Mark the beginning of the match in a token.
          '&endHighlight=' + encodeURIComponent('</mark>') + //  Mark the end of the match in a token.
          '&maxresults=5' +  // The upper limit the for number of suggestions to be included
                            // in the response.  Default is set to 5.
          '&app_id=' + APPLICATION_ID +
          '&app_code=' + APPLICATION_CODE;
        this.ajaxRequest.open('GET', AUTOCOMPLETION_URL + params );
        this.ajaxRequest.send();
      }
    }
    query = textBox.value;
  }

  attachEventListenersToXMLHttpRequestObject() {
    this.ajaxRequest.addEventListener('load', this.onAutoCompleteSuccess);
    this.ajaxRequest.addEventListener('error', this.onAutoCompleteFailed);
    this.ajaxRequest.responseType = 'json';
  }

  private onAutoCompleteSuccess(response) {
     this.clearOldSuggestions();
     this.addSuggestionsToPanel(response);  // In this context, 'this' means the XMLHttpRequest itself.
     this.addSuggestionsToMap(response);
   }

  private onAutoCompleteFailed() {
     alert('Ooops!');
   }


 openBubble(position, text) {
  if (!bubble) {
      bubble =  new H.ui.InfoBubble(
        position,
        // The FO property holds the province name.
        {content: '<small>' + text + '</small>'});
      ui.addBubble(bubble);
    } else {
      bubble.setPosition(position);
      bubble.setContent('<small>' + text + '</small>');
      bubble.open();
    }
}


  private setUpContainers() {
    this.mapContainer = document.getElementById('map');
    this.suggestionsContainer = document.getElementById('panel');
  }

  private clearOldSuggestions() {
    group.removeAll ();
     if (bubble) {
       bubble.close();
     }
  }

  private addSuggestionsToPanel(response) {
    const suggestions = document.getElementById('suggestions');
    suggestions.innerHTML = JSON.stringify(response, null, ' ');
 }

  private addSuggestionsToMap(response) {
  /**
   * This function will be called once the Geocoder REST API provides a response
   * @param  {Object} result          A JSONP object representing the  location(s) found.
   */
  const onGeocodeSuccess = function (result) {
    let marker,
      locations = result.Response.View[0].Result,
      i;

      // Add a marker for each location found
      for (i = 0; i < locations.length; i++) {
        marker = new H.map.Marker({
          lat : locations[i].Location.DisplayPosition.Latitude,
          lng : locations[i].Location.DisplayPosition.Longitude
        });
        marker.setData(locations[i].Location.Address.Label);
        group.addObject(marker);
      }

      map.setViewBounds(group.getBounds());
      if (group.getObjects().length < 2) {
        map.setZoom(15);
      }
    },
    /**
     * This function will be called if a communication error occurs during the JSON-P request
     * @param  {Object} error  The error message received.
     */
    onGeocodeError = function (error) {
      alert('Ooops!');
    },
     /**
     * This function uses the geocoder service to calculate and display information
     * about a location based on its unique `locationId`.
     *
     * A full list of available request parameters can be found in the Geocoder API documentation.
     * see: http://developer.here.com/rest-apis/documentation/geocoder/topics/resource-search.html
     *
     * @param {string} locationId    The id assigned to a given location
     */
    geocodeByLocationId = function (locationId) {
      geocodingParameters = {
        locationId : locationId
      };

      geocoder.geocode(
        geocodingParameters,
        onGeocodeSuccess,
        onGeocodeError
      );
    };

  /*
   * Loop through all the geocoding suggestions and make a request to the geocoder service
   * to find out more information about them.
   */

  response.suggestions.forEach(function (item, index, array) {
    geocodeByLocationId(item.locationId);
  });
}



}
