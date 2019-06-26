import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Image } from '../models/Image';

@Injectable({
  providedIn: 'root'
})
export class ImageService {
  
  private baseUrl = 'http://localhost:64067/api/images';
  constructor(private http: HttpClient) { }

  getImageByEntityId(entityId: string) {
    return this.http.get<Image>(this.baseUrl + '/' + entityId);
  }
}
