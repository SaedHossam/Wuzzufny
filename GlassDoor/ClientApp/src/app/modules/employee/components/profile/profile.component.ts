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
import { UpdateEmployeeDto } from '../../../../models/update-emplyee-dto';
import { CarrerInterestDto } from '../../../../models/carrer-interest-dto';
import { EducationAndExpDto } from '../../../../models/education-and-exp-dto';
import { SkillAndLanguageDto } from '../../../../models/skill-and-language-dto';
import { EmployeeLinks } from '../../../../models/employee-links';
import { NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  active = 'General Info';
  //dateOfBirth: NgbDateStruct;
  //isWillingToRelocate: boolean;

  countries: Country[];
  cities: City[];
  careerLevels: CareerLevel[];
  jobTypes: JobTypes[];
  jobCategories: JobCategory[];
  educationLevels: EducationLevel[];
  skills: Skills[];
  skillsList: Skills[];
  languages: Language[];

  constructor(
    private countryService: CountryService,
    private cityService: CityService,
    private careerLevelService: CareerLevelService,
    private jobTypeService: JobTypeService,
    private jobCategoryService: JobCategoryService,
    private educationLevelService: EducationLevelService,
    private skillService: SkillService,
    private languageService: LanguagesService,
    private userProfileService: UserProfileService,
    private parserFormatter: NgbDateParserFormatter
  ) {
  }

  employee: Employee;
  profile: UpdateEmployeeDto = new UpdateEmployeeDto();
  career: CarrerInterestDto = new CarrerInterestDto();
  edu_exp: EducationAndExpDto = new EducationAndExpDto();
  skill_lang: SkillAndLanguageDto = new SkillAndLanguageDto();
  skill: Skills[];
  empLink: EmployeeLinks = new EmployeeLinks();

  birthDateStruct: any;

  ngOnInit(): void {
    this.countryService.getCountries().subscribe(c => { this.countries = c });
    this.cityService.getCities().subscribe(c => { this.cities = c });
    this.careerLevelService.getCareerLevels().subscribe(c => { this.careerLevels = c });
    this.jobTypeService.getCompanyTypes().subscribe(j => { this.jobTypes = j });
    this.jobCategoryService.getjobCategories().subscribe(j => { this.jobCategories = j });
    this.educationLevelService.getEducationLevels().subscribe(e => { this.educationLevels = e });
    this.skillService.getSkills().subscribe(s => { this.skills = s });
    this.languageService.getLanguages().subscribe(l => { this.languages = l });



    this.userProfileService.getMyProfileData().subscribe(a => {
      this.profile = a;
      this.career = a;
      this.edu_exp = a;

      this.profile.birthDate = new Date(this.profile.birthDate);
      //this.birthDateStruct = {
      //  day: this.profile.birthDate.getDay(),
      //  month: this.profile.birthDate.getMonth(),
      //  year: this.profile.birthDate.getFullYear()
      //};

      console.log(this.profile.birthDate);
      console.log(this.profile.birthDate.getDate());
      console.log(this.profile.birthDate.getMonth());
      console.log(this.profile.birthDate.getFullYear());


      this.birthDateStruct = {
        year: this.profile.birthDate.getFullYear(),
        month: this.profile.birthDate.getMonth() + 1,
        day: this.profile.birthDate.getDate()
      }
    },
      (error) => {
        console.log(error);
      });
  }


  searchSkills(event) {
    this.skillsList = this.skills.filter(c => c.name.startsWith(event.query));
  }

  update() {
    this.profile.birthDate = new Date(this.birthDateStruct.year, this.birthDateStruct.month - 1, this.birthDateStruct.day + 1);
    console.log("prof", this.profile);
    this.userProfileService.editEmpProfile(this.profile).subscribe(a => {
      this.employee = a;
    })
  }


























  updateCarrerInterest() {
    this.userProfileService.editCareerInterest_InUI(this.career).subscribe(a => {
      this.employee = a;
    })
  }

  updateEduExp_InUI() {
    console.log(this.edu_exp)
    this.userProfileService.editEduExp_InUI(this.edu_exp).subscribe(a => {
      console.log(a)
      this.employee = a;
      console.log(this.edu_exp)

    })
  }

  updateSkills_Lang_InUI() {
    this.skill_lang.skillId = this.skill.map((val, index) => (val.id));
    this.userProfileService.editSkill_Lang_InUI(this.skill_lang).subscribe(a => {
      this.employee = a;
    })
  }

  updateEmpLinks() {
    console.log(this.empLink);
    this.userProfileService.getEmpLink(this.empLink).subscribe(o => {
      this.employee = o;
      console.log(this.empLink);
    })
  }
}
//this.postJobDto.skills = postjobform.value.skills.map((val, index) => ({ skillsId: val.id }));
