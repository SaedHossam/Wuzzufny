import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Job } from 'src/app/models/job';
import { EnvironmentUrlService } from 'src/app/shared/services/environment-url.service';
import { PostJobDto } from '../models/post-job-dto';

@Injectable({
  providedIn: 'root'
})
export class DiplayCompanyJobsService {

  constructor(private http:HttpClient, private _envUrl:EnvironmentUrlService) { }
  public getCompanyjobs=()=>{
    return this.http.get<Job[]>(this._envUrl.urlAddress+"/api/jobs/Companyjobs")
     }
}
