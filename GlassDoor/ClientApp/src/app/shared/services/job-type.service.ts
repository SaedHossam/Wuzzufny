import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { JobTypes } from "../../models/job-types";

@Injectable({
  providedIn: 'root'
})
export class JobTypeService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getCompanyTypes = () => {
    return this._http.get<JobTypes[]>(this._envUrl.urlAddress + '/api/JobTypes');
  }
}
