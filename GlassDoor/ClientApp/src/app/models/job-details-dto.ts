import { Skills } from "./skills";

export class JobDetailsDto {

  constructor(
    public id?: number,
    public experienceNeededMin?: number,
    public experienceNeededMax?: number,
    public careerLevelName?: string,
    public educationLevelName?: string,
    public salaryMin?: number,
    public salaryMax?: number,
    public salaryCurrencyName?: string,
    public salaryCurrencySymbol?: string,
    public salaryRate?: string,
    public category?: string,
    public description?: string,
    public requirements?: string,
    public responsibilities?: string,
    public jobId?: number,
    public jobTitle?: string,
    public jobCountry?: string,
    public jobCity?: string,
    public companyId?: number,
    public companyName?: string,
    public jobType?: string,
    public salaryCurrencyCode?: string,
    public createdDate?: Date,
    public yearFounded?: Date,
    public name?: string,
    public logo?: string,
    public skillsNames?: Skills[],
    public applied?: boolean,
    public vacancies?: number,
  ) { }
}
