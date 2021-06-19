import { CompanyLinksDto } from './../../models/company-links-dto';
import { Industry } from './../../../../interfaces/shared/industry.model';
import { CompanyIndustryService } from './../../../../shared/services/company-industry.service';
import { CompanyTypeService } from './../../../../shared/services/company-type.service';
import { CompanySizeService } from './../../../../shared/services/company-size.service';
import { CompanySize } from './../../../../models/company-size';
import { CompanyType } from './../../../../models/company-type';
import { Component, OnInit } from '@angular/core';
import { DisplayCompanyProfileService } from '../../services/display-company-profile.service';
import { CompanyProfile } from '../../models/company-profile';
import { CityService } from 'src/app/shared/services/city.service';
import { CountryService } from 'src/app/shared/services/country.service';
import { City } from '../../models/city';
import { Country } from 'src/app/models/country';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CompanyLinks } from 'src/app/models/company-links';

@Component({
  selector: 'app-company-profile-edit',
  templateUrl: './company-profile-edit.component.html',
  styleUrls: ['./company-profile-edit.component.css'],
})
export class CompanyProfileEditComponent implements OnInit {
  companyProfile: CompanyProfile;
  countries: Country[];
  cities: City[];
  companyTypes: CompanyType[];
  companySizes: CompanySize[];
  companyIndustries: Industry[];
  companyLinks: CompanyLinksDto[];
  facebookLink: CompanyLinksDto;
  linkedinLink: CompanyLinksDto;
  public editProfileForm: FormGroup;
  maxYearRange: number = new Date().getFullYear();
  dateNow: Date = new Date();
  constructor(
    private displayProfileService: DisplayCompanyProfileService,
    private _countryService: CountryService,
    private _cityService: CityService,
    private _companySize: CompanySizeService,
    private _companyType: CompanyTypeService,
    private _companyIndustry: CompanyIndustryService,
    private _editProfileService:DisplayCompanyProfileService,

  ) { }

  ngOnInit(): void {


    this.editProfileForm = new FormGroup({
      'aboutUs': new FormControl(null, [Validators.required]),
      'name': new FormControl(null, [Validators.required]),
      'logo': new FormControl(null, [Validators.required]),
      'phone': new FormControl(null, [Validators.required]),
      'yearFounded': new FormControl(null, [Validators.required]),
      'companyIndustry': new FormControl(null, [Validators.required]),
      // 'companyLinks': new FormControl(null, [Validators.required]),
      'facebookLink': new FormControl(null, [Validators.required]),
      'linkedinLink': new FormControl(null, [Validators.required]),
      'companySize': new FormControl(null, [Validators.required]),
      'companyType': new FormControl(null, [Validators.required]),
      'locations': new FormControl(null, [Validators.required]),
    });

    this._countryService.getCountries().subscribe((data) => {
      this.countries = data;
      console.log(this.countries);
    });
    this._cityService.getCities().subscribe((data) => {
      this.cities = data;
      console.log(this.cities);
    });

    this.displayProfileService.getCompanyProfileEdit().subscribe((data) => {
      this.companyProfile = data;
      this.companyLinks = this.companyProfile.companyLinks;

      this.facebookLink = this.companyLinks?.find(l => l.name == "facebook");
      this.linkedinLink = this.companyLinks?.find(l => l.name == "linkedin");


      // console.log(this.companyProfile);
      this.editProfileForm.get('aboutUs').setValue(this.companyProfile.aboutUs);
      this.editProfileForm.get('name').setValue(this.companyProfile.name);
      this.editProfileForm.get('logo').setValue(this.companyProfile.logo);
      this.editProfileForm.get('phone').setValue(this.companyProfile.phone);
      this.editProfileForm.get('yearFounded').setValue(new Date(this.companyProfile.yearFounded));
      this.editProfileForm.get('companyIndustry').setValue(this.companyProfile.companyIndustry.id);
      // this.editProfileForm.get('companyLinks').setValue(this.companyProfile.companyLinks.link);
      this.facebookLink == null ? this.facebookLink = { link: " ", name: "facebook" } : this.editProfileForm.get('facebookLink').setValue(this.companyLinks?.find(l => l.name == "facebook").link);
      this.linkedinLink == null ? this.linkedinLink = { link: " ", name: "linkedin" } : this.editProfileForm.get('linkedinLink').setValue(this.companyLinks?.find(l => l.name == "linkedin").link);

      console.log(this.facebookLink)
      this.editProfileForm.get('companySize').setValue(this.companyProfile.companySize.id);
      this.editProfileForm.get('companyType').setValue(this.companyProfile.companyType.id);
      this.editProfileForm.get('locations').setValue(this.companyProfile.locations);
      console.log(this.companyProfile);
    });


    this._companySize.getCompanySizes().subscribe((data) => {
      this.companySizes = data;
      console.log(this.companySizes);
    });
    this._companyType.getCompanyTypes().subscribe((data) => {
      this.companyTypes = data;
      console.log(this.companyTypes);
    });
    this._companyIndustry.getIndustries().subscribe((data) => {
      this.companyIndustries = data;
      console.log(this.companyIndustries);
    });

  }
  editProfile(editForm) {

    var links:CompanyLinksDto[] = [{link: editForm.value.facebookLink, id:this.facebookLink.id , name:"facebook"} ,{link: editForm.value.linkedinLink,id:this.linkedinLink.id , name:"linkedin" }]
    var companyProfileEdit: CompanyProfile ={
     id: this.companyProfile.id ,
     name :editForm.value.name ,
     logo:editForm.value.logo ,
     aboutUs:editForm.value.aboutUs ,
     yearFounded:editForm.value.yearFounded ,
     phone:editForm.value.phone ,
     companyIndustry:editForm.value.companyIndustry ,
     companyType:editForm.value.companyType ,
     companySize:editForm.value.companySize ,
     locations:editForm.value.locations ,
     companyLinks:links ,
    requestStatusId:this.companyProfile.requestStatusId
    }
    console.log(companyProfileEdit);
    this._editProfileService.putCompanyProfile(companyProfileEdit).subscribe(response=>{
       console.log(response);
    })
  }
}
