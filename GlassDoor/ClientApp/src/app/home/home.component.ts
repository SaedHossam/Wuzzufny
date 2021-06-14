
import { Component, OnInit } from "@angular/core";
import { AuthenticationService } from "../shared/services/authentication.service";
import { Router } from "@angular/router";


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public homeText: string;


  constructor(private _authService: AuthenticationService, private _router: Router) { }

  ngOnInit(): void {
    this.homeText = "WELCOME TO COMPANYEMPLOYEES CLIENT APP";

    if (this._authService.isUserEmployee()) {
      this._router.navigate(["/employee"]);
    }
    else if (this._authService.isUserAdmin()) {
      this._router.navigate(["/admin"]);
    }
    else if (this._authService.isUserCompany()) {
      this._router.navigate(["/company"]);
    }
  }
}
