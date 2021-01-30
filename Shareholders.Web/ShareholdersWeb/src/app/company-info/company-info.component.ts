import {Component, OnInit, ViewChild} from '@angular/core';
import {
  ApexNonAxisChartSeries,
  ApexResponsive,
  ApexChart, ChartComponent
} from 'ng-apexcharts';
import {CompanyService} from '../services/company.service';

export type ChartOptions = {
  series: ApexNonAxisChartSeries;
  chart: ApexChart;
  responsive: ApexResponsive[];
  labels: any;
};

@Component({
  selector: 'app-company-info',
  templateUrl: './company-info.component.html',
  styleUrls: ['./company-info.component.css']
})
export class CompanyInfoComponent implements OnInit {
  public chartOptions: Partial<ChartOptions>;

  @ViewChild('chart') chart: ChartComponent;
  constructor(private companyService: CompanyService) {
    this.chartOptions = {
      series: [],
      chart: {
        width: 380,
        type: 'pie'
      },
      labels: [],
      responsive: [
        {
          breakpoint: 480,
          options: {
            chart: {
              width: 200
            },
            legend: {
              position: 'bottom'
            }
          }
        }
      ]
    };
    const a = companyService.getByIdDymmy(1);
    this.chartOptions.series = a.shareholders.map(s => s.amountOfMoney);
    this.chartOptions.labels = a.shareholders.map(s => s.name);
  }

  ngOnInit(): void {
  }

}
