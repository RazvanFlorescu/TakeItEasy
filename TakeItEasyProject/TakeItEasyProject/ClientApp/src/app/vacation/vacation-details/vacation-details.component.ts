import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/shared/models/User';
import { Vacation } from 'src/app/shared/models/Vacation';

@Component({
  selector: 'app-vacation-details',
  templateUrl: './vacation-details.component.html',
  styleUrls: ['./vacation-details.component.scss']
})
export class VacationDetailsComponent implements OnInit {

  user: User;
  vacation: Vacation;

  constructor(private route: ActivatedRoute) { 
    this.route.queryParams.subscribe(params => {
      this.user = JSON.parse(params['user']);
      this.vacation = JSON.parse( params['vacation']);
  });
  }

  ngOnInit() {
  }

}
