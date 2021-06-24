import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PrimeNGConfig } from 'primeng/api';
import { Job } from '../../../../models/job';
import { DiplayCompanyJobsService } from '../../services/diplay-company-jobs.service';
import { EditJobService } from '../../services/edit-job.service';
import { ConfirmationService } from 'primeng/api';
import { Message } from 'primeng/api';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public value1: Date;
  public value2: String;
  companyJobs: Job[] = [];
  openJobs: Job[];
  closedJobs: Job[];
  msgs: Message[] = [];

  constructor(private primengConfig: PrimeNGConfig, private companyJobService: DiplayCompanyJobsService,
    private _router: Router, private _editJobServie: EditJobService, private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.primengConfig.ripple = true;
    this.companyJobService.getCompanyJobs().subscribe((a) => {

      this.companyJobs = a;
      this.openJobs = a.filter(j => j.isOpen);
      this.closedJobs = a.filter(j => !j.isOpen);
    });
  }
  closeJob(id) {
    this.confirmationService.confirm({
      message: 'Are you sure that you want to proceed?',
      header: 'Confirmation',
      icon: 'pi pi-exclamation-triangle',

      accept: () => {
        this._editJobServie.closeJob(id).subscribe((j) => {
          this.companyJobService.getCompanyJobs().subscribe((a) => {
            this.companyJobs = a;
          });
        });
      }
    });
  }
}
