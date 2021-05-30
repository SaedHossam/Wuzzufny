import { Subject } from "rxjs"
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from "./environment-url.service";
import { UserForAuthenticationDto } from '../../interfaces/user/user-for-authentication-dto.model';
import { UserForRegistrationDto } from "../../interfaces/user/user-for-registration-dto.model";
import { RegistrationResponseDto } from "../../interfaces/response/registration-response-dto.model";
import { ForgotPasswordDto } from "../../interfaces/resetPassword/forgot-password-dto.model";
import { ResetPasswordDto } from "../../interfaces/resetPassword/reset-password-dto.model";


import { GoogleLoginProvider, SocialAuthService } from "angularx-social-login";
import { ExternalAuthDto } from "../../interfaces/external-auth/external-auth-dto";
import { AuthResponseDto } from "../../interfaces/response/auth-response-dto";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private _authChangeSub = new Subject<boolean>();
  public authChanged = this._authChangeSub.asObservable();

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService, private _externalAuthService: SocialAuthService) { }
  // private _jwtHelper: JwtHelperService

  public registerUser = (route: string, body: UserForRegistrationDto) => {
    return this._http.post<RegistrationResponseDto>(this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this._authChangeSub.next(isAuthenticated);
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  public loginUser = (route: string, body: UserForAuthenticationDto) => {
    return this._http.post(this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }

  public logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }

  public signInWithGoogle = () => {
    return this._externalAuthService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }

  public signOutExternal = () => {
    this._externalAuthService.signOut();
  }

  public externalLogin = (route: string, body: ExternalAuthDto) => {
    return this._http.post<AuthResponseDto>(this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }

  public forgotPassword = (route: string, body: ForgotPasswordDto) => {
    return this._http.post(this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }

  public resetPassword = (route: string, body: ResetPasswordDto) => {
    return this._http.post(this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }
}
