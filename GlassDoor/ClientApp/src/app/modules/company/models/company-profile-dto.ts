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
    public companyType1: string,
    public companyIndustry1: string,
    public companySize1: string,
    public city: string,
    public country: string,
    public cities: Cities[],
    public companyLinks: CompanyLinksDto[]) {}
}
