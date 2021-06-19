import { Cities } from "./cities";
import { CompanyLinksDto } from "./company-links-dto";
import { LocationDto } from "./location-dto";

export interface EditCompanyProfileDto {
    name:string,
    logo:string,
    aboutUs:string,
    yearFounded:Date,
    phone:number,
    companyTypeId :number,
    companyIndustryId:number,
    companySizeId:number,
    locations :LocationDto[],
    companyLinks:CompanyLinksDto[],
    id?:number,
    requestStatusId?:number
}
