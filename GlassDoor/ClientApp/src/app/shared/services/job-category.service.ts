import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { JobTypes } from "../../models/job-types";
import { EnvironmentUrlService } from "./environment-url.service";
import { JobCategory } from "../../models/job-category";

@Injectable({
  providedIn: 'root'
})
export class JobCategoryService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getjobCategories = () => {
    return this._http.get<JobCategory[]>(this._envUrl.urlAddress + '/api/jobCategories');
  }
}
