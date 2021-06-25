import { ForgotPasswordDto } from "../../interfaces/resetPassword/forgot-password-dto.model";
import { AuthenticationService } from './../../shared/services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { EnvironmentUrlService } from "../../shared/services/environment-url.service";

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {
  public forgotPasswordForm: FormGroup
  public successMessage: string;
  public errorMessage: string;
  public showSuccess: boolean;
  public showError: boolean;

  constructor(private _authService: AuthenticationService, private _envUrl: EnvironmentUrlService) { }

  ngOnInit(): void {
    this.forgotPasswordForm = new FormGroup({
      email: new FormControl("", [Validators.required, Validators.email])
    })
  }

  public validateControl = (controlName: string) => {
    return this.forgotPasswordForm.controls[controlName].invalid && this.forgotPasswordForm.controls[controlName].touched
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.forgotPasswordForm.controls[controlName].hasError(errorName)
  }

  public forgotPassword = (forgotPasswordFormValue) => {
    this.showError = this.showSuccess = false;

    const forgotPass = { ...forgotPasswordFormValue };
    const forgotPassDto: ForgotPasswordDto = {
      email: forgotPass.email,
      clientURI: this._envUrl.urlAddress + '/authentication/resetpassword'
    }

    this._authService.forgotPassword('api/accounts/forgotpassword', forgotPassDto)
      .subscribe(_ => {
        this.showSuccess = true;
        this.successMessage = 'The link has been sent, please check your email to reset your password.'
      },
        err => {
          this.showError = true;
          this.errorMessage = err;
        })
  }

}
