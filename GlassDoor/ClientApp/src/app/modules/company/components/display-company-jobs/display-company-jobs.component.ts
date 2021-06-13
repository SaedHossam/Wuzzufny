import { join } from '@angular/compiler-cli/src/ngtsc/file_system';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Job } from 'src/app/models/job';
import { PostJobDto } from '../../models/post-job-dto';
import { DiplayCompanyJobsService } from '../../services/diplay-company-jobs.service';

@Component({
  selector: 'app-display-company-jobs',
  templateUrl: './display-company-jobs.component.html',
  styleUrls: ['./display-company-jobs.component.css']
})
export class DisplayCompanyJobsComponent implements OnInit {
  companyJobs:Job[]=[] ;

  constructor(private companyJobService:DiplayCompanyJobsService, public _router:Router) { }

  ngOnInit(): void {
    this.companyJobService.getCompanyjobs().subscribe(a => {
      this.companyJobs = a;
      console.log(this.companyJobs);

              })
 
  }
  editJobData(job){
    this._router.navigate(['/company/editJob/'],{state:{job:job}});

  }
}