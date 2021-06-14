import { ApplicationStatusComponent } from './components/application-status/application-status.component';
import { JobApplicationsComponent } from './components/job-applications/job-applications.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from "./components/home/home.component";
import { PostJobComponent } from './components/post-job/post-job.component';
import { DisplayCompanyProfileComponent } from './components/display-company-profile/display-company-profile.component';
import { DisplayCompanyJobsComponent } from './components/display-company-jobs/display-company-jobs.component';
import { ModifyJobDataComponent } from './components/modify-job-data/modify-job-data.component';
import { ProfileComponent } from './components/profile/profile.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'postjob', component: PostJobComponent },
  { path: 'applications/:id', component: JobApplicationsComponent },
  { path: 'status/:id', component: ApplicationStatusComponent },
  { path: 'profile2', component: DisplayCompanyProfileComponent },
  { path: 'jobs', component: DisplayCompanyJobsComponent },
  { path: 'editJob/:id', component: ModifyJobDataComponent },
  { path: 'profile', component: ProfileComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
