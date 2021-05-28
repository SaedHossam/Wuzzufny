import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationModule } from "./authentication/authentication.module";
import { RegisterUserComponent } from "./authentication/register-user/register-user.component";

const routes: Routes = [
  //{ path: 'home', component: HomeComponent },
  //{ path: 'company', loadChildren: () => import('./company/company.module').then(m => m.CompanyModule) },
  { path: 'authentication', loadChildren: () => import("../App/authentication/authentication.module").then(m => m.AuthenticationModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
