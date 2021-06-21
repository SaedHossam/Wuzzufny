import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Application } from '../../models/application';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getApplications = () => {
    return this._http.get<Application[]>(this._envUrl.urlAddress + '/api/Application');
  }

  public withdrawApplication = (applicationId: number) => {
    return this._http.put<Application>(
      `${this._envUrl.urlAddress}/api/Application/withdraw`, applicationId);
  };

  // TODO: update api
  public archiveApplication = (applicationId: number) => {
    return this._http.put<Application>(
      `${this._envUrl.urlAddress}/api/Application`, { id: applicationId, archived: true });
  };
}
