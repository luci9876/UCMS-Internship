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
  
  
  constructor(private httpClient: HttpClient) {
   
   }
   public getImageById(id:number): Observable<Image> {
    return this.httpClient.get<Image>(this.baseUrl+ '/'+id);
  }
}
