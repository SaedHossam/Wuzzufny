import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '../../../../models/employee';
import { UserProfileService } from '../../../../shared/services/user-profile.service';

@Component({
  selector: 'app-employee-profile',
  templateUrl: './employee-profile.component.html',
  styleUrls: ['./employee-profile.component.css']
})
export class EmployeeProfileComponent implements OnInit {

  constructor(private service: UserProfileService, private ac: ActivatedRoute) { }

  profile: Employee = new Employee();
  linkedInLink: string;
  facebookLink: string
  twitterLink: string;
  githubLink: string;

  ngOnInit(): void {
    let isMyprofile = false;
    let id = 0;
    this.ac.pathFromRoot[this.ac.pathFromRoot.length - 1].url.subscribe(u => {
      isMyprofile = u[1].path == 'public';
      if (isMyprofile) {
        this.service.getMyProfileData().subscribe(a => {
          this.profile = a;

          a.employeeLinksNames.forEach((link, index, array) => array[index].link = this.toAbsoluteLink(link.link));

          this.linkedInLink = a.employeeLinksNames.find(link => link.name == "linkedin")?.link;
          this.facebookLink = a.employeeLinksNames.find(link => link.name == "facebook")?.link;
          this.githubLink = a.employeeLinksNames.find(link => link.name == "github")?.link;
          this.twitterLink = a.employeeLinksNames.find(link => link.name == "twitter")?.link;
        });
      }
      else {
        this.ac.params.subscribe(p => {
          this.service.getEmpById(p.id).subscribe(a => {
            this.profile = a;

            a.employeeLinksNames.forEach((link, index, array) => array[index].link = this.toAbsoluteLink(link.link));

            this.linkedInLink = a.employeeLinksNames.find(link => link.name == "linkedin")?.link;
            this.facebookLink = a.employeeLinksNames.find(link => link.name == "facebook")?.link;
            this.githubLink = a.employeeLinksNames.find(link => link.name == "github")?.link;
            this.twitterLink = a.employeeLinksNames.find(link => link.name == "twitter")?.link;
          });
        });
      }
    });

    this.service.getMyProfileData().subscribe(a => {
      this.profile = a;

      a.employeeLinksNames.forEach((link, index, array) => array[index].link = this.toAbsoluteLink(link.link));

      this.linkedInLink = a.employeeLinksNames.find(link => link.name == "linkedin")?.link;
      this.facebookLink = a.employeeLinksNames.find(link => link.name == "facebook")?.link;
      this.githubLink = a.employeeLinksNames.find(link => link.name == "github")?.link;
      this.twitterLink = a.employeeLinksNames.find(link => link.name == "twitter")?.link;
    });
  }

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

}
