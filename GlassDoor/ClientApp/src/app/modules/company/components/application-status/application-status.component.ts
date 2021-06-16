import { CompanyApplicationStatusDto } from './../../models/company-application-status-dto';
import { ApplicationDto } from './../../models/application-dto';
import { Application } from './../../../../models/application';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApplicationService } from '../../services/application.service';
import { EditApplicationStatusDto } from '../../models/edit-application-status-dto';

// interface status {
//   status:string
// }

@Component({
  selector: 'app-application-status',
  templateUrl: './application-status.component.html',
  styleUrls: ['./application-status.component.css']
})
export class ApplicationStatusComponent implements OnInit {
  application:ApplicationDto;
 
  // statuses:status[];
  statuses:CompanyApplicationStatusDto[];
  selectedStatus:string;
  
  constructor(private _applicationService:ApplicationService,private _route:ActivatedRoute) { 
    // this.statuses = [
    //   {status:"inconsideration"},
    //   {status:"accepted"},
    //   {status:"rejected"},
    //   {status:"viewed"}
    // ]
  }

  ngOnInit(): void {
    this._applicationService.getAllCompanyApplicationStatus().subscribe(a =>{
      this.statuses = a;
    })

    this._route.params.subscribe(p =>{
      this._applicationService.getJobApplication(p.id).subscribe(app=>{
        // this.application=app;
        console.log(app);
        this.selectedStatus = app.status;
        this.application = app;
      })
    })
  }

  editStatus(){
    const statusDto:EditApplicationStatusDto = {id:this.application.id, status:this.selectedStatus};
    this._applicationService.editStatus(statusDto).subscribe(a=>{
      console.log(a);
    })
  }
}
