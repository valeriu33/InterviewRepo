import {Component, OnInit, ViewChild} from '@angular/core';
import {
  ApexNonAxisChartSeries,
  ApexResponsive,
  ApexChart, ChartComponent
} from 'ng-apexcharts';
import {CompanyService} from '../services/company.service';
import {Company} from '../models/company';
import {Observable} from 'rxjs';

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
  public companies: Company[];
  public selectedCompany: Observable<Company>;

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
    companyService.getAll().subscribe(c => this.companies = c);
  }

  ngOnInit(): void {
  }

  SelectCompany(id: number): void {
    this.companyService.getById(id).subscribe(c => {
        this.chartOptions.series = c.shareholders.map(s => s.amountOfMoney);
        this.chartOptions.labels = c.shareholders.map(s => s.name);
      }
    );
  }
}
