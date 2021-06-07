import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {PrimeNGConfig } from 'primeng/api';
import { JobDetailsDto } from '../../../../models/job-details-dto';
import { JobService } from '../../../../shared/services/job.service';


@Component({
  selector: 'app-apply-job',
  templateUrl: './apply-job.component.html',
  styleUrls: ['./apply-job.component.css']
})
export class ApplyJobComponent implements OnInit {

  constructor(private service: JobService, private ac: ActivatedRoute,
    private primengConfig: PrimeNGConfig) { }
  jobD: JobDetailsDto = new JobDetailsDto();
 
 
  


  ngOnInit(): void {
    this.primengConfig.ripple = true;
    this.ac.params.subscribe(p => {
      this.service.getjobdbyid(p.id).subscribe(a => {
        this.jobD = a;
        console.log(this.jobD);
        
        /*this.countryName = this.jobD.job.country.name;*/
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

    const dateString = dayNames[dayOfWeek] + ', ' + dayOfMonth + sup + ' ' + monthNames[month] + ' ' + year;

    return dateString;
  }
  getPrintedDate(value: Date) {
    if (value) {
      return this.printDateOnly(value);
    }
  }

  /*getNameFromJson(value: string) {
    return JSON.parse(value);
  }*/


  /*getStringFromEnum(value: number) {
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
  }*/

}
       
