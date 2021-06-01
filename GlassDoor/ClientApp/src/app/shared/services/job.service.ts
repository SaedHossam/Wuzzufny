import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Job } from '../../models/job';
import { EnvironmentUrlService } from './environment-url.service';
import { JobDetails } from '../../models/job-details';


@Injectable({
  providedIn: 'root'
})
export class JobService {
 // readonly ApiUrl = "https://localhost:44390/api";


  constructor(public http: HttpClient, private _envUrl: EnvironmentUrlService) { }
  getJobs(): Observable<Job[]> {
    return this.http.get<Job[]>(this._envUrl.urlAddress + '/api/jobs');
  }

  getJobById(id: number) {
    return this.http.get<Job>(this._envUrl.urlAddress + '/api/jobs/GetJobDetails/' + id);
  }
  //getjobdbyid(id: number) {
  //  return this.http.get<JobDetails>(this._envUrl.urlAddress + '/api/jobdetails/' + id);
  //}

}

