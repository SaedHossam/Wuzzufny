import { JobStatisticsViewModel } from "./job-statistics-view-model";

export class Application {
  constructor(
    public jobId?: number,
    public applicationId?: number,
    public companyLogo?: string,
    public status?: string,
    public jobTitle?: string,
    public companyName?: string,
    public companyId?: number,
    public city?: string,
    public country?: string,
    public industry?: string,
    public jobType?: string,
    public applyDate?: Date,
    public postDate?: Date,
    public vacancies?: number,
    public isArchived?: boolean,
    public jobStatisticsViewModel?: JobStatisticsViewModel
  ) {
  }


}
