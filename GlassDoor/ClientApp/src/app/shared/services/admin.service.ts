import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { AdminInsights } from "../../models/admin-insights";

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getInsights = () => {
    return this._http.get<AdminInsights>(this._envUrl.urlAddress + '/api/admin/insights');
  }
}
