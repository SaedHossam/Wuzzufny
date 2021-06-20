export class AdminInsights {
  constructor(public openJobs: number,
    public companiesCount: number,
    public openJobsByType: JobsByType[],
    public openJobsByCountry: JobsByCountry[],
    public openJobsByJobCategory: JobsByJobCategory[],
    public totalJobsByDate: TotalJobsByDate[]) {

  }
}

export class JobsByType {
  constructor(public type: string, public count: number) { }
}

export class JobsByCountry {
  constructor(public country: string, public count: number) { }
}

export class JobsByJobCategory {
  constructor(public category: string, public count: number) { }
}

export class TotalJobsByDate {
  constructor(public date: String, public count: number) { }
}
