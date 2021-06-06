import { HttpClient, HttpClientModule, HttpClientXsrfModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SeedAngular } from '../../models/seed-angular';
import { CustomFormsModule } from 'ng2-validation'
import { FormControl, Validators, FormGroup, FormBuilder, RequiredValidator, FormArray } from '@angular/forms';
import { EnvironmentUrlService } from 'src/app/shared/services/environment-url.service';


@Component({
  selector: 'app-post-job',
  templateUrl: './post-job.component.html',
  styleUrls: ['./post-job.component.css']
})

export class PostJobComponent implements OnInit {
  DB: SeedAngular;
  employeeform: FormGroup;
 public  postjobform:FormGroup;
  constructor(private http: HttpClient ,private _envUrl:EnvironmentUrlService) { }
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
      'skills':new FormArray(null,[Validators.required])

    });
    this.http.get<SeedAngular>(this._envUrl.urlAddress+"/api/jobs/SeedAngular").subscribe(a=>{
      this.DB = a;
    })
    
  
  }
public postjob=(postjobform)=>{
  console.log(postjobform)
  }

}
