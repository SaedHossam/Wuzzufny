import { publish } from "rxjs/operators";
import { JobDetailsDto } from "./job-details-dto";
import { Skills } from "./skills";
export class PostJobDto {
    constructor(public title:string, public jobTypeId:number,public cityId:number,public countryId:number,public numberOfVacancies:number ,public jobDetails:JobDetailsDto, public skills:Skills[] )
    {
        
        
       
        }
      }
      

