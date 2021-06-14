import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../../models/employee';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {

  constructor(public http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getEmpById(id: number) {
    return this.http.get<Employee>(this._envUrl.urlAddress + '/api/Employees/' + id);
  }

  public editEmpProfile(empData: Employee) {
    return this.http.put(this._envUrl.urlAddress + '/api/Employees/' + empData.id, empData);
  }

}
