import { JobDetails } from "./job-details";

export class SalaryRate {
  constructor(id?: number, name?: string, jobDetails?: JobDetails)
  {

    this.id = id;
    this.name = name;
    this.jobDetails = jobDetails;

  }
  public id: number;
  public name: string;

  public jobDetails: JobDetails;

}

