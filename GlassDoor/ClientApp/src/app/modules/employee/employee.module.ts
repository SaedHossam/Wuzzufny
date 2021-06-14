import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutingModule } from './employee-routing.module';
import { ApplyJobComponent } from './components/apply-job/apply-job.component';
//import { CalendarModule } from "primeng/calendar";
//import { PasswordModule } from "primeng/password";
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule, } from 'primeng/card';
import { ViewJobComponent } from './components/view-job/view-job.component';
import { RippleModule } from 'primeng/ripple';
import { HomeComponent } from './home/home.component';
import { EmployeeProfileComponent } from './components/employee-profile/employee-profile.component';
import { EditProfileComponent } from './components/edit-profile/edit-profile.component';
import { UploadComponent } from './components/upload/upload.component';




@NgModule({
  declarations: [
    ViewJobComponent,
    ApplyJobComponent,
    HomeComponent,
    EmployeeProfileComponent,
    EditProfileComponent,
    UploadComponent
  ],

  imports: [
    CommonModule,
    EmployeeRoutingModule,
    FormsModule,
    ButtonModule,
    CardModule,
    RippleModule,



  ]
})
export class EmployeeModule { }
