import { Component, OnInit } from '@angular/core';
import { Employee } from '../models/employee';
import { EmployeeService } from '../employee.service';


@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  public employees: Employee[] = [];
  constructor(private employeesService: EmployeeService) { }

  ngOnInit(): void {
    this.loadMembers();
  }
  private loadMembers() {
    this.employeesService.getEmployees().subscribe((employees) => {
      this.employees = employees
    })
  }
  public onItemSelected() {
    console.log("EmployeeSelected:");
  }
  

}
