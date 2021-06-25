import { Component, OnInit } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';
import { AuthenticationService } from './shared/services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent implements OnInit {
  title = 'CompanyEmployees.Client';

  constructor(private _authService: AuthenticationService) { }

  ngOnInit(): void {
    if (this._authService.isUserAuthenticated())
      this._authService.sendAuthStateChangeNotification(true);
  }
}
