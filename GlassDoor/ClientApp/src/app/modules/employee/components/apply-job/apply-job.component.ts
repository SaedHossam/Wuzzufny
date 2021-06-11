import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PrimeNGConfig } from 'primeng/api';
import { JobDetailsDto } from '../../../../models/job-details-dto';
import { JobService } from '../../../../shared/services/job.service';


@Component({
  selector: 'app-apply-job',
  templateUrl: './apply-job.component.html',
  styleUrls: ['./apply-job.component.css']
})
export class ApplyJobComponent implements OnInit {
  job: JobDetailsDto = new JobDetailsDto();
  public isLoading: boolean = false;

  constructor(private service: JobService, private ac: ActivatedRoute,
    private primengConfig: PrimeNGConfig) { }

  ngOnInit(): void {
    this.primengConfig.ripple = true;
    this.isLoading = true;
    this.ac.params.subscribe(p => {
      this.service.getjobdbyid(p.id).subscribe(a => {
        this.job = a;
        this.isLoading = false;
      });
    });
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

    const dateString = dayOfMonth + sup + ' ' + monthNames[month] + ' ' + year;

    return dateString;
  }
  getPrintedDate(value: Date) {
    if (value) {
      return this.printDateOnly(value);
    }
  }
}

