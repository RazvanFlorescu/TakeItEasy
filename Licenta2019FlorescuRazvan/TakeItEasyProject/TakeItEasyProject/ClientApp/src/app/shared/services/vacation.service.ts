import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Vacation, VacationJoining } from '../models/Vacation';
import { WishItem } from '../models/WishItem';

@Injectable({
  providedIn: 'root'
})
export class VacationService {

  private baseUrl = 'http://localhost:64067/api/vacations';
  constructor(private http: HttpClient) { }

  propose (vacation: Vacation): Observable<Vacation> {
    return this.http.post<Vacation>(this.baseUrl + '/propose', vacation);
  }

  join (vacationJoining: VacationJoining): Observable<VacationJoining> {
    return this.http.post<VacationJoining>(this.baseUrl + '/join', vacationJoining);
  }


  getVacationsByUserId(userId: string) {
    return this.http.get<Vacation[]>(this.baseUrl + '/' + userId);
  }

  getMostWanted() {
    return this.http.get<Vacation[]>(this.baseUrl + '/mostWanted');
  }

  getVacationByEntityId(entity: string) {
    return this.http.get<Vacation>(this.baseUrl + '/entityId/' + entity);
  }

  getAllVacations() {
    return this.http.get<Vacation[]>(this.baseUrl);
  }

  getAllPublicVacations() {
    return this.http.get<Vacation[]>(this.baseUrl + '/public');
  }

  getAllVacationJoiningsByVacationId(vacationId: string) {
    return this.http.get<VacationJoining[]>(this.baseUrl + '/vacationId/' + vacationId + 'joinings');
  }

  getAllVacationJoiningsByUserId(userId: string) {
    return this.http.get<VacationJoining[]>(this.baseUrl + '/userId/' + userId + 'joinings');
  }

  getVacationJoiningByVacationIdAndUserId(vacationId: string, userId: string) {
    return this.http.get<VacationJoining>(this.baseUrl + '/' + vacationId + '/' + userId + '/joinings');
  }

  updateStatusJoining(vacationJoining: VacationJoining): Observable<VacationJoining> {
    return this.http.put<VacationJoining>(this.baseUrl + '/updateStatusJoining', vacationJoining);
  }

  getVacationsByUserIdWhereThatUserIsJoinedThere(userId: string) {
    return this.http.get<Vacation[]>(this.baseUrl + '/' + userId + '/vacationJoinings');
  }

  addWishItem(wishItem: WishItem) {
    return this.http.post<WishItem>(this.baseUrl + '/addWishItem', wishItem);
  }

  removeWishItem(wishItem: WishItem) {
    return this.http.post<WishItem>(this.baseUrl + '/removeWishItem', wishItem);
  }

  getWishItemsByUserId(userId: string) {
    return this.http.get<WishItem[]>(this.baseUrl + '/' + userId + '/wishItems');
  }
}
