import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/shared/models/User';
import { Vacation, TripLocation } from 'src/app/shared/models/Vacation';
import { ImageService } from 'src/app/shared/services/image.service';

@Component({
  selector: 'app-vacation-details',
  templateUrl: './vacation-details.component.html',
  styleUrls: ['./vacation-details.component.scss']
})
export class VacationDetailsComponent implements OnInit {

  currentUser: User;
  vacation: Vacation;

  constructor(private route: ActivatedRoute, private imageService: ImageService) { 
  }

  public renderOptions = {
    suppressMarkers: true,
  }
  
  public markerOptions = {
    origin: {
        icon: './../../../assets/images/location.png',
    },
    destination: {
        icon: './../../../assets/images/location.png',
    },
    waypoints: {
        icon: './../../../assets/images/point.png',
    }
  }

  origin;
  destination;
  wayPoints;

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.currentUser = JSON.parse(params['user']);
      this.vacation = JSON.parse( params['vacation']);
      this.setCurrentLocation(this.vacation.vacationPoints);
      this.setImages();
  });
  }

  setCurrentLocation(locations: TripLocation[]): void {
    console.log(locations);
    this.origin = {
      lat: Number(locations[0].latitude),
      lng: Number(locations[0].longitude),
    }

    this.destination = {
      lat: Number(locations[locations.length -1].latitude),
      lng: Number(locations[locations.length -1].longitude)
    }

    this.wayPoints = [];
    if(locations.length > 2) {
      for(let i = 1; i < locations.length-1; i++){
        this.wayPoints.push({
          location: {
            "lat": Number(locations[i].latitude),
            "lng": Number(locations[i].longitude)
          },
          stopover: false
        });
      }
    }
  }

private setImages() {
  this.imageService.getImageByEntityId(this.vacation.entityId).subscribe(
    res => {
      this.vacation.image = res!==null? res.content : undefined;
    },
    err => {
      console.log(err);
    }
  )

  this.imageService.getImageByEntityId(this.currentUser.entityId).subscribe(
    res => {
      this.currentUser.image = res!==null? res.content : undefined;
    },
    err => {
      console.log(err);
    }
  )
}

}
