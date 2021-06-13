import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from "./components/home/home.component";
import { PostJobComponent } from './components/post-job/post-job.component';
import { ProfileComponent } from './components/profile/profile.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  {path:'postjob',component:PostJobComponent},
  {path:'profile',component:ProfileComponent},
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
