import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Company } from 'src/app/models/company';
import { CompanyProfileDto } from '../../models/company-profile-dto';
import { DisplayCompanyProfileService } from '../../services/display-company-profile.service';

@Component({
  selector: 'app-display-company-profile',
  templateUrl: './display-company-profile.component.html',
  styleUrls: ['./display-company-profile.component.css']
})
export class DisplayCompanyProfileComponent implements OnInit {

  constructor(private displayProfileService: DisplayCompanyProfileService) { }
  companyprofile: CompanyProfileDto;

  ngOnInit(): void {
    this.displayProfileService.getCompanyProfile().subscribe(a => {
      this.companyprofile = a;

    })
  }

}
