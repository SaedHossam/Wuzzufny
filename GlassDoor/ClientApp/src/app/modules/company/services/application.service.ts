import { EditApplicationStatusDto } from './../models/edit-application-status-dto';
import { CompanyApplicationStatusDto } from './../models/company-application-status-dto';
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
  public editStatus = (statusDto: EditApplicationStatusDto) => {
    return this.http.put<EditApplicationStatusDto>(
      `${this._envUrl.urlAddress}/api/Applications/status`,
      statusDto
    );
  };
  public getAllCompanyApplicationStatus = () => {
    return this.http.get<CompanyApplicationStatusDto[]>(
      `${this._envUrl.urlAddress}/api/CompanyApplicationStatus`
    );
  };
}
