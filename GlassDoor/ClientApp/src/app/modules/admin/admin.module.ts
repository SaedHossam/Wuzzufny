import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { HomeComponent } from './components/home/home.component';
import { CompanyRequestsComponent } from './components/company-requests/company-requests.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';
import { NgbModule } from "@ng-bootstrap/ng-bootstrap"


@NgModule({
  declarations: [
    HomeComponent,
    CompanyRequestsComponent,
    SideMenuComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    NgbModule
  ]
})
export class AdminModule { }
