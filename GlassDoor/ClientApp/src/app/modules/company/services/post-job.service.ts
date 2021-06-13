import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from 'src/app/shared/services/environment-url.service';
import { PostJobDto } from '../models/post-job-dto';

@Injectable({
  providedIn: 'root',
})
export class PostJobService {
  constructor(
    private http: HttpClient,
    private _envUrl: EnvironmentUrlService
  ) {}
  public postJob = (postJobDto: PostJobDto) => {
    return this.http.post<PostJobDto>(this._envUrl.urlAddress + '/api/jobs', postJobDto);
  };
  public closeJob = (id: number) => {
    return this.http.put(this._envUrl.urlAddress + '/api/jobs/closeJob', id);
  };
}
