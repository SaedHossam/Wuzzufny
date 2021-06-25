import { ApplicationUser } from "./application-user";
import { Company } from "./company";

export class CompanyManagers {

  constructor(id?: number, userId?: string, user?: ApplicationUser, company?: Company)
  {

    this.id = id;
    this.userId = userId;
    this.user = user;
    this.company = company;
  }
  public id: number;
  public userId: string;
  public user: ApplicationUser;
  public company: Company;
}
