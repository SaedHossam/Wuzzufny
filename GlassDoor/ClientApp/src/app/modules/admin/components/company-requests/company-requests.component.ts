import { Component, OnInit } from '@angular/core';
import { CompanyRequestsService } from "../../../../shared/services/company-requests.service";
import { CompanyRequest } from "../../../../models/company-request";

@Component({
  selector: 'app-company-requests',
  templateUrl: './company-requests.component.html',
  styleUrls: ['./company-requests.component.css']
})
export class CompanyRequestsComponent implements OnInit {
  page = 1;
  pageSize = 4;
  collectionSize = 0;
  allRequests:CompanyRequest[];
  requests: CompanyRequest[];

  constructor(private _companyRequestsService: CompanyRequestsService) { }

  ngOnInit(): void {
    this._companyRequestsService.getCompaniesRequests().subscribe(a => {
      this.allRequests = a;
      this.collectionSize = this.allRequests.length;

      this.refreshCompanies();

      console.log(a);
    })
  }

  refreshCompanies() {
    this.requests = this.allRequests
      .map((company, i) => ({ number: i + 1, ...company }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }
}
