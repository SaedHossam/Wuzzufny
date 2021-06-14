import { CareerLevel } from "./career-level";
import { Currency } from "./currency";
import { EducationLevel } from "./education-level";
import { Job } from "./job";
import { JobCategory } from "./job-category";
import { SalaryRate } from "./salary-rate";

export class JobDetails {
  constructor(public id?: number,public careerLevel?: CareerLevel,public experienceNeededMin?: number,public experienceNeededMax?: number,
    public careerLevelId?: number, public salaryMin?: number, public salaryMax?: number,
    public description?: string, public requirements?: string, public responsibilities?: string, public status?: string, public category?: JobCategory,
    public salaryCurrency?: Currency, public salaryRate?: SalaryRate, public job?: Job,
    public educationLevel?: EducationLevel, public yearFounded?: Date) {
 
  }


}
