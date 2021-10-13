import { Company } from './models/company';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private baseUrl: string = `${environment.apiUrl}Companies`;
  public constructor(private httpClient: HttpClient) { }
  public getCompanies(): Observable<Company[]> {
    return this.httpClient.get<Company[]>(this.baseUrl);
  }
}
