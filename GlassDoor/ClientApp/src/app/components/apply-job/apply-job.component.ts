import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Job } from '../../models/job';
import { JobService } from '../../servicess/job.service';

@Component({
  selector: 'app-apply-job',
  templateUrl: './apply-job.component.html',
  styleUrls: ['./apply-job.component.css']
})
export class ApplyJobComponent implements OnInit {

  job: any = new Job();
  carrerLevel: string;
  experienceNedded: number;
  salary: number;
  category: string;
  subCategory: string;
  description: string;
  requirements: string;
  responsibilities: string;
  educationLevel: string;
  status: string;
  skills: string[] = [];



  constructor(private service: JobService, private ac: ActivatedRoute) { }

  ngOnInit(): void {
    this.ac.params.subscribe(p => {
      this.service.getJobById(p.id).subscribe(a => {
        this.job = a;
        this.carrerLevel = this.job.jobDetails.carrerLevel;
        this.experienceNedded = this.job.jobDetails.experienceNedded;
        this.category = this.job.jobDetails.category;
        this.subCategory = this.job.jobDetails.subCategory;
        this.description = this.job.jobDetails.description;
        this.requirements = this.job.jobDetails.requirements;
        this.educationLevel = this.job.jobDetails.educationLevel;
        this.status = this.job.jobDetails.status;
        this.salary = this.job.jobDetails.salary;
        this.responsibilities = this.job.jobDetails.responsibilities;
        this.skills = this.job.skills;



        console.log(this.skills);
      });
    });
  }

}
