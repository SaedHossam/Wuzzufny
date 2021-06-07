import { Employee } from "./employee";
import { Job } from "./job";

export class Skills {
  constructor(id?: number, name?: string, jobs?: Job, employees?: Employee)
  {
    this.id = id;
    this.name = name;
    this.jobs = jobs;
    this.employees = employees;
  }
  public id: number;
  public name: string;
  public jobs: Job;
  public employees: Employee;


}
