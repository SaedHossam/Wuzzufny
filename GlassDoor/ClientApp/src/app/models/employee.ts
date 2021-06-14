import { Application } from "./application";
import { ApplicationUser } from "./application-user";
import { CareerLevel } from "./career-level";
import { City } from "./city";
import { Country } from "./country";
import { EducationLevel } from "./education-level";
import { EmployeeLinks } from "./employee-links";
import { Gender } from "./enums/gender.enum";
import { MilitaryStatus } from "./enums/military-status.enum";
import { JobCategory } from "./job-category";
import { JobTypes } from "./job-types";
import { Skills } from "./skills";
import { UserLanguage } from "./user-language";

export class Employee {


  constructor(public id?: number, public userId?: string, public birthDate?: Date, public gender?: Gender,
    public militaryStatus?: MilitaryStatus, public cityName?: string,public countryId?: number,
    public countryName?: string, public isWillingToRelocate?: boolean,
    public mobileNumber?: string, public alternativeMobileNumber?: string, public careerLevelId?: number,
    public careerLevelName?: string, public jobTypesName?: JobTypes[], public preferredJobCategoriesName?: JobCategory,
    public minimumSalary?: number, public experienceYears?: number, public skillsNames?: Skills[],
    public userLanguagesNames?: UserLanguage[], public employeeLinksNames?: EmployeeLinks[],public cV?: string,
    public photo?: string, public summary?: string, public educationLevelId?: number,
    public educationLevelName?: string, public nationalityId?: number, public nationalityName?: string,
    public userFirstName?: string, public userLastName?: string, public email?: string)
  {
  }

}
