import { CareerLevels } from "./career-levels";
import { Cities } from "./cities";
import { Countries } from "./countries";
import { Currencies } from "./currencies";
import { educationLevels } from "./education-levels";
import { JobCategories } from "./job-categories";
import { JobTypes } from "./job-types";
import { SalaryRates } from "./salary-rates";
import { Skills } from "./skills";

export class SeedAngular {
    constructor(public cities:Cities[],public careerLevels:CareerLevels[], public countries:Countries[],public currencies:Currencies[],public jobCategories:JobCategories[],public jobTypes:JobTypes[],public salaryRates:SalaryRates[],public skills:Skills[]
    ,public educationLevels:educationLevels[]){
    }
}
