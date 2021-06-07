import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from "./components/home/home.component";
import { PostJobComponent } from './components/post-job/post-job.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  {path:'postjob',component:PostJobComponent},
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
