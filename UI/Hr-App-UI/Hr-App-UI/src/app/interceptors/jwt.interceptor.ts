import { Injectable } from "@angular/core";
import { HttpEvent, HttpRequest, HttpHandler, HttpInterceptor } from "@angular/common/http";
import { Observable } from "rxjs";
import { User } from "../models/user";
import { take } from 'rxjs/operators';
import { AccountService } from '../account.service';
@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private accountservice: AccountService) { }
intercept(request:HttpRequest<unknown>,next:HttpHandler):Observable<HttpEvent<unknown>>{
    let currentUser!:User;
    this.accountservice.currentUser$.pipe(take(1)).subscribe(user=>currentUser=user);
    if (currentUser){
       request=request.clone({
           setHeaders:{
               Authorization:`Bearer ${currentUser.token}`
           }
       })
    }
    return next.handle(request);
}
}




