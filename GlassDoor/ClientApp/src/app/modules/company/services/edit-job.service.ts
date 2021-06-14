import { PostJobDto } from './../models/post-job-dto';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from 'src/app/shared/services/environment-url.service';

@Injectable({
  providedIn: 'root',
})
export class EditJobService {
  constructor(
    private http: HttpClient,
    private _envUrl: EnvironmentUrlService
  ) {}
  public editJob = (editJobDto: PostJobDto) => {
    return this.http.put<PostJobDto>(
      `${this._envUrl.urlAddress}/api/jobs/${editJobDto.id}`,
      editJobDto
    );
  };
  public closeJob = (id: number) => {
    return this.http.put(this._envUrl.urlAddress + '/api/jobs/closeJob', id);
  };
  public getJob = (id: number) => {
    return this.http.get<PostJobDto>(
      this._envUrl.urlAddress + '/api/jobs/' + id
    ).toPromise();
  };
}
