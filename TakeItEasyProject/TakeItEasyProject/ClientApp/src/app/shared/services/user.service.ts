import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl = 'http://localhost:63902/api/users';
  constructor(private http: HttpClient) { }

  register (user: User): Observable<User> {
    return this.http.post<User>(this.baseUrl + '/register', user);
  }

  login (user: User): Observable<User> {
    return this.http.post<User>(this.baseUrl + '/login', user);
  }
}
