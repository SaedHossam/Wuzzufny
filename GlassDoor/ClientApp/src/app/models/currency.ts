import { JobDetails } from "./job-details";

export class Currency {

  constructor(id?: number, symbol?: string, name?: string, code?: string,
    jobDetails?: JobDetails) {

    this.id = id;
    this.name = name;
    this.symbol = symbol;
    this.code = code;
    this.jobDetails = jobDetails;

  }
  public id: number;
  public name: string;
  public symbol: string;
  public code: string;
  public jobDetails: JobDetails;
}
