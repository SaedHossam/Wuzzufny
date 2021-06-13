import { ApplicationDto } from './../../models/application-dto';
import { Component, OnInit } from '@angular/core';
import { ApplicationService } from '../../services/application.service';

@Component({
  selector: 'app-job-applications',
  templateUrl: './job-applications.component.html',
  styleUrls: ['./job-applications.component.css']
})
export class JobApplicationsComponent implements OnInit {
  jobId:number = 1;
  applications:ApplicationDto[];

  constructor(private _applicationService:ApplicationService) { }

  setApplication(application:ApplicationDto){
    this._applicationService.setApplication(application);
  }

  ngOnInit(): void {
    this._applicationService.getAllJobApplications(this.jobId).subscribe(a=>{
      console.log(a);
      this.applications = a;
    })
  }
  
}
