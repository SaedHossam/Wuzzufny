import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from "./components/home/home.component";
import { PostJobComponent } from './components/post-job/post-job.component';
import { DisplayCompanyProfileComponent } from './components/display-company-profile/display-company-profile.component';
import { DisplayCompanyJobsComponent } from './components/display-company-jobs/display-company-jobs.component';
import { ModifyJobDataComponent } from './components/modify-job-data/modify-job-data.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  {path:'postjob',component:PostJobComponent},
  {path:'displaycompanyprofile',component:DisplayCompanyProfileComponent},
  {path:'displaycompanyjobs',component:DisplayCompanyJobsComponent},
  {path:'editJob',component:ModifyJobDataComponent},

  {path:'modifycompanyjob',component:ModifyJobDataComponent},

  { path: '', redirectTo: 'home', pathMatch: 'full' },

  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
