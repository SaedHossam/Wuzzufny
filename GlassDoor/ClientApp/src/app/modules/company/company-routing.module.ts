import { ApplicationStatusComponent } from './components/application-status/application-status.component';
import { JobApplicationsComponent } from './components/job-applications/job-applications.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from "./components/home/home.component";
import { PostJobComponent } from './components/post-job/post-job.component';
import { ModifyJobDataComponent } from './components/modify-job-data/modify-job-data.component';
import { ProfileComponent } from './components/profile/profile.component';
import { CompanyProfileEditComponent } from './components/company-profile-edit/company-profile-edit.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'postjob', component: PostJobComponent },
  { path: 'applications/:id/:status', component: JobApplicationsComponent },
  { path: 'applications/:id', component: JobApplicationsComponent },
  { path: 'status/:id', component: ApplicationStatusComponent },
  { path: 'editJob/:id', component: ModifyJobDataComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'profile/:id', component: ProfileComponent },
  { path: 'editprofile', component: CompanyProfileEditComponent},
  { path: '', redirectTo: 'home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
