import { HttpClient, HttpClientModule, HttpClientXsrfModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SeedAngular } from '../../models/seed-angular';
import { CustomFormsModule } from 'ng2-validation'
import { FormControl, Validators, FormGroup, FormBuilder, RequiredValidator, FormArray } from '@angular/forms';
import { EnvironmentUrlService } from 'src/app/shared/services/environment-url.service';
import { Skills } from '../../models/skills';
import { PostJobDto } from '../../models/post-job-dto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-post-job',
  templateUrl: './post-job.component.html',
  styleUrls: ['./post-job.component.css']
})

export class PostJobComponent implements OnInit {
  DB: SeedAngular;
  postJobDto:PostJobDto ={
    title: null ,
    jobTypeId: null ,
    cityId: null ,
    countryId: null ,
    numberOfVacancies: null ,
    
    jobDetails: {
      experienceNeededMin: null ,
      experienceNeededMax:null ,
      careerLevelId: null ,
      educationLevelId: null ,
      salaryMin: null ,
      salaryMax: null ,
      salaryCurrencyId: null ,
      salaryRateId: null ,
      jobCategoryId: null ,
      description: null ,
      requirements: null ,
      responsibilities:null ,
    },
        skills:null
  }
  
  employeeform: FormGroup;
 public  postjobform:FormGroup;
  constructor(private http: HttpClient, private _envUrl: EnvironmentUrlService, private _router: Router) { }
 public results: Skills[];
  ngOnInit(): void {
   this.postjobform =new FormGroup({
      'title':new FormControl(null,[Validators.required]),
      'jobTypeId':new FormControl(null,[Validators.required]),
      'countryId':new FormControl(null,[Validators.required]),
      'cityId':new FormControl(null,[Validators.required]),
      'numberOfVacancies':new FormControl(null,[Validators.required]),
      'experienceNeededMin':new FormControl(null,[Validators.required]),
      'experienceNeededMax':new FormControl(null,[Validators.required]),
      'careerLevelId':new FormControl(null,[Validators.required]),
      'educationLevelId':new FormControl(null,[Validators.required]),
      'salaryMin':new FormControl(null),
      'salaryMax':new FormControl(null),
      'salaryCurrencyId':new FormControl(null,[Validators.required]),
      'salaryRateId':new FormControl(null,[Validators.required]),
      'jobCategoryId':new FormControl(null,[Validators.required]),
      'description':new FormControl(null,[Validators.required]),
      'requirements':new FormControl(null,[Validators.required]),
      'responsibilities':new FormControl(null,[Validators.required]),
      'skills':new FormControl(null,[Validators.required])

    });
    this.http.get<SeedAngular>(this._envUrl.urlAddress+"/api/jobs/SeedAngular").subscribe(a=>{
      this.DB = a;
    })
    

    
  }


  // search(event) {
    
  //   this.http.get<SeedAngular>(this._envUrl.urlAddress+"/api/jobs/SeedAngular").subscribe(a=>{
  //     this.results = a.skills; 
  // })}
  search(event) {   
    this.results = this.DB.skills.filter(c => c.name.startsWith(event.query));
}


public postjob(postjobform){
  console.log(this.postjobform.value)

this.postJobDto.title=postjobform.value.title;
this.postJobDto.cityId=postjobform.value.cityId;
this.postJobDto.jobTypeId=postjobform.value.jobTypeId;
this.postJobDto.countryId=postjobform.value.countryId;
this.postJobDto.numberOfVacancies=postjobform.value.numberOfVacancies;
this.postJobDto.jobDetails.experienceNeededMin=postjobform.value.experienceNeededMin;
this.postJobDto.jobDetails.experienceNeededMax=postjobform.value.experienceNeededMax;
this.postJobDto.jobDetails.careerLevelId=postjobform.value.careerLevelId;
this.postJobDto.jobDetails.educationLevelId=postjobform.value.educationLevelId;
this.postJobDto.jobDetails.salaryMin=postjobform.value.salaryMin;
this.postJobDto.jobDetails.salaryMax=postjobform.value.salaryMax;
this.postJobDto.jobDetails.salaryCurrencyId=postjobform.value.salaryCurrencyId;
this.postJobDto.jobDetails.salaryRateId=postjobform.value.salaryRateId;
this.postJobDto.jobDetails.jobCategoryId=postjobform.value.jobCategoryId;
this.postJobDto.jobDetails.description=postjobform.value.description;
this.postJobDto.jobDetails.requirements=postjobform.value.requirements;
this.postJobDto.jobDetails.responsibilities=postjobform.value.responsibilities;
  this.postJobDto.skills = postjobform.value.skills.map(function (val, index) {
    return { SkillsId: val.id};
  });
  console.log(this.postJobDto.skills);

  this.http.post(this._envUrl.urlAddress+"/api/jobs",this.postJobDto).subscribe(a=>{
    this._router.navigate(['/company/']);
  })

  }

  // search($event){
  //   this.http.get<SeedAngular>(this._envUrl.urlAddress+"/api/jobs/SeedAngular").subscribe(a=>{
  //     this.results = a.skills})
  // }

  }  
  

