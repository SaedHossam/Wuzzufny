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
  loc: string;
  constructor(public service: JobService) { }

  ngOnInit(): void {
    this.service.getJobs().subscribe(a => {
      this.jobs = a;   
    })
  }

  

  public printDateOnly(date: Date) {

    date = new Date(date);

    const dayNames = new Array('Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday');
    const monthNames = new Array('January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December');

    const dayOfWeek = date.getDay();
    const dayOfMonth = date.getDate();
    let sup = '';
    const month = date.getMonth();
    const year = date.getFullYear();

    if (dayOfMonth === 1 || dayOfMonth === 21 || dayOfMonth === 31) {
      sup = 'st';
    } else if (dayOfMonth === 2 || dayOfMonth === 22) {
      sup = 'nd';
    } else if (dayOfMonth === 3 || dayOfMonth === 23) {
      sup = 'rd';
    } else {
      sup = 'th';
    }

    const dateString = dayNames[dayOfWeek] + ', ' + dayOfMonth + sup + ' ' + monthNames[month] + ' ' + year;

    return dateString;
  }
  getPrintedDate(value: Date) {
    if (value) {
      return this.printDateOnly(value);
    }
  }

  returnOpenJobsOnly(check: boolean) {
    return check == true ? "Open" : "CLOSED";
  }


  searchAJob() {
    this.service.searchForAJob(this.jobTitle, this.loc).subscribe(a => {
      this.jobs = a;
      console.log(this.jobs);
    }
    ) 
  }

}
