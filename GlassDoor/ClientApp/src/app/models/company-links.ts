import { Company } from "./company";

export class CompanyLinks {


  constructor(id?: number, company?: Company)
  {

    this.id = id;
    this.company = company;
  }
  public id: number;
  public company: Company;

}
