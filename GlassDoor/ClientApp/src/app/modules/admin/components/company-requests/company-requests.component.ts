import { Component, OnInit } from '@angular/core';
import { CompanyRequestsService } from "../../../../shared/services/company-requests.service";
import { CompanyRequest } from "../../../../models/company-request";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CompanyRequestStatus } from "../../../../models/company-request-status";

@Component({
  selector: 'app-company-requests',
  templateUrl: './company-requests.component.html',
  styleUrls: ['./company-requests.component.css']
})
export class CompanyRequestsComponent implements OnInit {
  page = 1;
  pageSize = 5;
  collectionSize = 0;
  allRequests: CompanyRequest[] = [];
  requests: CompanyRequest[];
  requestDetails: CompanyRequest;
  requestId: number;
  isLoading: boolean = false;

  constructor(private _companyRequestsService: CompanyRequestsService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.loadComapiesRequestes();
  }

  loadComapiesRequestes() {
    this.isLoading = true;
    this._companyRequestsService.getCompaniesRequests().subscribe(a => {
      this.allRequests = a;
      this.collectionSize = this.allRequests.length;

      this.refreshCompanies();
      this.isLoading = false;
    });
  }

  refreshCompanies() {
    this.requests = this.allRequests
      .map((company, i) => ({ number: i + 1, ...company }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

  open(content) {
    this._companyRequestsService.getCompanyRequest(this.requestId).subscribe(r => {
      this.requestDetails = r;
    });

    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {

    }, (reason) => {

    });
  }

  approve(id: number, accept: boolean) {
    this.isLoading = true;

    this._companyRequestsService.changeCompanyRequestStatus(new CompanyRequestStatus(id, accept)).subscribe((result) => {
    },
      () => { },
      () => {
        this.loadComapiesRequestes();
      }
    );
  }
}
