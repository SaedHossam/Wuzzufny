import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationModule } from "./authentication/authentication.module";
import { RegisterUserComponent } from "./authentication/register-user/register-user.component";
import { NotFoundComponent } from "./error-pages/not-found/not-found.component";
import { HomeComponent } from "./home/home.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  //{ path: 'company', loadChildren: () => import('./company/company.module').then(m => m.CompanyModule) },
  { path: 'authentication', loadChildren: () => import("../app/authentication/authentication.module").then(m => m.AuthenticationModule) },
  { path: '404', component: NotFoundComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/404', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
