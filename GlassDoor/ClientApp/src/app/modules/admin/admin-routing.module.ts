import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from "./components/home/home.component";
import { CompanyRequestsComponent } from "./components/company-requests/company-requests.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'companies-requests', component: CompanyRequestsComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
