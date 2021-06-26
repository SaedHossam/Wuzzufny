import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PasswordConfirmationValidatorService } from
  "../shared/custom-validators/password-confirmation-validator.service";
import { CompanyForRegistrationDto } from "../interfaces/company-register/company-for-registration-dto.model";
import { CompanyService } from "../shared/services/company.service"
import { CompanyIndustryService } from "../shared/services/company-industry.service";
import { Industry } from "../interfaces/shared/industry.model";
import { CompanySize } from "../models/company-size";
import { CompanySizeService } from "../shared/services/company-size.service";

@Component({
  selector: 'app-employer-register',
  templateUrl: './employer-register.component.html',
  styleUrls: ['./employer-register.component.css']
})
export class EmployerRegisterComponent implements OnInit {

  public registerForm: FormGroup;
  public errorMessage: string = '';
  public showError: boolean;
  public showSuccess: boolean;
  public successMessage: string;
  public industries: Industry[];
  public companySizes: CompanySize[];
  public isLoading: boolean = false;

  constructor(private _passConfValidator: PasswordConfirmationValidatorService,
    private _companyService: CompanyService, private _companyIndustryService: CompanyIndustryService, private _companySizeService: CompanySizeService) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      companyName: new FormControl('', [Validators.required]),
      companyIndustry: new FormControl('', [Validators.required]),
      companySize: new FormControl('', [Validators.required]),
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      title: new FormControl('', [Validators.required]),
      mobile: new FormControl(null, [Validators.pattern("[01][0-9]{10}")]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirm: new FormControl('')
    });

    this.registerForm.get('confirm').setValidators([Validators.required, this._passConfValidator.validateConfirmPassword(this.registerForm.get('password'))]);

    this._companyIndustryService.getIndustries().subscribe(industries => {
      this.industries = industries;
    },
      error => {
      })

    this._companySizeService.getCompanySizes().subscribe(companySizes => {
      this.companySizes = companySizes;
    },
      error => {
      })
  }

  public validateControl = (controlName: string) => {
    return this.registerForm.controls[controlName].invalid && this.registerForm.controls[controlName].touched
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.controls[controlName].hasError(errorName)
  }

  public registerCompany = (registerFormValue) => {
    this.showError = false;
    this.isLoading = true;
    const formValues = { ...registerFormValue };

    const company: CompanyForRegistrationDto = {
      name: formValues.companyName,
      companyIndustryId: formValues.companyIndustry,
      companySizeId: formValues.companySize,
      title: formValues.title,
      phoneNumber: formValues.mobile,
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm,
    };

    this._companyService.registerCompany(company)
      .subscribe(_ => {
        this.showSuccess = true;
        this.successMessage = 'we received your request and we will send you an email within 24 hours.';
      },
        error => {
          this.errorMessage = error;
          this.showError = true;
        },
        () => {
          this.isLoading = false;
        }
        )
  }
}
