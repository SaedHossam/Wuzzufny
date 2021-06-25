import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { CompanySize } from "../../models/company-size";

@Injectable({
  providedIn: 'root'
})
export class CompanySizeService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getCompanySizes= () => {
    return this._http.get<CompanySize[]>(this._envUrl.urlAddress + '/api/CompanySizes');
  }
}
