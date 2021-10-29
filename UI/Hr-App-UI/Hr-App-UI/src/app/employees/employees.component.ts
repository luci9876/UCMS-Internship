import { Component, OnInit } from '@angular/core';
import { Employee } from '../models/employee';
import { EmployeeService } from '../services/employee.service';
import { EmployeeCardComponent } from '../employee-card/employee-card.component';


@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  public employees: Employee[] = [];
  public currentEmployee:Employee;
  public currentId:number=0;
  constructor(private employeesService: EmployeeService) { }

  ngOnInit(): void {
    this.currentEmployee= {id:0,firstName:" ",lastName:" ",email:" " };
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
      this.currentEmployee= {id:0,firstName:" ",lastName:" ",email:" "  };
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
  

}
