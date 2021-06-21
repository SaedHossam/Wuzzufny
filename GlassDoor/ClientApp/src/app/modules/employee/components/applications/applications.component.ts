import { Component, OnInit } from '@angular/core';
import { Application } from '../../../../models/application';
import { ApplicationService } from '../../../../shared/services/application.service';

@Component({
  selector: 'app-applications',
  templateUrl: './applications.component.html',
  styleUrls: ['./applications.component.css']
})
export class ApplicationsComponent implements OnInit {

  constructor(public applicationService: ApplicationService) { }
  applications: Application[];
  ngOnInit(): void {
    this.applicationService.getApplications().subscribe(a => {
      console.log(a);
      this.applications = a;
    })
  }

  withdrawApplication(applicationId: number) {
    this.applicationService.withdrawApplication(applicationId).subscribe(a => {
      this.ngOnInit();
    });
  }

  archiveApplication(applicationId: number) {
    this.applicationService.archiveApplication(applicationId).subscribe(a => {
      this.ngOnInit();
    });
  }
}
