import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PrimeNGConfig } from 'primeng/api';
import { Application } from '../../../../models/application';
import { JobDetailsDto } from '../../../../models/job-details-dto';
import { JobService } from '../../../../shared/services/job.service';

@Component({
  selector: 'app-apply-job',
  templateUrl: './apply-job.component.html',
  styleUrls: ['./apply-job.component.css']
})
export class ApplyJobComponent implements OnInit {
  job: JobDetailsDto = new JobDetailsDto();

  constructor(private service: JobService, private toastr: ToastrService, private ac: ActivatedRoute) { }

  ngOnInit(): void {
    this.ac.params.subscribe(p => {
      this.service.getjobdbyid(p.id).subscribe(a => {
        this.job = a;

        console.log(a);
      });
    });
  }

  apply() {
    this.service.applyJob(this.job.jobId).subscribe(a => {
      this.toastr.success(`You applied successfully`, 'Success');
      this.job.applied = true;
    });
  }
}
