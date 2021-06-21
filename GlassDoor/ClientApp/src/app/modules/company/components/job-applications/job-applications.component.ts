import { ApplicationDto } from './../../models/application-dto';
import { Component, OnInit } from '@angular/core';
import { ApplicationService } from '../../services/application.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-job-applications',
  templateUrl: './job-applications.component.html',
  styleUrls: ['./job-applications.component.css'],
})
export class JobApplicationsComponent implements OnInit {
  applications: ApplicationDto[];

  constructor(
    private _applicationService: ApplicationService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this._route.params.subscribe((p) => {
      this._applicationService.getAllJobApplications(p.id, p.status).subscribe((a) => {
        console.log(a);
        this.applications = a;
      });
    });
  }

  public ageFromDateOfBirthday(dateOfBirth: any): number {
    const today = new Date();
    const birthDate = new Date(dateOfBirth);
    let age = today.getFullYear() - birthDate.getFullYear();
    const m = today.getMonth() - birthDate.getMonth();

    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }

    return age;
  }
  
}
