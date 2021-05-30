import { Component, OnInit } from "@angular/core";
import { Job } from '../models/job';
import { JobService } from '../servicess/job.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  jobs: Job[] = [];
  totalLength: any;//paging
  page: number = 1;//paging


  // searching
  title: any;

  constructor(public service: JobService) { }

  ngOnInit(): void {
    this.service.getJobs().subscribe(a => {
      this.jobs = a;
      this.totalLength = a.length;// paging
      console.log(this.totalLength);
    })
  }

  // Search start region
  Search() {
    if (this.title == "") {
      this.ngOnInit();
    }
    else {
      this.jobs = this.jobs.filter(res => {
        return res.title.toLocaleLowerCase().match(this.title.toLocaleLowerCase());
      });
    }


  }

}
