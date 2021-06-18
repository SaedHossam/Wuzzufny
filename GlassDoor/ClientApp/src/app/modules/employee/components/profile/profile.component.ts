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
import { Employee } from '../../../../models/employee';
import { UserProfileService } from '../../../../shared/services/user-profile.service';
import { ActivatedRoute } from '@angular/router';
import { UpdateEmplyeeDto } from '../../../../models/update-emplyee-dto';
import { CarrerInterestDto } from '../../../../models/carrer-interest-dto';
import { EducationAndExpDto } from '../../../../models/education-and-exp-dto';
import { SkillAndLanguageDto } from '../../../../models/skill-and-language-dto';
import { EmployeeLinks } from '../../../../models/employee-links';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  active = 'General Info';
  //dateOfBirth: NgbDateStruct;
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
    private _skillService: SkillService, private _languageService: LanguagesService,
    private service: UserProfileService, private ac: ActivatedRoute
  ) { }

  Emp: Employee = new Employee();
  profile: UpdateEmplyeeDto = new UpdateEmplyeeDto();
  career: CarrerInterestDto = new CarrerInterestDto();
  edu_exp: EducationAndExpDto = new EducationAndExpDto();
  skill_lang: SkillAndLanguageDto = new SkillAndLanguageDto();
  skill: Skills[];
  empLink: EmployeeLinks = new EmployeeLinks();


  ngOnInit(): void {
    this._countryService.getCountries().subscribe(c => { this.countries = c });
    this._cityService.getCities().subscribe(c => { this.cities = c });
    this._careerLevelService.getCareerLevels().subscribe(c => { this.careerLevels = c });
    this._JobTypeService.getCompanyTypes().subscribe(j => { this.jobTypes = j });
    this._jobCategoryService.getjobCategories().subscribe(j => { this.jobCategories = j });
    this._educationLevelService.getEducationLevels().subscribe(e => { this.educationLevels = e });
    this._skillService.getSkills().subscribe(s => { this.skills = s });
    this._languageService.getLanguages().subscribe(l => { this.languages = l });


    this.ac.params.subscribe(p => {

      this.service.getEmpById(p.id).subscribe(a => {
        console.log(a);
        this.profile = a;
        this.career = a;
        this.edu_exp = a;


      });
    });
  }


  searchSkills(event) {
    this.skillsList = this.skills.filter(c => c.name.startsWith(event.query));
  }

  update() {

    //this.profile.birthDate = new Date(this.profile.birthDate.year, this.profile.birthDate.month-1, this.profile.birthDate.day-1, 0, 0, 0, 0);
    console.log("prof", this.profile);
    this.service.editEmpProfile(this.profile).subscribe(a => {
      this.Emp = a;
      console.log("a", a);
      console.log("prof", this.profile);

    })
  }

  updateCarrerInterest() {
    this.service.editCareerInterest_InUI(this.career).subscribe(a => {
      this.Emp = a;
    })
  }

  updateEduExp_InUI() {
    console.log(this.edu_exp)
    this.service.editEduExp_InUI(this.edu_exp).subscribe(a => {
      console.log(a)
      this.Emp = a;
      console.log(this.edu_exp)

    })
  }

  updateSkills_Lang_InUI() {
    this.skill_lang.skillId = this.skill.map((val, index) => (val.id));
    this.service.editSkill_Lang_InUI(this.skill_lang).subscribe(a => {
      this.Emp = a;
    })
  }

  updateEmpLinks() {
    console.log(this.empLink);
    this.service.getEmpLink(this.empLink).subscribe(o => {
      this.Emp = o;
      console.log(this.empLink);


    })
  }
}
//this.postJobDto.skills = postjobform.value.skills.map((val, index) => ({ skillsId: val.id }));
