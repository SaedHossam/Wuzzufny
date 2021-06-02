import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { ComapnySize } from "../../interfaces/shared/comapny-size.model";

@Injectable({
  providedIn: 'root'
})
export class CompanySizeService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getComapnySizes= () => {
    return this._http.get<ComapnySize[]>(this._envUrl.urlAddress + '/api/CompanySizes');
  }
}
