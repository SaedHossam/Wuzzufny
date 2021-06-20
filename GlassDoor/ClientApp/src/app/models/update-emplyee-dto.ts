import { Data } from "@angular/router";
import { Calendar } from "primeng/calendar";
import { Gender } from "./enums/gender.enum";
import { MilitaryStatus } from "./enums/military-status.enum";

export class UpdateEmployeeDto {
  constructor(
    public summary?: string,
    public educationLevelId?: number,
    public experienceYears?: number,
    public careerLevelId?: number,
    public mobileNumber?: string,
    public alternativeMobileNumber?: string,
    public isWillingToRelocate?: boolean,
    public countryId?: number,
    public cityId?: number,
    public minimumSalary?: number,
    public nationalityId?: number,
    public birthDate?: Date,
    public gender?: Gender,
    public militaryStatus?: MilitaryStatus,
    public userFirstName?: string,
    public userLastName?: string,
    public photo?: string,
    public cv?: string
  ) {
  }
}
