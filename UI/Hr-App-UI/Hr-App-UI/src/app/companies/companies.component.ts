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
  constructor(private companiesService: CompanyService) { }

  ngOnInit(): void {
    this.loadMembers();
  }
  private loadMembers() {
    this.companiesService.getCompanies().subscribe((companies) => {
      this.companies = companies,
      console.log(this.companies.length);
      
      
    })
  }
  public onItemSelected() {
    console.log("ItemSelected:");
  }

}
