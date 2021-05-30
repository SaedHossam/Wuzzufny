import { JobDetails } from './job-details';
import { Skills } from './skills';

export class Job {
  constructor(id?: number, title?: string, employmentType?: string, numberOfVacancies?: number, location?: string,
    totalClicks?: number,/* acceptedApplications?: number, rejectedApplications?: number,*/ viewedApplications?: number, withdrawnApplications?: number,
    createdBy?: string, updatedBy?: string, createdDate?: Date, updatedDate?: Date, jobDetails?: JobDetails, skills?: Skills) {

    this.id = id;
    this.title = title;
    this.employmentType = employmentType;
    this.numberOfVacancies = numberOfVacancies;
    this.location = location;
    //this.totalApplications = totalApplications;
    this.totalClicks = totalClicks;
    //this.acceptedApplications = acceptedApplications;
    //this.rejectedApplications = rejectedApplications;
    this.viewedApplications = viewedApplications;
    this.withdrawnApplications = withdrawnApplications;
    this.createdBy = createdBy;
    this.updatedBy = updatedBy;
    this.createdDate = createdDate;
    this.updatedDate = updatedDate;
    this.jobDetails = jobDetails;
    this.skills = skills;
  }


  public id: number;
  public title: string;
  public employmentType: string;
  public numberOfVacancies: number;
  public location: string;
  //public totalApplications: number;
  public totalClicks: number;
  //public acceptedApplications: number;
  //public rejectedApplications: number;
  public viewedApplications: number;
  public withdrawnApplications: number;
  public createdBy: string;
  public updatedBy: string;
  public createdDate: Date;
  public updatedDate: Date;
  public jobDetails: JobDetails;
  public skills: Skills;

}
