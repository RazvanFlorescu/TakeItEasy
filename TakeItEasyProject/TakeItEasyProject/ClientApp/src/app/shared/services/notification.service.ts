import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TripNotification } from '../models/TripNotification';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  private baseUrl = 'http://localhost:64067/api/notifications';
  constructor(private http: HttpClient) { }

  pushNotification (notification: TripNotification): Observable<TripNotification> {
    return this.http.post<TripNotification>(this.baseUrl + '/pushNotification', notification);
  }

  updateNotification (notification: TripNotification): Observable<TripNotification> {
    return this.http.put<TripNotification>(this.baseUrl + '/updateNotification', notification);
  }

  getNotificationsByUserId(userId: string) {
    return this.http.get<TripNotification[]>(this.baseUrl + '/' + userId);
  }
}
