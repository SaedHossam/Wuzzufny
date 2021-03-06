import { CompanySize } from './../../../models/company-size';
import { CompanyIndustry } from './../../../models/company-industry';
import { CompanyType } from "src/app/models/company-type"
import { Cities } from "./cities"
import { CompanyLinksDto } from "./company-links-dto"
import { LocationDto } from './location-dto';

export interface CompanyProfile {
    name:string,
    logo:string,
    aboutUs:string,
    yearFounded:Date,
    phone:number,
    companyType :CompanyType,
    companyIndustry:CompanyIndustry,
    companySize:CompanySize,
    locations :LocationDto[],
    
    companyLinks:CompanyLinksDto[],
    id?:number,
    requestStatusId?:number

}

