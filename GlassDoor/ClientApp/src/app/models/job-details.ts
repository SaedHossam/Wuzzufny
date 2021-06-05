import { CareerLevel } from "./career-level";
import { Job } from "./job";

export class JobDetails {
  constructor(id?: number, carrerLevel?: string, experienceNeededMin?: number, experienceNeededMax?: number,
    careerLevelId?: number, careerLevel?: CareerLevel, salaryMin?: number, salaryMax?: number,
    subCategory?: string, description?: string, requirements?: string, responsibilities?: string, status?: string, category?: string,
    salaryCurrency?: string, job?: Job) {
    this.id = id;
    this.carrerLevel = carrerLevel;
    this.experienceNeededMin = experienceNeededMin;
    this.experienceNeededMax = experienceNeededMax;
    this.category = category;
    this.subCategory = subCategory;
    this.status = status;
    this.salaryMin = salaryMin;
    this.salaryMax = salaryMax;
    this.description = description;
    this.requirements = requirements;
    this.responsibilities = responsibilities;
    //this.educationLevel = educationLevel;
    this.salaryCurrency = salaryCurrency;
    this.careerLevelId = careerLevelId;
    this.careerLevel = careerLevel;
    this.job = job;
  }
  public id: number;
  public carrerLevel: string;
  public experienceNeededMin: number;
  public experienceNeededMax: number;
  public educationLevel: string;
  public salaryMin: number;
  public salaryMax: number;
  public category: string;
  public subCategory: string;
  public description: string;
  public requirements: string;
  public responsibilities: string;
  public status: string;
  public salaryCurrency: string;
  public careerLevelId: number;
  public careerLevel: CareerLevel;
  public job: Job;

}
