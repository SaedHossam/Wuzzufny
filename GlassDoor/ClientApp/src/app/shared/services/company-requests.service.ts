import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { CompanyRequest } from "../../models/company-request";
import { CompanyRequestStatus } from "../../models/company-request-status";

@Injectable({
  providedIn: 'root'
})
export class CompanyRequestsService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getCompaniesRequests = () => {
    return this._http.get<CompanyRequest[]>(this._envUrl.urlAddress + '/api/Companies/companiesRequests');
  }

  public getCompanyRequest = (id: number) => {
    return this._http.get<CompanyRequest>(this._envUrl.urlAddress + '/api/Companies/companiesRequests/' + id);
  }

  public changeCompanyRequestStatus = (body: CompanyRequestStatus) => {
    return this._http.post(this._envUrl.urlAddress + '/api/Companies/requestStatus', body);
  }
}
