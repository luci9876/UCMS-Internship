import { Injectable } from "@angular/core";
import { HttpEvent, HttpRequest, HttpHandler, HttpInterceptor, HttpErrorResponse } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { User } from "../models/user";
import { catchError, take } from 'rxjs/operators';
import { AccountService } from '../account.service';
import { Router } from "@angular/router";
@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private accountservice: AccountService,private router:Router) { }
    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        let currentUser!: User;
        this.accountservice.currentUser$.pipe(take(1)).subscribe(user => currentUser = user);
        if (currentUser) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${currentUser.token}`
                }
            })
        }
        return next.handle(request).pipe(
            catchError((errorResponse: HttpErrorResponse) => {
                if (errorResponse) {
                    switch(errorResponse.status){
                            case 401:
                            this.router.navigateByUrl("/");
                            console.warn("The authetication session expired. Please signin again!");
                            break;
                            case 404:
                            console.warn("404 error was handled");
                            this.router.navigateByUrl("/not-found");
                            break;
                            case 422:
                            console.warn("422 error was handled");
                            break;
                            case 500:
                            console.warn("500 error was handled");
                            this.router.navigateByUrl("/server-error");
                            break;
                            default:
                            console.warn("An unexpected error was handled. Please contact the adminstrator");
                            break;
                    }
                }
                return throwError(errorResponse);
            }
            ));
    }
}




