import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyRoutingModule } from './company-routing.module';
import { HomeComponent } from './components/home/home.component';
import { PostJobComponent } from './components/post-job/post-job.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { PasswordModule } from 'primeng/password';
import { HttpClient, HttpClientModule } from '@angular/common/http';
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

@NgModule({
  declarations: [
    HomeComponent,
    PostJobComponent,
    JobApplicationsComponent,
    ApplicationStatusComponent,
    DisplayCompanyProfileComponent,
    DisplayCompanyJobsComponent,
    ModifyJobDataComponent,
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
  ]
})
export class CompanyModule { }
