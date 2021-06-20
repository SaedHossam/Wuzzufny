import { Component, OnInit, ViewChild } from '@angular/core';
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
import { EmployeeLink } from '../../../../models/employee-links';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { UploadFilesService } from '../../../../shared/services/upload-files.service';
import { HttpEventType } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  active = 'General Info';
  imageUpload = new FormGroup({
    imageFile: new FormControl('')
  });

  cvUpload = new FormGroup({
    cvFile: new FormControl('')
  });

  @ViewChild(NgForm) personalInfo: NgForm;

  countries: Country[];
  cities: City[];
  careerLevels: CareerLevel[];
  jobTypes: JobTypes[];
  jobCategories: JobCategory[];
  educationLevels: EducationLevel[];
  skills: Skills[];
  skillsList: Skills[];
  languages: Language[];
  employee: Employee;
  profile: UpdateEmployeeDto = new UpdateEmployeeDto();
  career: CarrerInterestDto = new CarrerInterestDto();
  edu_exp: EducationAndExpDto = new EducationAndExpDto();
  skill_lang: SkillAndLanguageDto = new SkillAndLanguageDto();
  employeeSkills: Skills[];
  links: EmployeeLink[];
  linkedInLink: string;
  facebookLink: string
  twitterLink: string;
  githubLink: string;

  birthDateStruct: any;

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
    private uploadFilesService: UploadFilesService,
    private toastrService: ToastrService) {
  }

  ngOnInit(): void {
    this.countryService.getCountries().subscribe(c => { this.countries = c });
    this.cityService.getCities().subscribe(c => { this.cities = c });
    this.careerLevelService.getCareerLevels().subscribe(c => { this.careerLevels = c });
    this.jobTypeService.getCompanyTypes().subscribe(j => { this.jobTypes = j });
    this.jobCategoryService.getjobCategories().subscribe(j => { this.jobCategories = j });
    this.educationLevelService.getEducationLevels().subscribe(e => { this.educationLevels = e });
    this.skillService.getSkills().subscribe(s => { this.skills = s });
    this.languageService.getLanguages().subscribe(l => { this.languages = l });

    this.loadEmployeeData();
  }

  loadEmployeeData() {
    this.userProfileService.getMyProfileData().subscribe(a => {
      this.profile = a;

      this.career.careerLevelId = a.careerLevelId;
      this.career.jobTypeId = a.jobTypesName.map((jobTypes) => jobTypes.id);
      this.career.preferredJobCategories = a.preferredJobCategoriesName.map((jobCategory) => jobCategory.id);
      
      this.edu_exp.educationLevelId = a.educationLevelId;
      this.edu_exp.experienceYears = a.experienceYears;

      this.employeeSkills = a.skillsNames;
      this.skill_lang.languageId = a.userLanguagesNames.map(language => language.languageId);

      this.links = a.employeeLinksNames.map(link => new EmployeeLink(link.name, link.link));

      this.facebookLink = this.links.find(link => link.name === "facebook")?.link;
      this.githubLink = this.links.find(link => link.name === "github")?.link;
      this.twitterLink = this.links.find(link => link.name === "twitter")?.link;
      this.linkedInLink = this.links.find(link => link.name === "linkedin")?.link;

      this.profile.birthDate = new Date(this.profile.birthDate);
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
    this.userProfileService.editEmpProfile(this.profile).subscribe(a => { 
      this.toastrService.success('saved your changes successfuly', 'success');
    },
      error => { },
      () => this.loadEmployeeData()
    );
  }

  updateCarrerInterest() {
    this.userProfileService.editCareerInterest_InUI(this.career).subscribe(a => {
      this.toastrService.success('saved your changes successfuly', 'success');
     },
      error => { },
      () => this.loadEmployeeData()
    );
  }

  updateEduExp_InUI() {
    this.userProfileService.editEduExp_InUI(this.edu_exp).subscribe(a => {
      this.toastrService.success('saved your changes successfuly', 'success');
     },
      error => { },
      () => this.loadEmployeeData()
    );
  }

  updateSkills_Lang_InUI() {
    this.skill_lang.skillId = this.employeeSkills.map((val, index) => (val.id));
    this.userProfileService.editSkill_Lang_InUI(this.skill_lang).subscribe(a => {
      this.toastrService.success('saved your changes successfuly', 'success');
     },
      error => { },
      () => this.loadEmployeeData()
    );
  }

  updateLinks() {
    this.links = [
      new EmployeeLink("facebook", this.facebookLink?.trim().length ? this.facebookLink?.trim() : null),
      new EmployeeLink("github", this.githubLink?.trim().length ? this.githubLink?.trim() : null),
      new EmployeeLink("twitter", this.twitterLink?.trim().length ? this.twitterLink?.trim() : null),
      new EmployeeLink("linkedin", this.linkedInLink?.trim().length ? this.linkedInLink?.trim() : null),
    ];

    this.userProfileService.updateEmplpyeeLinks(this.links).subscribe(o => { },
      error => { },
      () => this.loadEmployeeData()
    );
  }

  uploadFile(event: Event) {
    const target = event.target as HTMLInputElement;
    const files = target.files as FileList;

    if (files.length === 0) {
      return;
    }
    this.profile.photo = null;
    let fileToUpload: File = files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.uploadFilesService.uploadEmployeeImage(formData).subscribe(e => {
      if (e.type === HttpEventType.Response) {
        console.log('fileUploaded');
        this.toastrService.success('saved your changes successfuly', 'success');
      }
    },
      (error) => {
        console.log(error);
      },
      () => this.loadEmployeeData()
    );
  }

  uploadCVFile(event: Event) {
    const target = event.target as HTMLInputElement;
    const files = target.files as FileList;

    if (files.length === 0) {
      return;
    }
    this.profile.cv = null;
    let fileToUpload: File = files[0];
    const formData = new FormData();
    formData.append('Cv', fileToUpload, fileToUpload.name);
    this.uploadFilesService.uploadEmployeeCV(formData).subscribe(e => {
      if (e.type === HttpEventType.Response) {
        console.log('fileUploaded');
        this.toastrService.success('saved your changes successfuly', 'success');
      }
    },
      (error) => {
        console.log(error);
      },
      () => this.loadEmployeeData()
    );
  }
}
