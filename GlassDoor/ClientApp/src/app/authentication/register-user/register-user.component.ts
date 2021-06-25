import { AuthenticationService } from "../../shared/services/authentication.service";
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PasswordConfirmationValidatorService } from
  "../../shared/custom-validators/password-confirmation-validator.service";
import { UserForRegistrationDto } from "../../interfaces/user/user-for-registration-dto.model";
import { Router } from '@angular/router';
import { EnvironmentUrlService } from "../../shared/services/environment-url.service";

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  public registerForm: FormGroup;
  public errorMessage: string = '';
  public showError: boolean;
  public showSuccess: boolean;
  public successMessage: string;

  constructor(private _authService: AuthenticationService, private _passConfValidator: PasswordConfirmationValidatorService, private _router: Router, private _envUrl: EnvironmentUrlService) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirm: new FormControl('')
    });

    this.registerForm.get('confirm').setValidators([Validators.required,
    this._passConfValidator.validateConfirmPassword(this.registerForm.get('password'))]);
  }

  public validateControl = (controlName: string) => {
    return this.registerForm.controls[controlName].invalid && this.registerForm.controls[controlName].touched
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.controls[controlName].hasError(errorName)
  }

  public registerUser = (registerFormValue) => {
    this.showError = false;
    const formValues = { ...registerFormValue };

    const user: UserForRegistrationDto = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm,
      clientURI: this._envUrl.urlAddress + '/authentication/emailconfirmation'
    };

    this._authService.registerUser("api/accounts/registration", user)
      .subscribe(_ => {
        // this._router.navigate(["/authentication/login"]);

        this.showSuccess = true;
        this.successMessage = 'The confirmation link has been sent, please check your email to confirm your account.'
      },
        error => {
          this.errorMessage = error;
          this.showError = true;
        })
  }
}
