import { NgModule } from '@angular/core'; 
import { RouterModule, Routes } from '@angular/router';
import { ApplyJobComponent } from "./components/apply-job/apply-job.component";
import { ViewJobComponent } from "./components/view-job/view-job.component";
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from "./components/profile/profile.component";


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'jobs', component: ViewJobComponent },
  { path: 'apply/:id', component: ApplyJobComponent },
  { path: 'profile', component: ProfileComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },


  {
get component() {
          return this._component;
      },
set component(value) {
          this._component = value;
      },
 },
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
