import { CareerLevels } from "./career-levels";
import { Cities } from "./cities";
import { Countries } from "./countries";
import { Currencies } from "./currencies";
import { JobCategories } from "./job-categories";
import { JobTypes } from "./job-types";
import { SalaryRates } from "./salary-rates";
import { Skills } from "./skills";

export class SeedAngular {
    constructor(public cities:Cities[],public careerLevel:CareerLevels[], public countries:Countries[],public currencies:Currencies[],public jobCategries:JobCategories[],public jobTypes:JobTypes[],public salaryRate:SalaryRates[],public skills:Skills[]
         ){
    }
}
