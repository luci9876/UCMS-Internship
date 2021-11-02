import { Company } from '../models/company';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private headers: HttpHeaders;
  private baseUrl: string = `${environment.apiUrl}Companies`;
  public constructor(private httpClient: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
   }
  public getCompanies(): Observable<Company[]> {
    return this.httpClient.get<Company[]>(this.baseUrl);
  }
  public getCompanyById(id:number): Observable<Company> {
    return this.httpClient.get<Company>(this.baseUrl+ '/'+id);
  }
  public addCompany(company:Company): Observable<any> {
    return this.httpClient.post<number>(this.baseUrl,company,{'headers':this.headers});
  }
  public editCompany(id:number,company:Company): Observable<any> {
    return this.httpClient.put<any>(this.baseUrl+ '/'+id,company,{'headers':this.headers});
  }
  public delteCompanyById(id:number): Observable<any> {
    return this.httpClient.delete<any>(this.baseUrl+ '/'+id);
  }
}
