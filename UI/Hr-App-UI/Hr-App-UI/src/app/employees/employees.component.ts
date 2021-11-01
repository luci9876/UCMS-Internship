import { Component, OnInit } from '@angular/core';
import { Employee } from '../models/employee';
import { EmployeeService } from '../services/employee.service';
import { EmployeeCardComponent } from '../employee-card/employee-card.component';
import { Image } from '../models/image';
import { SafeUrl,DomSanitizer } from '@angular/platform-browser';
import { ImagesServiceService } from '../services/images-service.service';


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
  public domSanitizer:DomSanitizer;
  public imageService: ImagesServiceService;
  
  constructor(private employeesService: EmployeeService) { }

  ngOnInit(): void {
    this.currentImage= {id:0,imageTitle:" ",imageData:" " };
    this.currentEmployee= {id:0,firstName:" ",lastName:" ",email:" " ,image:this.currentImage};
    this.loadEmployees();
    
  }
  private loadEmployees() {
    this.employeesService.getEmployees().subscribe((employees) => {
      this.employees = employees
    })
  }
  public loadEmployee() {
    this.employeesService.getEmployeeById(this.currentId).subscribe((employee) => {
      this.currentEmployee = employee
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

  public onItemSelected() {
    console.log("EmployeeSelected:");
    
  }
  public loadImage() {
    this.imageService.getImageById(this.currentId).subscribe((image) => {
      this.currentImage = image,
      this.base64Image =this.domSanitizer.bypassSecurityTrustUrl('data:image/png;base64,'+this.currentImage.imageData);
    })
  }
  

}
