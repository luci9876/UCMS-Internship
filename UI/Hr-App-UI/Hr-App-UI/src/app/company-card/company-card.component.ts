import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Company } from '../models/company';
@Component({
  selector: 'app-company-card',
  templateUrl: './company-card.component.html',
  styleUrls: ['./company-card.component.css']
})
export class CompanyCardComponent implements OnInit {
  @Input() public company!: Company;
  @Output() public selectionChange = new EventEmitter();
  public constructor() { }

  public ngOnInit(): void {
  }
  OnSelectionChanged(event: any) {
    this.selectionChange.emit();
  }

}
