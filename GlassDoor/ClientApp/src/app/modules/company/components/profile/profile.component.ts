import { Component, OnInit } from '@angular/core';
import { ErrorHandlerService } from '../../../../shared/services/error-handler.service';
import { CompanyProfileDto } from '../../models/company-profile-dto';
import { DisplayCompanyProfileService } from '../../services/display-company-profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  public errorMessage: string = '';
  public website: string;
  public email: string;
  public facebook: string;
  public linkedin: string;
  constructor(private displayProfileService: DisplayCompanyProfileService, private errorHandler: ErrorHandlerService) { }
  company: CompanyProfileDto;
  isLoading: boolean;
  ngOnInit(): void {
    this.isLoading = true;
    this.displayProfileService.getCompanyProfile().subscribe(a => {
      this.company = a;
      this.facebook = this.company.companyLinks.find(l => l.name == "facebook")?.link;
      this.email = this.company.companyLinks.find(l => l.name == "email")?.link;
      this.website = this.company.companyLinks.find(l => l.name == "website")?.link;
      this.linkedin = this.company.companyLinks.find(l => l.name == "linkedin")?.link;
      this.isLoading = false;
    }
    );
  }

}
