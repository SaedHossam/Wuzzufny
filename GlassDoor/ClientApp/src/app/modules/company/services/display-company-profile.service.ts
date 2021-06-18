import { CompanyProfile } from './../models/company-profile';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Company } from 'src/app/models/company';
import { EnvironmentUrlService } from 'src/app/shared/services/environment-url.service';
import { CompanyProfileDto } from '../models/company-profile-dto';

@Injectable({
  providedIn: 'root'
})
export class DisplayCompanyProfileService {

  constructor(private http:HttpClient, private _envUrl:EnvironmentUrlService) { }
  public getCompanyProfile=()=>{
 return this.http.get<CompanyProfileDto>(this._envUrl.urlAddress+"/api/companies/CompanyProfile")
  }
  public getCompanyProfileEdit=()=>{
    return this.http.get<CompanyProfile>(this._envUrl.urlAddress+"/api/companies/CompanyProfile")
     }
}
