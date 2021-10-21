import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.css']
})
export class ServerErrorComponent implements OnInit {
  msg:String="";
  constructor(private router: Router) { 
    this.msg=this.router.getCurrentNavigation().extras.state.msg;
  }

  ngOnInit(): void {
  }

}
