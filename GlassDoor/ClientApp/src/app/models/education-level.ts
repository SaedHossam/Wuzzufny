import { Employee } from "./employee";
import { JobDetails } from "./job-details";

export class EducationLevel {

  constructor(id?: number, name?: string, jobDetails?: JobDetails,
    employees?: Employee) {

    this.id = id;
    this.name = name;
    this.jobDetails = jobDetails;
    this.employees = employees;

  }
  public id: number;
  public name: string;
  public employees: Employee;
  public jobDetails: JobDetails;
}
