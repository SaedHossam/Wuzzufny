import { Component, OnInit } from '@angular/core';
import { ErrorHandlerService } from '../../../../shared/services/error-handler.service';
import { CompanyProfileDto } from '../../models/company-profile-dto';
import { DisplayCompanyProfileService } from '../../services/display-company-profile.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  public errorMessage: string = '';
  public website: string;
  public email: string;
  public emailLink: string;
  public facebook: string;
  public linkedin: string;

  constructor(private displayProfileService: DisplayCompanyProfileService, private ac: ActivatedRoute) {
  }
  company: CompanyProfileDto;
  isLoading: boolean;
  ngOnInit(): void {

    this.ac.params.subscribe(p => {
      if (p.id === undefined) {
        this.isLoading = true;
        this.displayProfileService.getCompanyProfile().subscribe(a => {
          this.company = a;
          this.facebook = this.toAbsoluteLink(this.company.companyLinks.find(l => l.name == "facebook")?.link);
          this.email = this.company.companyLinks.find(l => l.name == "email")?.link;
          this.website = this.toAbsoluteLink(this.company.companyLinks.find(l => l.name == "website")?.link);
          this.linkedin = this.toAbsoluteLink(this.company.companyLinks.find(l => l.name == "linkedin")?.link);
          this.isLoading = false;

          if (this.email != null) {
            this.emailLink = "mailto:" + this.email;
          }
        });
      } else {
        this.isLoading = true;
        this.displayProfileService.getCompanyProfileById(p.id).subscribe(a => {
          this.company = a;
          this.facebook = this.toAbsoluteLink(this.company.companyLinks.find(l => l.name == "facebook")?.link);
          this.email = this.company.companyLinks.find(l => l.name == "email")?.link;
          this.website = this.toAbsoluteLink(this.company.companyLinks.find(l => l.name == "website")?.link);
          this.linkedin = this.toAbsoluteLink(this.company.companyLinks.find(l => l.name == "linkedin")?.link);
          this.isLoading = false;

          if (this.email != null) {
            this.emailLink = "mailto:" + this.email;
          }
        });


      }

    })























  }

  toAbsoluteLink(link: string) {
    if (link == null || link.length == 0) {
      return '';
    }

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
