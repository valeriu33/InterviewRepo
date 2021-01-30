import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Company} from '../models/company';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  public companyUrl = 'api/company';
  constructor(private http: HttpClient) { }

  public getById(id: number): Observable<Company> {
    return this.http.get<Company>(`${this.companyUrl}/${id}`);
  }
  public getByIdDymmy(id: number): Company {
    return { id: 1, name: 'com', shareholders: [{name: 'share', amountOfMoney: 10}, {name: 'mare', amountOfMoney: 12}]};
  }
}
