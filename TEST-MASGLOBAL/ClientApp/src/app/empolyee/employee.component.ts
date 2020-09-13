import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../Services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent implements OnInit {
  public employees: Employee[] = [];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {

    this.searchEmploye();
  }

  searchEmploye() {
    this.employeeService.GetEmployees().subscribe(resp => {
      this.employees = resp.result;
    });
  }

  searchEmployee(value: number) {

    if (value > 0) {
      this.employeeService.GetEmployee(value).subscribe(resp => {
        this.employees = [];
        this.employees.push(resp.result); 
      });

    } else {
      this.searchEmploye();
    }
  }
}

export interface Employee {
  id: number;
  name: string;
  contractTypeName: string;
  hourlySalary: number;
  monthlySalary: number;
  yearSalary: number;
  roleName: string;
}

