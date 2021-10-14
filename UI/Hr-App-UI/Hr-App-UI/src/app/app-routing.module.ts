import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompaniesComponent } from './companies/companies.component';
import { EmployeesComponent } from './employees/employees.component';

const routes: Routes = [
  { path: 'companies', component: CompaniesComponent },
  { path: 'employees', component: EmployeesComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes),HttpClientModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents=[CompaniesComponent,EmployeesComponent]
