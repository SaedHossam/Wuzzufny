import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { Industry } from "../../interfaces/shared/industry.model";

@Injectable({
  providedIn: 'root'
})
export class CompanyIndustryService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getIndustries = () => {
    return this._http.get<Industry[]>(this._envUrl.urlAddress + '/api/CompanyIndustries');
  }
}
