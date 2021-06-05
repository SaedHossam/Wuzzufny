import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyRoutingModule } from './company-routing.module';
import { HomeComponent } from './components/home/home.component';
import { PostJobComponent } from './components/post-job/post-job.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { PasswordModule } from 'primeng/password';
import { HttpClient, HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    HomeComponent,
    PostJobComponent
  ],
  imports: [
    CommonModule,
    CompanyRoutingModule,
    FormsModule,
    CalendarModule,
    PasswordModule,
    ReactiveFormsModule,
    
    
  ]
})
export class CompanyModule { }
