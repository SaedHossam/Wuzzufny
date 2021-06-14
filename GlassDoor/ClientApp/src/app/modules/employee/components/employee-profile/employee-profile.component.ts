import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '../../../../models/employee';
import { Gender } from '../../../../models/enums/gender.enum';
import { Skills } from '../../../../models/skills';
import { UserProfileService } from '../../../../shared/services/user-profile.service';

@Component({
  selector: 'app-employee-profile',
  templateUrl: './employee-profile.component.html',
  styleUrls: ['./employee-profile.component.css']
})
export class EmployeeProfileComponent implements OnInit {

  constructor(private service: UserProfileService, private ac: ActivatedRoute) { }

  profile: Employee = new Employee();
  public response: { dbPath: '' };

  ngOnInit(): void {
    this.ac.params.subscribe(p => {
      this.service.getEmpById(p.id).subscribe(a => {
        this.profile = a;
        console.log(this.profile);

      });
    });
  }

  public uploadFinished = (event) => {
    this.response = event;
  }


  public printDateOnly(date: Date) {

    date = new Date(date);

    const dayNames = new Array('Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday');
    const monthNames = new Array('January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December');

    const dayOfWeek = date.getDay();
    const dayOfMonth = date.getDate();
    let sup = '';
    const month = date.getMonth();
    const year = date.getFullYear();

    if (dayOfMonth === 1 || dayOfMonth === 21 || dayOfMonth === 31) {
      sup = 'st';
    } else if (dayOfMonth === 2 || dayOfMonth === 22) {
      sup = 'nd';
    } else if (dayOfMonth === 3 || dayOfMonth === 23) {
      sup = 'rd';
    } else {
      sup = 'th';
    }

    const dateString = dayNames[dayOfWeek] + ', ' + dayOfMonth + sup + ' ' + monthNames[month] + ' ' + year;

    return dateString;
  }

  public printGender(value: number) {
    return value == 0 ? "Male":"Female"
  
  }

  public printMilitaryStatus(value: number) {
    if (value == 0)
      return "Not applicable";
    else if (value == 1)
      return "Exempted";
    else if (value == 2)
      return "Completed";
    else 
      return "Postponed";
  }

  public willingToRelocate(value: boolean) {
    return value == true ? "Yes" : "No";
  }


}
