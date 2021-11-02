import { Component, OnInit } from '@angular/core';
import { Employee } from '../models/employee';
import { EmployeeService } from '../services/employee.service';
import { EmployeeCardComponent } from '../employee-card/employee-card.component';
import { Image } from '../models/image';
import { SafeUrl,DomSanitizer } from '@angular/platform-browser';
import { ImagesServiceService } from '../services/images-service.service';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';



@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})

export class EmployeesComponent implements OnInit {
  public employees: Employee[] = [];
  public currentEmployee:Employee;
  public currentImage:Image;
  public currentId:number=0;
  public base64Image: SafeUrl;
  private baseUrl: string = `${environment.apiUrl}Image`;
  public fileName:string;
  private selectedFile: File;
  
  constructor(private employeesService: EmployeeService, public domSanitizer:DomSanitizer,private http: HttpClient, private imageService: ImagesServiceService) 
  { 
  this.fileName="No Input Chosen";
  }
  ngOnInit(): void {
    this.currentImage= {id:0,imageTitle:" ",imageData:" " };
    this.currentEmployee= {id:0,firstName:" ",lastName:" ",email:" " ,image:this.currentImage};
    this.base64Image=this.domSanitizer.bypassSecurityTrustUrl('../../assets/default-photo/default.png');
    
    this.loadEmployees();
    
  }
  private loadEmployees() {
    this.employeesService.getEmployees().subscribe((employees) => {
      this.employees = employees
    })
  }
  public loadEmployee() {
    this.employeesService.getEmployeeById(this.currentId).subscribe((employee) => {
      this.currentEmployee = employee;
      if(this.currentEmployee.image!=null){
        this.imageService.getImageById(this.currentEmployee.image.id).subscribe((image) => {
          this.currentImage = image,
          this.base64Image =this.domSanitizer.bypassSecurityTrustUrl('data:image/png;base64,'+this.currentImage.imageData);
        })
      }
    })
  }
  public deleteEmployee() {
    this.employeesService.delteEmployeeById(this.currentId).subscribe(() => {
      this.currentImage= {id:0,imageTitle:" ",imageData:" " };
      this.currentEmployee= {id:0,firstName:" ",lastName:" ",email:" " ,image:this.currentImage};
      this.loadEmployees();
    })
  }
  public addEmployee() {
    this.employeesService.addEmployee(this.currentEmployee).subscribe(() => {
      this.loadEmployees();
    })
  }
  public editEmployee() {
      this.employeesService.editEmployee(this.currentId,this.currentEmployee).subscribe(() => {
        this.loadEmployees();
      })
  }

  public onItemSelected(employee:Employee) {
    console.log("EmployeeSelected:");
    this.currentId=employee.id;
    this.loadEmployee();
    
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
    this.Upload();
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
    uploadFile.append('myFile', this.selectedFile);
    this.http.post(this.baseUrl+'/file-to-byte',uploadFile)
      .subscribe(res=>{
        this.currentImage.imageData=res.toString();
        
      });
    }
      else
      {
       alert("This file is not an image!");
      }
  }
}
