import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Vacation } from '../models/Vacation';

@Injectable({
  providedIn: 'root'
})
export class VacationService {

  private baseUrl = 'http://localhost:64067/api/vacations';
  constructor(private http: HttpClient) { }

  propose (vacation: Vacation): Observable<Vacation> {
    return this.http.post<Vacation>(this.baseUrl + '/propose', vacation);
  }

  getVacationsByUserId(userId: string) {
    return this.http.get<Vacation[]>(this.baseUrl + '/' + userId);
  }
}
