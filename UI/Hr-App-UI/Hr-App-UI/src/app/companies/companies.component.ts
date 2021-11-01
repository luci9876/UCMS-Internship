import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../services/company.service';
import { Company } from '../models/company';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ImagesServiceService } from '../services/images-service.service';
import { Image } from '../models/image';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent implements OnInit {
  public companies: Company[] = [];
  public currentCompany:Company;
  public currentId:number=0;
  public base64Image: SafeUrl;
  public domSanitizer:DomSanitizer;
  public imageService: ImagesServiceService;
  public currentImage:Image;
  
  constructor(private employeesService: CompanyService) { }

  ngOnInit(): void {
    this.loadCompanies();
    console.log(this.companies);
    console.log("here");
    this.currentImage= {id:0,imageTitle:" ",imageData:" " };
    this.currentCompany= {id:0,name:" ",description:" ",image:this.currentImage,founded:1900 };
    
    
  }
  private loadCompanies() {
    this.employeesService.getCompanies().subscribe((companies) => {
      this.companies = companies;
      console.log(this.companies);
      
    })
  }
  public loadCompany() {
    this.employeesService.getCompanyById(this.currentId).subscribe((company) => {
      this.currentCompany = company
    })
  }
  public deleteCompany() {
    this.employeesService.delteCompanyById(this.currentId).subscribe(() => {
      this.currentImage= {id:0,imageTitle:" ",imageData:" " };
      this.currentCompany= {id:0,name:" ",description:" ",image:this.currentImage,founded:1900 };
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
  public loadImage() {
    this.imageService.getImageById(this.currentId).subscribe((image) => {
      this.currentImage = image,
      this.base64Image =this.domSanitizer.bypassSecurityTrustUrl('data:image/png;base64,'+this.currentImage.imageData);
    })
  }
  


}
