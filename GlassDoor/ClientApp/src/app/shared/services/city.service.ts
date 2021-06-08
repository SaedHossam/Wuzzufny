import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { City } from "../../models/city";

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getCities = () => {
    return this._http.get<City[]>(this._envUrl.urlAddress + '/api/cities');
  }
}
