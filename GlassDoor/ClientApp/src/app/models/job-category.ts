import { Employee } from "./employee";
import { JobDetails } from "./job-details";

export class JobCategory {
  constructor(id?: number, name?: string, employees?: Employee,
    jobDetails?: JobDetails) {

    this.id = id;
    this.name = name;
    this.employees = employees;
    this.jobDetails = jobDetails;


  }
  public id: number;
  public name: string;
  public employees: Employee;
  public jobDetails: JobDetails;
}
