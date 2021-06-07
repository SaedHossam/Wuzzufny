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


  constructor(id?: number, userId?: string, birthDate?: Date, gender?: Gender,
    militaryStatus?: MilitaryStatus, city?: City, countryId?: number,
    country?: Country, isWillingToRelocate?: boolean,
    mobileNumber?: string, alternativeMobileNumber?: string, careerLevelId?: number
    , careerLevel?: CareerLevel, jobTypes?: JobTypes, preferredJobCategories?: JobCategory,
    minimumSalary?: number, experienceYears?: number, skills?: Skills,
    userLanguages?: UserLanguage, employeeLinks?: EmployeeLinks, cV?: string,
    photo?: string, summary?: string, educationLevelId?: number,
    educationLevel?: EducationLevel, nationalityId?: number, nationality?: Country,
    user?: ApplicationUser, applications?: Application)
  {

    this.id = id;
    this.userId = userId;
    this.birthDate = birthDate;
    this.gender = gender;

    this.militaryStatus = militaryStatus;
    this.city = city;
    this.countryId = countryId;
    this.country = country;

    this.isWillingToRelocate = isWillingToRelocate;
    this.mobileNumber = mobileNumber;
    this.alternativeMobileNumber = alternativeMobileNumber;
    this.careerLevelId = careerLevelId;

    this.careerLevel = careerLevel;
    this.jobTypes = jobTypes;
    this.preferredJobCategories = preferredJobCategories;
    this.minimumSalary = minimumSalary;

    this.experienceYears = experienceYears;
    this.skills = skills;
    this.userLanguages = userLanguages;
    this.employeeLinks = employeeLinks;


    this.cV = cV;
    this.photo = photo;
    this.summary = summary;
    this.educationLevelId = educationLevelId;

    this.educationLevel = educationLevel;
    this.nationalityId = nationalityId;
    this.nationality = nationality;
    this.user = user;

    this.applications = applications;



  }
  public id: number;
  public userId: string;
  public birthDate: Date;
  public gender : Gender;
  
  public militaryStatus : MilitaryStatus;
  public city: City;
  public countryId: number;
  public country : Country;

  public isWillingToRelocate: Boolean;
  public mobileNumber: string;
  public alternativeMobileNumber: string;
  public careerLevelId: number;
   
  public careerLevel : CareerLevel;
  public jobTypes: JobTypes;
  public preferredJobCategories: JobCategory;
  public minimumSalary: number;

  public experienceYears: number;
  public skills : Skills;
  public userLanguages : UserLanguage;
  public employeeLinks : EmployeeLinks;


  public cV: string;
  public photo: string;
  public summary: string;
  public educationLevelId: number;
   
  public educationLevel: EducationLevel;
  public nationalityId: number;
  public nationality: Country;
  public user: ApplicationUser;
   
  public applications : Application;
}
