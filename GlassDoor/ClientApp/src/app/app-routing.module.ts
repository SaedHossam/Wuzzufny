import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationModule } from "./authentication/authentication.module";
import { RegisterUserComponent } from "./authentication/register-user/register-user.component";
import { ApplyJobComponent } from './components/apply-job/apply-job.component';
import { NotFoundComponent } from "./error-pages/not-found/not-found.component";
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';
import { PrivacyComponent } from './privacy/privacy.component';
import { AdminGuard } from './shared/guards/admin.guard';
import { AuthGuard } from './shared/guards/auth.guard';

const routes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'apply/:id', component: ApplyJobComponent, canActivate: [AuthGuard], pathMatch: "full" },

  { path: 'authentication', loadChildren: () => import("../app/authentication/authentication.module").then(m => m.AuthenticationModule) },
  { path: 'privacy', component: PrivacyComponent },
  { path: 'privacy', component: PrivacyComponent, canActivate: [AuthGuard, AdminGuard] },
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
