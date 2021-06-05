import { Employee } from "./employee";
import { JobDetails } from "./job-details";

export class CareerLevel {
  constructor(id?: number, name?: string, jobDetails?: JobDetails, employee?: Employee) {
    this.id = id;
    this.name = name;
    this.jobDetails = jobDetails;
    this.employee = employee;

  }

  public id: number;
  public name: string;
  public jobDetails: JobDetails;
  public employee: Employee;
  
}
