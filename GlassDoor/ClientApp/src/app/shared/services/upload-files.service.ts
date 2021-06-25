import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "./environment-url.service";

@Injectable({
  providedIn: 'root'
})
export class UploadFilesService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public uploadEmployeeImage = (fileToUpload: FormData) => {
    return this._http.post(this._envUrl.urlAddress + '/api/employees/upload', fileToUpload,
      { reportProgress: true, observe: 'events' });
  }

  public uploadEmployeeCV = (fileToUpload: FormData) => {
    return this._http.post(this._envUrl.urlAddress + '/api/employees/uploadcv', fileToUpload,
      { reportProgress: true, observe: 'events' });
  }

  public uploadCompanyLogo = (fileToUpload: FormData) => {
    return this._http.post(this._envUrl.urlAddress + '/api/companies/upload', fileToUpload,
      { reportProgress: true, observe: 'events' });
  }
}
