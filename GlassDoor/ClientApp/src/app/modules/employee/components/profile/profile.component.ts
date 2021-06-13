import { Component, OnInit } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { Country } from "../../../../models/country";
import { CountryService } from "../../../../shared/services/country.service";
import { City } from "../../../../models/city";
import { CityService } from "../../../../shared/services/city.service";
import { CareerLevelService } from "../../../../shared/services/career-level.service";
import { CareerLevel } from "../../../../models/career-level";
import { JobTypeService } from "../../../../shared/services/job-type.service";
import { JobTypes } from "../../../../models/job-types";
import { JobCategory } from "../../../../models/job-category";
import { JobCategoryService } from "../../../../shared/services/job-category.service";
import { EducationLevel } from "../../../../models/education-level";
import { EducationLevelService } from "../../../../shared/services/education-level.service";
import { Skills } from "../../../../models/skills";
import { SkillService } from "../../../../shared/services/skill.service";
import { LanguagesService } from "../../../../shared/services/languages.service";
import { Language } from "../../../../models/language";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  active = 'General Info';
  dateOfBirth: NgbDateStruct;
  isWillingToRelocate: boolean = true;

  countries: Country[];
  cities: City[];
  careerLevels: CareerLevel[];
  jobTypes: JobTypes[];
  jobCategories: JobCategory[];
  educationLevels: EducationLevel[];
  skills: Skills[];
  skillsList: Skills[];
  languages: Language[];

  constructor(private _countryService: CountryService, private _cityService: CityService, private _careerLevelService: CareerLevelService,
    private _JobTypeService: JobTypeService, private _jobCategoryService: JobCategoryService, private _educationLevelService: EducationLevelService,
    private _skillService: SkillService, private _languageService: LanguagesService
    ) { }

  ngOnInit(): void {
    this._countryService.getCountries().subscribe(c => { this.countries = c });
    this._cityService.getCities().subscribe(c => { this.cities = c });
    this._careerLevelService.getCareerLevels().subscribe(c => { this.careerLevels = c });
    this._JobTypeService.getCompanyTypes().subscribe(j => { this.jobTypes = j });
    this._jobCategoryService.getjobCategories().subscribe(j => { this.jobCategories = j });
    this._educationLevelService.getEducationLevels().subscribe(e => { this.educationLevels = e });
    this._skillService.getSkills().subscribe(s => { this.skills = s });
    this._languageService.getLanguages().subscribe(l => { this.languages = l });
  }


  searchSkills(event) {
    this.skillsList = this.skills.filter(c => c.name.startsWith(event.query));
  }
}
