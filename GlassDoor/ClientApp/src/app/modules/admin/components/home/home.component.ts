import { Component, OnInit } from '@angular/core';
import { AdminService } from "../../../../shared/services/admin.service";
import { AdminInsights } from "../../../../models/admin-insights";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  insights: AdminInsights;
  jobsByType: any;
  jobsByTypeOptions: any;

  jobsByCountry: any;
  jobsByCountryOptions: any;

  jobsByCategory: any;
  jobsByCategoryOptions: any;

  totalJobsByDate: any;
  totalJobsByDateOptions: any;

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
    this.adminService.getInsights().subscribe(i => {
      this.insights = i;

      const jobTypesLabels = [];
      const jobTypesData = [];

      for (let item of this.insights.openJobsByType) {
        jobTypesLabels.push(item.type);
        jobTypesData.push(item.count);
      }

      this.jobsByType = {
        labels: jobTypesLabels,
        datasets: [
          {
            data: jobTypesData,
            backgroundColor: [
              "#FF6384",
              "#36A2EB",
              "#FFCE56",
              "#FF9020",
              "#22CFCF"
            ],
            hoverBackgroundColor: [
              "#FF6384",
              "#36A2EB",
              "#FFCE56",
              "#FF9020",
              "#22CFCF"
            ]
          }
        ]
      };
      this.jobsByTypeOptions = {
        title: {
          display: true,
          text: 'Open jobs by Type',
          fontSize: 16
        },
        legend: {
          position: 'bottom'
        }
      };

      const jobsCountryLabels = [];
      const jobCountryData = [];

      for (let item of this.insights.openJobsByCountry) {
        jobsCountryLabels.push(item.country);
        jobCountryData.push(item.count);
      }

      this.jobsByCountry = {
        labels: jobsCountryLabels,
        datasets: [
          {
            data: jobCountryData,
            backgroundColor: [
              "#FF6384",
              "#36A2EB",
              "#FFCE56",
              "#FF9020",
              "#22CFCF"
            ],
            hoverBackgroundColor: [
              "#FF6384",
              "#36A2EB",
              "#FFCE56",
              "#FF9020",
              "#22CFCF"
            ]
          }
        ]
      };
      this.jobsByCountryOptions = {
        title: {
          display: true,
          text: 'Open jobs by Country',
          fontSize: 16
        },
        legend: {
          position: 'bottom'
        }
      };

      const jobsCategoryLabels = [];
      const jobCategoryData = [];

      for (let item of this.insights.openJobsByJobCategory) {
        jobsCategoryLabels.push(item.category);
        jobCategoryData.push(item.count);
      }

      this.jobsByCategory = {
        labels: jobsCategoryLabels,
        datasets: [
          {
            data: jobCategoryData,
            backgroundColor: [
              "#FF6384",
              "#36A2EB",
              "#FFCE56",
              "#FF9020",
              "#22CFCF"
            ],
            hoverBackgroundColor: [
              "#FF6384",
              "#36A2EB",
              "#FFCE56",
              "#FF9020",
              "#22CFCF"
            ]
          }
        ]
      };
      this.jobsByCategoryOptions = {
        title: {
          display: true,
          text: 'Open jobs by category',
          fontSize: 16
        },
        legend: {
          position: 'bottom'
        }
      };

      const totalJobsByDateLabels = [];
      const totalJobsByDateData = [];

      for (let item of this.insights.totalJobsByDate) {
        totalJobsByDateLabels.push(item.date);
        totalJobsByDateData.push(item.count);
      }

      this.totalJobsByDate = {
        labels: totalJobsByDateLabels,
        datasets: [
          {
            data: totalJobsByDateData,
            borderColor: '#42A5F5',
            fill: false
          }
        ],
      };
      this.totalJobsByDateOptions = {
        title: {
          display: true,
          text: 'Total jobs by date',
          fontSize: 16
        },
        legend: {
          display: false,
          position: 'bottom'
        },
        scales: {
          yAxes: [{
            ticks: {
              suggestedMin: 0,
              suggestedMax: 10
            }
          }]
        }
      };
    });
  }
}
