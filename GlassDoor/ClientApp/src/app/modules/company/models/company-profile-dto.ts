import { CompanySize } from "src/app/interfaces/shared/company-size.model";
import { CompanyIndustry } from "src/app/models/company-industry";
import { CompanyLinks } from "src/app/models/company-links";
import { CompanyType } from "src/app/models/company-type";
import { Cities } from "./cities";
import { CompanyLinksDto } from "./company-links-dto";

export class CompanyProfileDto {

    constructor(public id:number , public name:string,public logo:string,public aboutUs:string,public YearFounded:Date,public phone:number ,public CompanyTypeId :number,public companyType:CompanyType ,public companyIndustry:CompanyIndustry, public companySize:CompanySize
        ,public companyIndustryId:number ,public cities:Cities[],public companyLinks:CompanyLinksDto){

    }
}
