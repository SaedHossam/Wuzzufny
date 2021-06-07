import { Company } from "./company";

export class CompanySize {

  constructor(id?: number, name?: string, companies?: Company)
  {

    this.id = id;
    this.name = name;
    this.companies = companies;
 
  }
  public id: number;
  public name: string;
  public companies: Company;

}
