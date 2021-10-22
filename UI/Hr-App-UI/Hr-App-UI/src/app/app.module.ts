import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule, routingComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CompaniesComponent } from './companies/companies.component';
import { CompanyCardComponent } from './company-card/company-card.component';
import { MatCardModule } from '@angular/material/card';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeeCardComponent } from './employee-card/employee-card.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register/register.component';
import { NavbarComponent } from './navbar/navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { TestErrorsComponent } from './test-errors/test-errors.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { CompanyService } from './company.service';
import { EmployeeService } from './employee.service';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { AccountService } from './account.service';


@NgModule({
  declarations: [
    AppComponent,
    CompaniesComponent,
    CompanyCardComponent,
    routingComponents,
    EmployeesComponent,
    EmployeeCardComponent,
    RegisterComponent,
    NavbarComponent,
    TestErrorsComponent,
    ServerErrorComponent,
    NotFoundComponent


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    RouterModule,
    MatToolbarModule,
    ReactiveFormsModule
  ],

  providers: [
    CompanyService,
    EmployeeService,
    AccountService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
