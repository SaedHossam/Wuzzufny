import { HttpClient, HttpClientModule, HttpClientXsrfModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CustomFormsModule } from 'ng2-validation'
import { FormControl, Validators, FormGroup, FormBuilder, RequiredValidator, FormArray } from '@angular/forms';
import { EnvironmentUrlService } from 'src/app/shared/services/environment-url.service';
import { Skills } from '../../models/skills';
import { PostJobDto } from '../../models/post-job-dto';
import { Router } from '@angular/router';
import { JobTypes } from "../../../../models/job-types";
import { JobTypeService } from "../../../../shared/services/job-type.service"
import { Country } from "../../../../models/country";
import { CountryService } from "../../../../shared/services/country.service"
import { City } from "../../../../models/city";
import { CityService } from "../../../../shared/services/city.service";
import { CareerLevelService } from "../../../../shared/services/career-level.service";
import { CareerLevel } from "../../../../models/career-level";
import { EducationLevel } from "../../../../models/education-level";
import { EducationLevelService } from "../../../../shared/services/education-level.service";
import { Currency } from "../../../../models/currency";
import { CurrencyService } from "../../../../shared/services/currency.service";
import { SalaryRate } from "../../../../models/salary-rate";
import { SalaryRateService } from "../../../../shared/services/salary-rate.service";
import { JobCategory } from "../../../../models/job-category";
import { JobCategoryService } from "../../../../shared/services/job-category.service";
import { SkillService } from "../../../../shared/services/skill.service";

@Component({
  selector: 'app-post-job',
  templateUrl: './post-job.component.html',
  styleUrls: ['./post-job.component.css']
})

export class PostJobComponent implements OnInit {
  jobTypes: JobTypes[];
  countries: Country[];
  cities: City[];
  careerLevels: CareerLevel[];
  educationLevels: EducationLevel[];
  currencies: Currency[];
  salaryRates: SalaryRate[];
  jobCategories: JobCategory[];
  skills: Skills[];

  postJobDto: PostJobDto = {
    title: null,
    jobTypeId: null,
    cityId: null,
    countryId: null,
    numberOfVacancies: null,

    jobDetails: {
      experienceNeededMin: null,
      experienceNeededMax: null,
      careerLevelId: null,
      educationLevelId: null,
      salaryMin: null,
      salaryMax: null,
      salaryCurrencyId: null,
      salaryRateId: null,
      jobCategoryId: null,
      description: null,
      requirements: null,
      responsibilities: null,
    },
    skills: null
  }

  employeeform: FormGroup;
  public postjobform: FormGroup;
  constructor(private http: HttpClient,
    private _envUrl: EnvironmentUrlService,
    private _router: Router,
    private _JobTypeService: JobTypeService,
    private _countryService: CountryService,
    private _cityService: CityService,
    private _careerLevelService: CareerLevelService,
    private _educationLevelService: EducationLevelService,
    private _currencyService: CurrencyService,
    private _salaryRateService: SalaryRateService,
    private _jobCategoryService: JobCategoryService,
    private _skillService: SkillService
  ) { }

  public results: Skills[];
  ngOnInit(): void {
    this.postjobform = new FormGroup({
      'title': new FormControl(null, [Validators.required]),
      'jobTypeId': new FormControl(null, [Validators.required]),
      'countryId': new FormControl(null, [Validators.required]),
      'cityId': new FormControl(null, [Validators.required]),
      'numberOfVacancies': new FormControl(null, [Validators.required]),
      'experienceNeededMin': new FormControl(null, [Validators.required]),
      'experienceNeededMax': new FormControl(null, [Validators.required]),
      'careerLevelId': new FormControl(null, [Validators.required]),
      'educationLevelId': new FormControl(null, [Validators.required]),
      'salaryMin': new FormControl(null),
      'salaryMax': new FormControl(null),
      'salaryCurrencyId': new FormControl(null, [Validators.required]),
      'salaryRateId': new FormControl(null, [Validators.required]),
      'jobCategoryId': new FormControl(null, [Validators.required]),
      'description': new FormControl(null, [Validators.required]),
      'requirements': new FormControl(null, [Validators.required]),
      'responsibilities': new FormControl(null, [Validators.required]),
      'skills': new FormControl(null, [Validators.required])

    });

    this._JobTypeService.getCompanyTypes().subscribe(jt => { this.jobTypes = jt });
    this._countryService.getCountries().subscribe(c => { this.countries = c });
    this._cityService.getCities().subscribe(c => { this.cities = c });
    this._careerLevelService.getCareerLevels().subscribe(c => { this.careerLevels = c });
    this._educationLevelService.getEducationLevels().subscribe(e => { this.educationLevels = e });
    this._currencyService.getCurrencies().subscribe(c => { this.currencies = c });
    this._salaryRateService.getSalaryRates().subscribe(s => { this.salaryRates = s });
    this._jobCategoryService.getjobCategories().subscribe(jc => { this.jobCategories = jc });
    this._skillService.getSkills().subscribe(s => { this.skills = s });
  }

  search(event) {
    this.results = this.skills.filter(c => c.name.startsWith(event.query));
  }


  public postjob(postjobform) {
    this.postJobDto.title = postjobform.value.title;
    this.postJobDto.cityId = postjobform.value.cityId;
    this.postJobDto.jobTypeId = postjobform.value.jobTypeId;
    this.postJobDto.countryId = postjobform.value.countryId;
    this.postJobDto.numberOfVacancies = postjobform.value.numberOfVacancies;
    this.postJobDto.jobDetails.experienceNeededMin = postjobform.value.experienceNeededMin;
    this.postJobDto.jobDetails.experienceNeededMax = postjobform.value.experienceNeededMax;
    this.postJobDto.jobDetails.careerLevelId = postjobform.value.careerLevelId;
    this.postJobDto.jobDetails.educationLevelId = postjobform.value.educationLevelId;
    this.postJobDto.jobDetails.salaryMin = postjobform.value.salaryMin;
    this.postJobDto.jobDetails.salaryMax = postjobform.value.salaryMax;
    this.postJobDto.jobDetails.salaryCurrencyId = postjobform.value.salaryCurrencyId;
    this.postJobDto.jobDetails.salaryRateId = postjobform.value.salaryRateId;
    this.postJobDto.jobDetails.jobCategoryId = postjobform.value.jobCategoryId;
    this.postJobDto.jobDetails.description = postjobform.value.description;
    this.postJobDto.jobDetails.requirements = postjobform.value.requirements;
    this.postJobDto.jobDetails.responsibilities = postjobform.value.responsibilities;
    this.postJobDto.skills = postjobform.value.skills.map((val, index) => ({ SkillsId: val.id }));
    //console.log(this.postJobDto);

    this.http.post(this._envUrl.urlAddress + "/api/jobs", this.postJobDto).subscribe(a => {
      this._router.navigate(['/company/']);
    })

  }
}


