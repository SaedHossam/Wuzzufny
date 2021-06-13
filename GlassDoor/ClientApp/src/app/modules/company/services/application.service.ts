import { StatusDto } from './../models/status-dto';
import { ApplicationDto } from './../models/application-dto';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from 'src/app/shared/services/environment-url.service';

@Injectable({
  providedIn: 'root',
})
export class ApplicationService {
  constructor(
    private http: HttpClient,
    private _envUrl: EnvironmentUrlService
  ) {}
  public getAllJobApplications = (jobId: number) => {
    return this.http.get<ApplicationDto[]>(
      `${this._envUrl.urlAddress}/api/Applications/jobId/${jobId}`
    );
  };
  public getJobApplication = (applicationId: number) => {
    return this.http.get<ApplicationDto>(
      `${this._envUrl.urlAddress}/api/Applications/${applicationId}`
    );
  };
  public editStatus = (statusDto: StatusDto) => {
    return this.http.put<StatusDto>(
      `${this._envUrl.urlAddress}/api/Applications/status`,
      statusDto
    );
  };
}
