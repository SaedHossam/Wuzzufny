import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CalendarModule } from 'primeng/calendar';
import { PasswordModule } from 'primeng/password';
import {ChipsModule} from 'primeng/chips';
import {AutoCompleteModule} from 'primeng/autocomplete';
import {EditorModule} from 'primeng/editor';
import {SelectButtonModule} from 'primeng/selectbutton';
import {RippleModule} from 'primeng/ripple';
import { InputNumberModule } from 'primeng/inputnumber';
import {MultiSelectModule} from 'primeng/multiselect';
import {FileUploadModule} from 'primeng/fileupload';
import { CompanyRoutingModule } from './company-routing.module';
import { HomeComponent } from './components/home/home.component';
import { PostJobComponent } from './components/post-job/post-job.component';
import { JobApplicationsComponent } from './components/job-applications/job-applications.component';
import { ApplicationStatusComponent } from './components/application-status/application-status.component';
import { DisplayCompanyProfileComponent } from './components/display-company-profile/display-company-profile.component';
import { DisplayCompanyJobsComponent } from './components/display-company-jobs/display-company-jobs.component';
import { ModifyJobDataComponent } from './components/modify-job-data/modify-job-data.component';
import { ProfileComponent } from './components/profile/profile.component';
import { CompanyProfileEditComponent } from './components/company-profile-edit/company-profile-edit.component';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import { ProgressSpinnerModule } from 'primeng/progressspinner';

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
    FileUploadModule,
    ConfirmDialogModule,
    ProgressSpinnerModule
  ]
})
export class CompanyModule { }
