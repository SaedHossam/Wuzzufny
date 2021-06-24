import { ApplicationDto } from './../../models/application-dto';
import { Application } from './../../../../models/application';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApplicationService } from '../../services/application.service';
import { ToastrService } from 'ngx-toastr';
import { error } from '@angular/compiler/src/util';
import { EditApplicationStatusDto } from "../../models/edit-application-status-dto";
import { UserProfileService } from '../../../../shared/services/user-profile.service';
import { Employee } from '../../../../models/employee';

interface status {
  status: string
}

@Component({
  selector: 'app-application-status',
  templateUrl: './application-status.component.html',
  styleUrls: ['./application-status.component.css']
})
export class ApplicationStatusComponent implements OnInit {
  application: ApplicationDto;

  statuses: status[];
  selectedStatus: string;

  constructor(private _applicationService: ApplicationService, private service: UserProfileService, private _route: ActivatedRoute, private toastr: ToastrService) {
    this.statuses = [
      { status: "In Consideration" },
      { status: "Accepted" },
      { status: "Rejected" },
      { status: "Viewed" }
    ]
  }

  profile: Employee = new Employee();
  linkedInLink: string;
  facebookLink: string
  twitterLink: string;
  githubLink: string;

  ngOnInit(): void {
    this._route.params.subscribe(p => {
      this._applicationService.getJobApplication(p.id).subscribe(app => {
        // this.application=app;
        this.selectedStatus = app.status;
        this.application = app;

        this.service.getEmpById(app.employeeId).subscribe(a => {
          this.profile = a;
          a.employeeLinksNames.forEach((link, index, array) => array[index].link = this.toAbsoluteLink(link.link));

          this.linkedInLink = a.employeeLinksNames.find(link => link.name == "linkedin")?.link;
          this.facebookLink = a.employeeLinksNames.find(link => link.name == "facebook")?.link;
          this.githubLink = a.employeeLinksNames.find(link => link.name == "github")?.link;
          this.twitterLink = a.employeeLinksNames.find(link => link.name == "twitter")?.link;

          console.log(a);
          console.log(this.profile);
        });

      })
    })
  }

  editStatus(status: string) {
    const statusDto: EditApplicationStatusDto = { id: this.application.id, status: status };
    this._applicationService.editStatus(statusDto).subscribe(a => {
      this.toastr.success(`Status Changed successfully`, 'Success');

    }, error => console.log(error))
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

  toAbsoluteLink(link: string) {
    var result;
    var startingUrl = "http://";
    var httpsStartingUrl = "https://";
    if (this.startWith(link, startingUrl) || this.startWith(link, httpsStartingUrl)) {
      result = link;
    }
    else {
      result = startingUrl + link;
    }
    return result;
  }

  startWith(string: string, subString: string) {
    return string.indexOf(subString) == 0;
  };

  public printGender(value: number) {
    return value == 0 ? "Male" : "Female"
  }

  public printMilitaryStatus(value: number) {
    if (value == 0)
      return "Not applicable";
    else if (value == 1)
      return "Exempted";
    else if (value == 2)
      return "Completed";
    else
      return "Postponed";
  }

  public willingToRelocate(value: boolean) {
    return value == true ? "Yes" : "No";
  }
}
