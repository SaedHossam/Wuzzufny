import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { CareerLevel } from "../../models/career-level";

@Injectable({
  providedIn: 'root'
})
export class CareerLevelService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getCareerLevels = () => {
    return this._http.get<CareerLevel[]>(this._envUrl.urlAddress + '/api/careerLevels');
  }
}
