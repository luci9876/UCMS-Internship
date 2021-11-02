import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../services/company.service';
import { Company } from '../models/company';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ImagesServiceService } from '../services/images-service.service';
import { Image } from '../models/image';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

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
  
  public imageService: ImagesServiceService;
  public currentImage:Image;
  private baseUrl: string = `${environment.apiUrl}Image`;
  public fileName:string;
  private selectedFile: File;
  
  
  constructor(private employeesService: CompanyService,public domSanitizer:DomSanitizer,private http: HttpClient) {
    this.fileName="No Input Chosen";
   }

  ngOnInit(): void {
    this.currentImage= {id:0,imageTitle:" ",imageData:" " };
    this.currentCompany= {id:0,name:" ",description:" ",image:this.currentImage,founded:1900 };
    this.base64Image=this.domSanitizer.bypassSecurityTrustUrl('../../assets/default-photo/logo.png');
    this.loadCompanies();
    
  }
  private loadCompanies() {
    this.employeesService.getCompanies().subscribe((companies) => {
      this.companies = companies; 
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
  onFileChanged(event) {
    this.selectedFile = event.target.files[0];
    this.fileName=this.selectedFile.name;
  }
  Upload() {
    var index = this.fileName.lastIndexOf('.');
    var currentExtension = this.fileName.substring(index + 1).trim();
    let allExtensions: Array<string> = ["png", "jpg", "jpeg", "gif", "tiff", "bpg"];
    var exists:boolean=false;
    for(let element of allExtensions)
    {
      if(currentExtension===element)
       {
         exists=true;
        break;}
    }
    if(exists)
    {
    const uploadFile = new FormData();
    uploadFile.append('myFile', this.selectedFile, this.selectedFile.name);
    this.http.post(this.baseUrl,uploadFile,)
      .subscribe(res=>{
        console.log(res);
      });
    }
      else
      {
       alert("This file is not an image!");
      }
  }
  


}
