import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from '../../../../models/employee';
import { UserProfileService } from '../../../../shared/services/user-profile.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  constructor(private service: UserProfileService,
    private ac: ActivatedRoute) { }

  profile: Employee = new Employee();

  ngOnInit(): void {
    this.ac.params.subscribe(p => {
      this.service.getEmpById(p.id).subscribe(a => {
        this.profile = a;
      })
    })
  }


  public update() {
    this.service.editEmpProfile(this.profile).subscribe(a => {
      this.profile = a;

    })
  }
      
}
