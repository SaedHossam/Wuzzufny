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
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    ViewJobComponent,
    ApplyJobComponent,
  
    
  ],
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    //CalendarModule,
//PasswordModule,
    FormsModule,
    ButtonModule,
    CardModule,
    RippleModule,
    BrowserModule,
    BrowserAnimationsModule,

  ]
})
export class EmployeeModule { }
