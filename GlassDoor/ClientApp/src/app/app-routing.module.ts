import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationModule } from "./authentication/authentication.module";
import { RegisterUserComponent } from "./authentication/register-user/register-user.component";
import { NotFoundComponent } from "./error-pages/not-found/not-found.component";
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';
import { PrivacyComponent } from './privacy/privacy.component';
import { AdminGuard } from './shared/guards/admin.guard';
import { AuthGuard } from './shared/guards/auth.guard';
import { CompanyGuard } from "./shared/guards/company.guard";
import { EmployeeGuard } from "./shared/guards/employee.guard";

const routes: Routes = [
  { path: 'home', component: HomeComponent},
  { path: 'authentication', loadChildren: () => import("../app/authentication/authentication.module").then(m => m.AuthenticationModule) },
  { path: 'admin', loadChildren: () => import("./modules/admin/admin.module").then(m => m.AdminModule), canActivate: [AuthGuard, AdminGuard]  },
  { path: 'company', loadChildren: () => import("./modules/company/company.module").then(m => m.CompanyModule), canActivate: [AuthGuard, CompanyGuard]  },
  { path: 'employee', loadChildren: () => import("./modules/employee/employee.module").then(m => m.EmployeeModule), canActivate: [AuthGuard, EmployeeGuard]  },
  { path: 'privacy', component: PrivacyComponent, canActivate: [AuthGuard] },
  { path: 'forbidden', component: ForbiddenComponent },
  { path: '404', component: NotFoundComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/404', pathMatch: 'full' },
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
