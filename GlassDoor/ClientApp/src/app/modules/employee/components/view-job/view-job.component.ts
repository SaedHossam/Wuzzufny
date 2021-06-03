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

  totalLength: any;//paging
  page: number = 1;//paging


  // searching
  title: any;

  constructor(public service: JobService) { }

  ngOnInit(): void {
    this.service.getJobs().subscribe(a => {
      this.jobs = a;
      this.totalLength = a.length;// paging
      console.log(this.totalLength);
    })

  }

  // Search start region
  Search() {
    if (this.title == "") {
      this.ngOnInit();
    }
    else {
      this.jobs = this.jobs.filter(res => {
        return res.title.toLocaleLowerCase().match(this.title.toLocaleLowerCase());
      });
    }


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

  getNameFromJson(value: string) {
    return JSON.parse(value);
  }


  getStringFromEnum(value: number) {
    switch (value) {
      case 0:
        return "FullTime";
      case 1:
        return "PartTime";
      case 2:
        return "FreeLance";
      case 3:
        return "Internship";
    }
  }

}
