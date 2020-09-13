import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../empolyee/employee.component';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor( private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  GetEmployees() {
    return this.http.get<BodyResponseList>(this.baseUrl + 'employee');
  }

  GetEmployee( id: number) {
    return this.http.get<BodyResponseObject>(this.baseUrl + 'employee/' + id);
  }
}

interface BodyResponseList {
  isSuccess: boolean;
  messages: string;
  result: Employee[];
}

interface BodyResponseObject {
  isSuccess: boolean;
  messages: string;
  result: Employee;
}
