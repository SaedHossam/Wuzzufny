import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from 'src/app/shared/services/environment-url.service';
import { PostJobDto } from '../models/post-job-dto';

@Injectable({
  providedIn: 'root'
})
export class EditJobService {

  constructor(private http:HttpClient ,private _envUrl :EnvironmentUrlService) { }
  public geteditjob =(editJobDto:PostJobDto)=>{
    return  this.http.put<PostJobDto>(`${this._envUrl.urlAddress}/api/jobs/${editJobDto.id}`,editJobDto);
}
}
