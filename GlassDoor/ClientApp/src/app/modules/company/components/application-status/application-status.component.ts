import { StatusDto } from './../../models/status-dto';
import { ApplicationDto } from './../../models/application-dto';
import { Application } from './../../../../models/application';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApplicationService } from '../../services/application.service';

interface status {
  status:string
}

@Component({
  selector: 'app-application-status',
  templateUrl: './application-status.component.html',
  styleUrls: ['./application-status.component.css']
})
export class ApplicationStatusComponent implements OnInit {
  application:ApplicationDto;
 
  statuses:status[];
  selectedStatus:string;
  
  constructor(private _applicationService:ApplicationService,private _route:ActivatedRoute) { 
    this.statuses = [
      {status:"In Considration"},
      {status:"Accepted"},
      {status:"Rejected"},
      {status:"Viewed"}
    ]
  }

  ngOnInit(): void {
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
    const statusDto:StatusDto = {id:this.application.id, status:this.selectedStatus};
    this._applicationService.editStatus(statusDto).subscribe(a=>{
      console.log(a);
    })
  }
}
