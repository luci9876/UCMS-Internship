import { Employee } from './models/employee';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private headers: HttpHeaders;
  private baseUrl: string = `${environment.apiUrl}Employees`;
  public constructor(private httpClient: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
   }
  public getEmployees(): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(this.baseUrl);
  }
  public getEmployeeById(id:number): Observable<Employee> {
    return this.httpClient.get<Employee>(this.baseUrl+ '/'+id);
  }
  public addEmployee(employee:Employee): Observable<any> {
    return this.httpClient.post<number>(this.baseUrl,employee,{'headers':this.headers});
  }
  public editEmployee(id:number,employee:Employee): Observable<any> {
    return this.httpClient.put<any>(this.baseUrl+ '/'+id,employee,{'headers':this.headers});
  }
  public delteEmployeeById(id:number): Observable<any> {
    return this.httpClient.delete<any>(this.baseUrl+ '/'+id);
  }
}
