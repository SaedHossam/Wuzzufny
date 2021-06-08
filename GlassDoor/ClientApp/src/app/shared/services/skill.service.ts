import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { Skills } from "../../models/skills";

@Injectable({
  providedIn: 'root'
})
export class SkillService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getSkills = () => {
    return this._http.get<Skills[]>(this._envUrl.urlAddress + '/api/skills');
  }
}
