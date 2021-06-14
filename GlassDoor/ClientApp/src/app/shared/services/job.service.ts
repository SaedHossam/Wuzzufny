import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Job } from '../../models/job';
import { EnvironmentUrlService } from './environment-url.service';
import { JobDetailsDto } from '../../models/job-details-dto';
import { Application } from '../../models/application';


@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(public http: HttpClient, private _envUrl: EnvironmentUrlService) { }
  getJobs(): Observable<Job[]> {
    return this.http.get<Job[]>(this._envUrl.urlAddress + '/api/jobs');
  }

  //getJobById(id: number) {
  //  return this.http.get<Job>(this._envUrl.urlAddress + '/api/jobs/GetJobDetails/' + id);
  //}
  getjobdbyid(id: number) {
    return this.http.get<JobDetailsDto>(this._envUrl.urlAddress + '/api/jobDetails/GetJobDetails/' + id);
  }


  searchForAJob(term: string, loc: string): Observable<Job[]>{
    return this.http.get<Job[]>(this._envUrl.urlAddress + '/api/jobs/Search/' + term + '/' + loc);
  }

  applyJob(app: Application) {
    return this.http.post<Application>(this._envUrl.urlAddress + '/api/Application/', app);
  }
}

