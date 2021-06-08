import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { SalaryRate } from "../../models/salary-rate";

@Injectable({
  providedIn: 'root'
})
export class SalaryRateService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getSalaryRates = () => {
    return this._http.get<SalaryRate[]>(this._envUrl.urlAddress + '/api/salaryRates');
  }
}
