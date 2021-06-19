import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarrerInterestDto } from '../../models/carrer-interest-dto';
import { EducationAndExpDto } from '../../models/education-and-exp-dto';
import { Employee } from '../../models/employee';
import { EmployeeLinks } from '../../models/employee-links';
import { SkillAndLanguageDto } from '../../models/skill-and-language-dto';
import { UpdateEmployeeDto } from '../../models/update-emplyee-dto';
import { EmployeeDto } from '../../modules/company/models/employee-dto';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {

  constructor(public http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public getEmpById(id: number) {
    return this.http.get<Employee>(this._envUrl.urlAddress + '/api/Employees/' + id);
  }

  public getMyProfileData() {
    return this.http.get<Employee>(this._envUrl.urlAddress + '/api/Employees/me');
  }

  public editEmpProfile(empData: UpdateEmployeeDto) {
    return this.http.put(this._envUrl.urlAddress + '/api/Employees/UpdateEmployee/', empData);
  }

  public editCareerInterest_InUI(empData: CarrerInterestDto) {
    return this.http.put(this._envUrl.urlAddress + '/api/Employees/jobCategory/', empData);
  }

  public editEduExp_InUI(empData: EducationAndExpDto) {
    return this.http.put(this._envUrl.urlAddress + '/api/Employees/EducationAndExperience/', empData);
  }

  
  public editSkill_Lang_InUI(empData: SkillAndLanguageDto) {
    return this.http.put(this._envUrl.urlAddress + '/api/Employees/SkillAndLanguage/', empData);
  }

  public getEmpLink(empData: EmployeeLinks) {
    return this.http.put(this._envUrl.urlAddress + '/api/Employees/EmployeeLinks/', empData);
  }
}
