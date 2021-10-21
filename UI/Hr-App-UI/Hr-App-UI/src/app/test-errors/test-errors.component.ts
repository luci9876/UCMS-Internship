import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {
  private baseUrl: string = `${environment.apiUrl}`;
  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }

  divisionByZero(){
 console.log(this.baseUrl+'Companies/division-by-zero');
 this.http.get(this.baseUrl+'/division-by-zero').subscribe(
   (succesResult)=>console.log(succesResult),
   (errorResult)=>console.warn(errorResult)
   );
  }
  unAuth(){
    this.http.get(this.baseUrl+'Companies/unauth').subscribe(
      (succesResult)=>console.log(succesResult),
      (errorResult)=>console.warn(errorResult)
      );
     }
}
