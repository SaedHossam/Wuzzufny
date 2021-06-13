import { CompanyLinks } from "src/app/models/company-links";
import { Cities } from "./cities";
import { CompanyLinksDto } from "./company-links-dto";

export class CompanyProfileDto {

    constructor(public id:number , public name:string,public logo:string,public aboutUs:string,public YearFounded:Date,public phone:number ,public CompanyTypeId :number,public companyType :string ,public companyIndustry:string,public companyIndustryId:number ,public cities:Cities[],public companyLinks:CompanyLinksDto){

    }
}
