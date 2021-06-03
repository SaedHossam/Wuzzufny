export class JobDetails {
  constructor(id?: number, carrerLevel?: string, experienceNedded?: number, educationLevel?: string, salary?: number,
    subCategory?: string, description?: string, requirements?: string, responsibilities?: string, status?: string, category?: string) {
    this.id = id;
    this.carrerLevel = carrerLevel;
    this.experienceNedded = experienceNedded;
    this.category = category;
    this.subCategory = subCategory;
    this.status = status;
    this.salary = salary;
    this.description = description;
    this.requirements = requirements;
    this.responsibilities = responsibilities;
    this.educationLevel = educationLevel;
  }
  public id: number;
  public carrerLevel: string;
  public experienceNedded: number;
  public educationLevel: string;
  public salary: number;
  public category: string;
  public subCategory: string;
  public description: string;
  public requirements: string;
  public responsibilities: string;
  public status: string;


}
