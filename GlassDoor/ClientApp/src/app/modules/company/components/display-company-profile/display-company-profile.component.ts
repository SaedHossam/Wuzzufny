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
  companyprofile: CompanyProfileDto={
    "id":1,
    "name":"Mycompany",
    "logo":"dfd",
    "aboutUs":"we are here",
    "YearFounded":new Date("2016-01-17T08:44:29+0100"),
    "phone":1001982,
    "CompanyTypeId":1,
    "companyIndustryId":1,
    "companyIndustry":"field",
    "companyType":"high level",
    "cities":[],
    "companyLinks":{
       id:1,
       name:"facebook",
      link:"hello.com"
    }
  };

  ngOnInit(): void {
    this.displayProfileService.getCompanyProfile().subscribe(a => {
      this.companyprofile = a;
      console.log(this.companyprofile);
    })
  }

}
