import { Component, OnInit } from '@angular/core';
import { Job } from '../../../../models/job';
import { JobService } from '../../../../shared/services/job.service';

@Component({
  selector: 'app-view-job',
  templateUrl: './view-job.component.html',
  styleUrls: ['./view-job.component.css']
})
export class ViewJobComponent implements OnInit {

  jobs: Job[] = [];
  jobTitle: string;
  isLoading: boolean;

  constructor(public service: JobService) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.service.getJobs().subscribe(a => {
      this.jobs = a;
      this.isLoading = false;
    });
  }

  searchAJob() {
    this.service.searchForAJob(this.jobTitle, "e").subscribe(j => {
      this.jobs = j;
    });
  }
}
