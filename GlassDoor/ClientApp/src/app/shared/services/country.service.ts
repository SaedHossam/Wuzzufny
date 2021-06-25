import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { Country } from "../../models/country";

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getCountries = () => {
    return this._http.get<Country[]>(this._envUrl.urlAddress + '/api/Countries');
  }
}
