import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompanyRoutingModule } from './company-routing.module';
import { HomeComponent } from './components/home/home.component';
import { PostJobComponent } from './components/post-job/post-job.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { PasswordModule } from 'primeng/password';
import {ChipsModule} from 'primeng/chips';
import {AutoCompleteModule} from 'primeng/autocomplete';
import {EditorModule} from 'primeng/editor';
import { JobApplicationsComponent } from './components/job-applications/job-applications.component';
import { ApplicationStatusComponent } from './components/application-status/application-status.component';
import {SelectButtonModule} from 'primeng/selectbutton';
import { DisplayCompanyProfileComponent } from './components/display-company-profile/display-company-profile.component';
import { DisplayCompanyJobsComponent } from './components/display-company-jobs/display-company-jobs.component';
import { ModifyJobDataComponent } from './components/modify-job-data/modify-job-data.component';
import {RippleModule} from 'primeng/ripple';
import { InputNumberModule } from 'primeng/inputnumber';
import { ProfileComponent } from './components/profile/profile.component';
import { CompanyProfileEditComponent } from './components/company-profile-edit/company-profile-edit.component';
import {MultiSelectModule} from 'primeng/multiselect';
import {FileUploadModule} from 'primeng/fileupload';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    HomeComponent,
    PostJobComponent,
    JobApplicationsComponent,
    ApplicationStatusComponent,
    DisplayCompanyProfileComponent,
    DisplayCompanyJobsComponent,
    ModifyJobDataComponent,
    ProfileComponent,
    CompanyProfileEditComponent,
  ],
  imports: [
    CommonModule,
    CompanyRoutingModule,
    FormsModule,
    CalendarModule,
    PasswordModule,
    ReactiveFormsModule,
    ChipsModule,
    AutoCompleteModule,
    EditorModule,
    SelectButtonModule,
    RippleModule,
    InputNumberModule,
    NgbModule,
    MultiSelectModule,
    FileUploadModule
  ]
})
export class CompanyModule { }
