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

@NgModule({
  declarations: [
    ViewJobComponent,
    
  ],
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    //CalendarModule,
//PasswordModule,
    FormsModule,
    ButtonModule,
    CardModule
  ]
})
export class EmployeeModule { }
