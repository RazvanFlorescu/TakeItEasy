import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl = 'http://localhost:64067/api/users';
  private user: User;
  constructor(private http: HttpClient) { }

  register (user: User): Observable<User> {
    return this.http.post<User>(this.baseUrl + '/register', user);
  }

  login (user: User): Observable<User> {
    return this.http.post<User>(this.baseUrl + '/login', user);
  }

  setLoggedUser(user:User) {
    this.user = user;
  }

  getLoggedUser (): User {
    return this.user;
  }
}
