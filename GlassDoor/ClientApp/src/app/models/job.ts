




export class Job {
  constructor(public id?: number, public title?: string, public jobTypeName?: string, public numberOfVacancies?: number,
    public jobCityName?: string, public jobCountryName?: string, public isOpen?: boolean,
    public createdDate?: Date, public companyName?: string)
  { }
}
