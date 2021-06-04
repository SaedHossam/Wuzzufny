import { HttpClient, HttpClientModule, HttpClientXsrfModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SeedAngular } from '../../models/seed-angular';

@Component({
  selector: 'app-post-job',
  templateUrl: './post-job.component.html',
  styleUrls: ['./post-job.component.css']
})
export class PostJobComponent implements OnInit {
DB:SeedAngular;
  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.http.get<SeedAngular>("https://localhost:44390/api/jobs/SeedAngular").subscribe(a=>{
      this.DB=a;
      console.log(this.DB);
    })
  
  }

}
