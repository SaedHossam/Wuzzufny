import { AuthenticationService } from "../shared/services/authentication.service";
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SocialAuthService } from "angularx-social-login";

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  public isUserAuthenticated: boolean;
  public isExternalAuth: boolean;
  public isMenuCollapsed: boolean = true;
  public isUserAdmin: boolean = false;
  public isUserEmployee: boolean = false;
  public isUserCompany: boolean = false;

  constructor(private _authService: AuthenticationService, private _router: Router, private _socialAuthService: SocialAuthService) {
    this._authService.authChanged
      .subscribe(res => {
        this.isUserAuthenticated = res;
      })
  }


  ngOnInit(): void {
    this._authService.authChanged
      .subscribe(res => {
        this.isUserAuthenticated = res;

        this.isUserAdmin = this._authService.isUserAdmin();
        this.isUserEmployee = this._authService.isUserEmployee();
        this.isUserCompany = this._authService.isUserCompany();
      });

    this._socialAuthService.authState.subscribe(user => {
      this.isExternalAuth = user != null;
    });

    this.isUserAdmin = this._authService.isUserAdmin();
    this.isUserEmployee = this._authService.isUserEmployee();
    this.isUserCompany = this._authService.isUserCompany();
  }

  public logout = () => {
    this._authService.logout();

    if (this.isExternalAuth)
      this._authService.signOutExternal();

    this._router.navigate(["/"]);
  }
}
