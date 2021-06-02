import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from "./menu/menu.component";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ErrorHandlerService } from "./shared/services/error-handler.service";

import { NotFoundComponent } from "./error-pages/not-found/not-found.component";
import { JwtModule } from "@auth0/angular-jwt";
import { RouterModule } from '@angular/router';
import { AuthGuard } from './shared/guards/auth.guard';
import { PrivacyComponent } from './privacy/privacy.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';

import { SocialLoginModule, SocialAuthServiceConfig } from 'angularx-social-login';
import { GoogleLoginProvider } from 'angularx-social-login';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CalendarModule} from "primeng/calendar";
import { FormsModule, ReactiveFormsModule  } from "@angular/forms"
import { PasswordModule} from "primeng/password";
import { RecruitmentComponent } from './recruitment/recruitment.component';
import { EmployerRegisterComponent } from './employer-register/employer-register.component'
import { InputNumberModule } from 'primeng/inputnumber';
import { CompanyService } from "./shared/services/company.service";
import { PasswordConfirmationValidatorService } from
  "./shared/custom-validators/password-confirmation-validator.service";
import { DropdownModule } from 'primeng/dropdown';
import { IdustryService } from "./shared/services/idustry.service";


export function tokenGetter() {
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    NotFoundComponent,
    PrivacyComponent,
    ForbiddenComponent,
    HomeComponent,
    RecruitmentComponent,
    EmployerRegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule ,
    CalendarModule,
    PasswordModule,
    InputNumberModule,
    DropdownModule,

    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:44390"],
        disallowedRoutes: []
      }
    }),
    SocialLoginModule 
  ],


  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true
    },
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              '265437536059-jbtlo3po0rg4thkudi9ouchckrahf172.apps.googleusercontent.com'
            )
          },
        ],
      } as SocialAuthServiceConfig
    },
    CompanyService,
    PasswordConfirmationValidatorService,
    IdustryService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
