import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeRoutingModule } from './employee-routing.module';
import { ApplyJobComponent } from "./components/apply-job/apply-job.component";
//import { CalendarModule } from "primeng/calendar";
//import { PasswordModule } from "primeng/password";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule, } from 'primeng/card';
import { ViewJobComponent } from "./components/view-job/view-job.component";
import { RippleModule } from 'primeng/ripple';
import { HomeComponent } from './home/home.component';
import { SkeletonModule } from 'primeng/skeleton';
import { ProfileComponent } from './components/profile/profile.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MultiSelectModule } from 'primeng/multiselect';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { ApplicationsComponent } from './components/applications/applications.component';


@NgModule({
  declarations: [
    ViewJobComponent,
    ApplyJobComponent,
    HomeComponent,
    ProfileComponent,
    ApplicationsComponent
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
    AutoCompleteModule
  ]
})
export class EmployeeModule { }
