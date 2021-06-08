import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { Currency } from "../../models/currency";

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getCurrencies = () => {
    return this._http.get<Currency[]>(this._envUrl.urlAddress + '/api/currencies');
  }
}
