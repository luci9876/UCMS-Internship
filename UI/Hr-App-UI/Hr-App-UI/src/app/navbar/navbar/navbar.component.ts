import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Locale } from '../../models/locale';
import { TranslateService } from '@ngx-translate/core';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  locales: Locale[] = [
    { localeCode: 'en-US', label: 'English' },
    { localeCode: 'ro', label: 'Romania' },
  ];

  public loginForm!: FormGroup;

  constructor(public accountService: AccountService, private fb: FormBuilder, private router: Router,public translate: TranslateService)
   {
      translate.addLangs(['en', 'ro']);
      translate.setDefaultLang('en');
    }
  ngOnInit(): void {
    this.initializeForm();
  }
  initializeForm() {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(10)]],
    });
  }
  public login() {
    this.accountService.login(this.loginForm.value).subscribe(() => {
      this.router.navigateByUrl("/welcome");
    });

  }
  public logout() {
    this.accountService.logout();
    this.router.navigateByUrl("/");
  }
  switchLang(lang: string) {
    this.translate.use(lang);

}
}
