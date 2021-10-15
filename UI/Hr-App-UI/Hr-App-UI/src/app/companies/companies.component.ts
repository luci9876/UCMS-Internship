import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../company.service';
import { Company } from '../models/company';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent implements OnInit {
  public companies: Company[] = [];
  public currentCompany:Company;
  public currentId:number=0;
  constructor(private employeesService: CompanyService) { }

  ngOnInit(): void {
    this.currentCompany= {id:0,name:" ",description:" " };
    this.loadCompanies();
    
  }
  private loadCompanies() {
    this.employeesService.getCompanies().subscribe((companies) => {
      this.companies = companies
    })
  }
  public loadCompany() {
    this.employeesService.getCompanyById(this.currentId).subscribe((company) => {
      this.currentCompany = company
    })
  }
  public deleteCompany() {
    this.employeesService.delteCompanyById(this.currentId).subscribe(() => {
      this.currentCompany= {id:0,name:" ",description:" " };
      this.loadCompanies();
    })
  }
  public addCompany() {
    this.employeesService.addCompany(this.currentCompany).subscribe(() => {
      this.loadCompanies();
    })
  }
  public editCompany() {
      this.employeesService.editCompany(this.currentId,this.currentCompany).subscribe(() => {
        this.loadCompanies();
      })
  }

  public onItemSelected() {
    console.log("CompanySelected:");
    
  }
  


}
