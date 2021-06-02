import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PasswordConfirmationValidatorService } from
  "../shared/custom-validators/password-confirmation-validator.service";
import { CompanyForRegistrationDto } from "../interfaces/company-register/company-for-registration-dto.model";
import { CompanyService } from "../shared/services/company.service"
import { IdustryService } from "../shared/services/idustry.service";
import { Industry } from "../interfaces/shared/industry.model";
import { ComapnySize } from "../interfaces/shared/comapny-size.model";
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
  public companySizes: ComapnySize[];

  constructor(private _passConfValidator: PasswordConfirmationValidatorService,
    private _companyService: CompanyService, private _idustryService: IdustryService, private _companySizeService: CompanySizeService) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      companyName: new FormControl(''),
      companyIndustry: new FormControl(''),
      companySize: new FormControl(''),
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      title: new FormControl(''),
      mobile: new FormControl(null, [Validators.pattern("[01][0-9]{9}")]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirmPassword: new FormControl(''),
      confirm: new FormControl('')
    });

    this.registerForm.get('confirm').setValidators([Validators.required, this._passConfValidator.validateConfirmPassword(this.registerForm.get('password'))]);

    this._idustryService.getIndustries().subscribe(industries => {
      this.industries = industries;
    },
      error => {
        //this.errorMessage = error;
        //this.showError = true;
        console.log(error);
      })

    this._companySizeService.getComapnySizes().subscribe(companySizes => {
      this.companySizes = companySizes;
    },
      error => {
        //this.errorMessage = error;
        //this.showError = true;
        console.log(error);
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
    const formValues = { ...registerFormValue };

    const company: CompanyForRegistrationDto = {
      companyName: formValues.companyName,
      companyIndustry: formValues.companyIndustry,
      companySize: formValues.companySize,
      title: formValues.title,
      mobile: formValues.mobile,
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm,
    };

    this._companyService.registerCompany(company)
      .subscribe(_ => {
        console.log("Successful registration");
        this.showSuccess = true;
        this.successMessage = 'we received your request and we will send you an email within 24 hours.';
      },
        error => {
          this.errorMessage = error;
          this.showError = true;
        })
  }
}
