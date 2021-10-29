import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable} from 'rxjs';
import { environment } from '../../environments/environment';
import { Image } from '../models/image';

@Injectable({
  providedIn: 'root'
})
export class ImagesServiceService {
  private baseUrl: string = `${environment.apiUrl}Image`;
  private headers: HttpHeaders;

  constructor(private httpClient: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
   }
   public getImageById(id:number): Observable<Image> {
    return this.httpClient.get<Image>(this.baseUrl+ '/'+id);
  }
}
