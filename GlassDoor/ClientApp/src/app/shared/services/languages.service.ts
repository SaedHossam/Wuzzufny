import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";
import { Language } from 'src/app/models/language';

@Injectable({
  providedIn: 'root'
})
export class LanguagesService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getLanguages = () => {
    return this._http.get<Language[]>(this._envUrl.urlAddress + '/api/languages');
  }
}
