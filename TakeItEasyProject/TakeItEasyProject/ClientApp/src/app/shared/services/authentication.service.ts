import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  login (): Observable<any> {
    return this.http.get('http://localhost:64067/api/Auth/facebookSignin');
  }
}
