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
  openApplications: Application[];
  archivedApplications: Application[];
  ngOnInit(): void {
    this.applicationService.getApplications().subscribe(a => {
      console.log(a);
      this.applications = a;
      this.openApplications = a.filter(a => a.isArchived == false);
      console.log(this.openApplications);
      this.archivedApplications = a.filter(a => a.isArchived == true);
      console.log(this.archivedApplications);
    })
  }

  withdrawApplication(applicationId: number) {
    this.applicationService.withdrawApplication(applicationId).subscribe(a => {
      this.ngOnInit();
    });
  }

  archiveApplication(applicationId: number, archive: boolean) {
    this.applicationService.archiveApplication(applicationId, archive).subscribe(a => {
      this.ngOnInit();
    });
  }
}
