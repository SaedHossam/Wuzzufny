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
import { EditCompanyProfileDto } from '../../models/edit-company-profile-dto';
import { FileUpload } from 'primeng/fileupload';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { UploadFilesService } from "../../../../shared/services/upload-files.service";

@Component({
  selector: 'app-company-profile-edit',
  templateUrl: './company-profile-edit.component.html',
  styleUrls: ['./company-profile-edit.component.css'],
})
export class CompanyProfileEditComponent implements OnInit {
  companyProfile: CompanyProfile;
  countries: Country[];
  cities: City[] = [];
  companyTypes: CompanyType[];
  companySizes: CompanySize[];
  companyIndustries: Industry[];
  companyLinks: CompanyLinksDto[];
  facebookLink: CompanyLinksDto;
  linkedinLink: CompanyLinksDto;
  website: CompanyLinksDto;
  email: CompanyLinksDto;

  public editProfileForm: FormGroup;
  maxYearRange: number = new Date().getFullYear();
  dateNow: Date = new Date();
  public progress: number;
  public message: string;

  constructor(
    private displayProfileService: DisplayCompanyProfileService,
    private _countryService: CountryService,
    private _cityService: CityService,
    private _companySize: CompanySizeService,
    private _companyType: CompanyTypeService,
    private _companyIndustry: CompanyIndustryService,
    private _editProfileService: DisplayCompanyProfileService,
    public _http: HttpClient,
    private toastr: ToastrService,
    private uploadFilesService: UploadFilesService

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
      'websiteLink': new FormControl(null, [Validators.required]),
      'email': new FormControl(null, [Validators.required]),
      'companySize': new FormControl(null, [Validators.required]),
      'companyType': new FormControl(null, [Validators.required]),
      'locations': new FormControl(null, [Validators.required]),
    });

    this._countryService.getCountries().subscribe((data) => {
      this.countries = data;
    });
    this._cityService.getCities().subscribe((data) => {
      this.cities = data;
    });

    this.displayProfileService.getCompanyProfileEdit().subscribe((data) => {
      this.companyProfile = data;
      this.companyLinks = this.companyProfile.companyLinks;

      this.facebookLink = this.companyLinks?.find(l => l.name == "facebook");
      this.linkedinLink = this.companyLinks?.find(l => l.name == "linkedin");
      this.website = this.companyLinks?.find(l => l.name == "website");
      this.email = this.companyLinks?.find(l => l.name == "email");


      // console.log(this.companyProfile);
      this.editProfileForm.get('aboutUs').setValue(this.companyProfile.aboutUs);
      this.editProfileForm.get('name').setValue(this.companyProfile.name);
      this.editProfileForm.get('phone').setValue(this.companyProfile.phone);
      this.editProfileForm.get('yearFounded').setValue(new Date(this.companyProfile.yearFounded));
      this.editProfileForm.get('companyIndustry').setValue(this.companyProfile.companyIndustry.id);
      this.facebookLink == null ? this.facebookLink = { link: " ", name: "facebook" } : this.editProfileForm.get('facebookLink').setValue(this.companyLinks?.find(l => l.name == "facebook").link);
      this.linkedinLink == null ? this.linkedinLink = { link: " ", name: "linkedin" } : this.editProfileForm.get('linkedinLink').setValue(this.companyLinks?.find(l => l.name == "linkedin").link);
      this.website == null ? this.linkedinLink = { link: " ", name: "website" } : this.editProfileForm.get('websiteLink').setValue(this.companyLinks?.find(l => l.name == "website").link);
      this.email == null ? this.linkedinLink = { link: " ", name: "email" } : this.editProfileForm.get('email').setValue(this.companyLinks?.find(l => l.name == "email").link);

      this.editProfileForm.get('companySize').setValue(this.companyProfile.companySize.id);
      this.editProfileForm.get('companyType').setValue(this.companyProfile.companyType.id);

      this.editProfileForm.get('locations').setValue(this.companyProfile.locations.map((val, index) => ({ countryId: val.cities.countryId, id: val.cities.id, name: val.cities.name })));
      //console.log(this.companyProfile);
    });


    this._companySize.getCompanySizes().subscribe((data) => {
      this.companySizes = data;
    });
    this._companyType.getCompanyTypes().subscribe((data) => {
      this.companyTypes = data;
    });
    this._companyIndustry.getIndustries().subscribe((data) => {
      this.companyIndustries = data;
    });
  }

  public uploadFile = (event) => {
    if (event.target.files.Length == 0) {
      return;
    }
    let fileToUpload = event.target.files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.uploadFilesService.uploadCompanyLogo(formData).subscribe(e => {
      if (e.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * e.loaded / e.total);
      else if (e.type === HttpEventType.Response) {
        this.toastr.success('your photo is uploaded successfully ', 'uploaded');
        this.companyProfile.logo = null;
        setTimeout(() => {
          this.companyProfile.logo = e.body['dbPath'];
        }, 100);
      }
    })
  }

  editProfile(editForm) {
    var links: CompanyLinksDto[] = [
      { link: editForm.value.facebookLink, id: this.facebookLink.id, name: "facebook" },
      { link: editForm.value.linkedinLink, id: this.linkedinLink.id, name: "linkedin" },
      { link: editForm.value.websiteLink, id: this.website.id, name: "website" },
      { link: editForm.value.email, id: this.email.id, name: "email" }
    ]
    var companyProfileEdit: EditCompanyProfileDto = {
      id: this.companyProfile.id,
      name: editForm.value.name,
      logo: editForm.value.logo,
      aboutUs: editForm.value.aboutUs,
      yearFounded: editForm.value.yearFounded,
      phone: editForm.value.phone,
      companyIndustryId: editForm.value.companyIndustry,
      companyTypeId: editForm.value.companyType,
      companySizeId: editForm.value.companySize,
      locations: editForm.value.locations.map((val, index) => ({ cityId: val.id, companyId: this.companyProfile.id })),
      companyLinks: links,
      requestStatusId: this.companyProfile.requestStatusId
    }
    //console.log(companyProfileEdit);
    this._editProfileService.putCompanyProfile(companyProfileEdit).subscribe(response => {
      this.toastr.success('saved your changes', 'saved');
    })
  }
}
