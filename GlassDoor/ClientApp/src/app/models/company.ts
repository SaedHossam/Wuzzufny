import { City } from "./city";
import { CompanyIndustry } from "./company-industry";
import { CompanyLinks } from "./company-links";
import { CompanyManagers } from "./company-managers";
import { CompanySize } from "./company-size";
import { CompanyType } from "./company-type";
import { Job } from "./job";

export class Company {
  constructor(id?: number, name?: string, logo?: string, aboutUs?: string,
    yearFounded?: Date, phone?: string, companyType?: CompanyType,
    companyIndustry?: CompanyIndustry, companySize?: CompanySize,
    isActive?: boolean, locations?: City, jobs?: Job, companyManagers?: CompanyManagers,
    companyLinks?: CompanyLinks)
  {

    this.id = id;
    this.name = name;
    this.logo = logo;
    this.aboutUs = aboutUs;
    this.yearFounded = yearFounded;
    this.phone = phone;
    this.companyType = companyType;
    this.companyIndustry = companyIndustry;
    this.companySize = companySize;
    this.isActive = isActive;
    this.locations = locations;
    this.jobs = jobs;
    this.companyManagers = companyManagers;
    this.companyLinks = companyLinks;
  }
  public id: number;
  public name: string;
  public logo: string;
  public aboutUs: string;
  public yearFounded: Date;
  public phone: string;
  public companyType: CompanyType;

  public companyIndustry: CompanyIndustry;
  public companySize: CompanySize;
  public isActive: boolean;
  public locations: City;
  public jobs: Job;
  public companyManagers: CompanyManagers;
  public companyLinks: CompanyLinks;
}
