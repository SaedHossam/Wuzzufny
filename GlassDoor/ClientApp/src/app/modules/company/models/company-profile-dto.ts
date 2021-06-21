import { Cities } from "./cities";
import { CompanyLinksDto } from "./company-links-dto";

export class CompanyProfileDto {

  constructor(
    public id: number,
    public name: string,
    public logo: string,
    public aboutUs: string,
    public yearFounded: Date,
    public phone: number,
    public companyType: string,
    public companyIndustry: string,
    public companySize: string,
    public city: string,
    public country: string,
    public cities: Cities[],
    public companyLinks: CompanyLinksDto[]) {}
}
