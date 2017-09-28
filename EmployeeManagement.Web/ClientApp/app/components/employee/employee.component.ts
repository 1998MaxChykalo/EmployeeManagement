import { Component, OnInit } from "@angular/core";
import { EmployeeService } from "../../services/employee/employee.service";
import { IEmployee } from "../../models/employee";


@Component({
    templateUrl: './employee.component.html',
    styleUrls: ['./employee.component.css']
})

export class EmployeeComponent implements OnInit {
    

    employees: IEmployee[];

    constructor(private employeeService: EmployeeService){}

    ngOnInit(): void {
        this.employeeService.getEmployees()
                .subscribe(employees => this.employees = employees);
    }

}