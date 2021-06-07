import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplyJobComponent } from './components/apply-job/apply-job.component';
import { ViewJobComponent } from './components/view-job/view-job.component';


const routes: Routes = [
  //{ path: 'home', component: HomeComponent },
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
