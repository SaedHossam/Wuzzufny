import { ApplicationStatusComponent } from './components/application-status/application-status.component';
import { JobApplicationsComponent } from './components/job-applications/job-applications.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from "./components/home/home.component";
import { PostJobComponent } from './components/post-job/post-job.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  {path:'postjob',component:PostJobComponent},
  {path:'applications',component:JobApplicationsComponent},
  {path:'status/:id',component:ApplicationStatusComponent},
  // {path:'status',component:ApplicationStatusComponent},
  { path: '', redirectTo: 'home', pathMatch: 'full' },

  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
