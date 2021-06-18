import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { CompanyType } from "../../models/company-type";

@Injectable({
  providedIn: 'root'
})
export class CompanyTypeService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getCompanyTypes = () => {
    return this._http.get<CompanyType[]>(this._envUrl.urlAddress + '/api/CompanyTypes');
  }
}
