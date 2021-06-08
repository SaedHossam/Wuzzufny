import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JobTypes } from "../../models/job-types";
import { EnvironmentUrlService } from "./environment-url.service";
import { EducationLevel } from "../../models/education-level";

@Injectable({
  providedIn: 'root'
})
export class EducationLevelService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getEducationLevels = () => {
    return this._http.get<EducationLevel[]>(this._envUrl.urlAddress + '/api/educationLevels');
  }
}
