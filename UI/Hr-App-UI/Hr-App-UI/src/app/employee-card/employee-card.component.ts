import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Employee } from '../models/employee';

@Component({
  selector: 'app-employee-card',
  templateUrl: './employee-card.component.html',
  styleUrls: ['./employee-card.component.css']
})
export class EmployeeCardComponent implements OnInit {
  @Input() public employee!: Employee;
  @Output() public selectionChange = new EventEmitter();
  public constructor() { }

  public ngOnInit(): void {
  }
  OnSelectionChanged(event: any) {
    this.selectionChange.emit();
  }

}
