import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from "@angular/forms";
import { AdminRoutingModule } from './admin-routing.module';
import { HomeComponent } from './components/home/home.component';
import { CompanyRequestsComponent } from './components/company-requests/company-requests.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';
import { NgbModule } from "@ng-bootstrap/ng-bootstrap"
import { ChartModule } from 'primeng/chart';

@NgModule({
  declarations: [
    HomeComponent,
    CompanyRequestsComponent,
    SideMenuComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    NgbModule,
    FormsModule,
    ChartModule
  ]
})
export class AdminModule { }
