import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { AbstractControl,FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public registerForm!:FormGroup;
  constructor(private accountService:AccountService,private fb:FormBuilder, private router:Router) { }

  ngOnInit(): void {
    this.initializeForm();
  }
  initializeForm(){
    this.registerForm=this.fb.group({
      username: ['',Validators.required],
      firstName: ['',Validators.required],
      lastName: ['',Validators.required],
      email: ['',Validators.email],
      password:['',[Validators.required,Validators.minLength(10)]],
    });
  }
register(){
  this.accountService.register(this.registerForm.value).subscribe(() => {
    this.router.navigateByUrl("/companies");
  }, error=>{
    console.log(error);
    
  });
}
cancel(){
  this.router.navigateByUrl("/companies");
}

}
