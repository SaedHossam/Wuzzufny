import { publish } from "rxjs/operators";
import { JobDetailsDto } from "./job-details-dto";
import { JobSkill } from "./job-skill";

export class PostJobDto {
  constructor(public title:  string, public jobTypeId: number, public cityId: number, public countryId: number, public numberOfVacancies: number, public jobDetails: JobDetailsDto, public skills: JobSkill[],public id?:number)
    {
        
  
        }
      }
      

