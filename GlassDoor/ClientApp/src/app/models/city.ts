import { Company } from "./company";
import { Country } from "./country";
import { Employee } from "./employee";
import { Job } from "./job";

export class City {

  constructor(id?: number, name?: string, location?: string, country?: Country,
    company?: Company, job?: Job, employee?: Employee)
  {

    this.id = id;
    this.name = name;
    this.location = location;
    this.country = country;
    this.company = company;
    this.job = job;
    this.employee = employee;
  }
  public id: number;
  public name: string;
  public location: string;
  public country: Country;
  public company: Company;
  public job: Job;
  public employee: Employee;
}
