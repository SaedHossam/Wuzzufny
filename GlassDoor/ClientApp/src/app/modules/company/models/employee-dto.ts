import { CareerLevels } from './career-levels';
import { educationLevels } from './education-levels';
import { Countries } from './countries';
import { Cities } from './cities';
import { EmployeeLinksDto } from './employee-links-dto';
import { UserLanguagesDto } from './user-languages-dto';
import { Skills } from './skills';
export interface EmployeeDto {
    birthDate:Date,
    gender:string,
    militaryStatus:string,
    city:Cities,
    country:Countries,
    isWillingToRelocate:boolean,
    mobileNumber:string,
    alternativeMobileNumber:string,
    careerLevel:CareerLevels,
    minimumSalary:number,
    experienceYears:number,
    cV:string,
    photo:string,
    summary:string,
    educationLevel:educationLevels,
    nationalityId:number,
    skills:Skills,
    userLanguages:UserLanguagesDto,
    employeeLinks:EmployeeLinksDto
}
