import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeRoutingModule } from './employee-routing.module';
import { ApplyJobComponent } from "./components/apply-job/apply-job.component";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule, } from 'primeng/card';
import { ViewJobComponent } from "./components/view-job/view-job.component";
import { RippleModule } from 'primeng/ripple';
import { SkeletonModule } from 'primeng/skeleton';
import { ToastrModule } from 'ngx-toastr';
import { EmployeeProfileComponent } from './components/employee-profile/employee-profile.component';
import { ProfileComponent } from './components/profile/profile.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MultiSelectModule } from 'primeng/multiselect';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { ApplicationsComponent } from './components/applications/applications.component';
import { CalendarModule } from 'primeng/calendar';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { FileUploadModule } from 'primeng/fileupload';

@NgModule({
  declarations: [
    ViewJobComponent,
    ApplyJobComponent,
    ProfileComponent,
    ApplicationsComponent,
    EmployeeProfileComponent,
  ],

  imports: [
    CommonModule,
    EmployeeRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonModule,
    CardModule,
    RippleModule,
    SkeletonModule,
    NgbModule,
    MultiSelectModule,
    AutoCompleteModule,
    CalendarModule,
    ProgressSpinnerModule,
    FileUploadModule,
    ToastrModule.forRoot(),

  ]
})
export class EmployeeModule { }
