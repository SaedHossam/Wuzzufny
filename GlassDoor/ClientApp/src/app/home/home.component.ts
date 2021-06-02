import { Component, OnInit } from "@angular/core";
import { PasswordModule } from 'primeng/password';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public homeText: string;
  public value1: Date;
  public value2: String;

  constructor() { }

  ngOnInit(): void {
    this.homeText = "WELCOME TO COMPANYEMPLOYEES CLIENT APP"
  }

}
