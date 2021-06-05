import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { Job } from '../../../../models/job';
import { JobDetails } from '../../../../models/job-details';
import { JobService } from '../../../../shared/services/job.service';


@Component({
  selector: 'app-apply-job',
  templateUrl: './apply-job.component.html',
  styleUrls: ['./apply-job.component.css']
})
export class ApplyJobComponent implements OnInit {

  constructor(private service: JobService, private ac: ActivatedRoute,
    private primengConfig: PrimeNGConfig) { }
  jobD: JobDetails = new JobDetails();

  //salaryCurrency: string;
  //carrerLevel: string;
  //experienceNedded: number;
  //salary: number;
  //category: string;
  //subCategory: string;
  //description: string;
  //requirements: string;
  //responsibilities: string;
  //educationLevel: string;
  //status: string;
  //skills: string[] = [];

  ngOnInit(): void {
    this.primengConfig.ripple = true;
    this.ac.params.subscribe(p => {
      this.service.getjobdbyid(p.id).subscribe(a => {
        this.jobD = a;

        console.log(this.jobD);
        //this.carrerLevel = this.jobD.jobDetails.carrerLevel;
        //this.experienceNedded = this.jobD.jobDetails.experienceNedded;
        //this.category = this.jobD.jobDetails.category;
        //this.subCategory = this.jobD.jobDetails.subCategory;
        //this.description = this.jobD.jobDetails.description;
        //this.requirements = this.jobD.jobDetails.requirements;
        //this.educationLevel = this.jobD.jobDetails.educationLevel;
        //this.status = this.jobD.jobDetails.status;
        //this.salary = this.jobD.jobDetails.salary;
        //this.responsibilities = this.jobD.jobDetails.responsibilities;
        //this.skills = this.jobD.skills;
        
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
       
