import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { CompanyForRegistrationDto } from "../../interfaces/company-register/company-for-registration-dto.model";
import { RegistrationResponseDto } from "../../interfaces/response/registration-response-dto.model";

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public registerCompany = (body: CompanyForRegistrationDto) => {
    return this._http.post(this._envUrl + '/api/company/register', body);
  }
}
