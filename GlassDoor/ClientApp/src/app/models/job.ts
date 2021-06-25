export class Job {
  constructor(
    public id?: number,
    public title?: string,
    public jobTypeName?: string,
    public numberOfVacancies?: number,
    public jobCityName?: string,
    public jobCountryName?: string,
    public isOpen?: boolean,
    public createdDate?: Date,
    public companyId?: number,
    public companyName?: string,
    public logo?: string,
    public name?: string,
    public totalApplications?: number,
    public totalViews?: number,
    public applicationViewed?: number,
    public applicationInConsideration?: number,
    public applicationRejected?: number,
    public applicationHired?: number,
  ) { }
}
