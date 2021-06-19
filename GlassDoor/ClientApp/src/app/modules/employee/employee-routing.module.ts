import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplyJobComponent } from './components/apply-job/apply-job.component';
import { EmployeeProfileComponent } from './components/employee-profile/employee-profile.component';
import { UploadComponent } from './components/upload/upload.component';
import { ViewJobComponent } from './components/view-job/view-job.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from "./components/profile/profile.component";
import { ApplicationsComponent } from "./components/applications/applications.component";


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'jobs', component: ViewJobComponent },
  { path: 'apply/:id', component: ApplyJobComponent },
  //{ path: 'profile/:id', component: EmployeeProfileComponent },
  { path: 'upload', component: UploadComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'applications', component: ApplicationsComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
