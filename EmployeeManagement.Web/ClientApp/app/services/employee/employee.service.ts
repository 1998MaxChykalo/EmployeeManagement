import { Injectable } from "@angular/core";
import { IEmployee } from "../../models/employee";
import { Http, Response, Headers, RequestOptions } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map"
import "rxjs/add/operator/do"
import "rxjs/add/operator/catch"

@Injectable()
export class EmployeeService {
    
    constructor(private http: Http){}

    private employeeUrl = '/api/employees';

    getEmployees(): Observable<IEmployee[]> {
        return this.http.get(this.employeeUrl)
                    .map((res : Response) => {
                        let employees = res.json();
                        console.log(employees);
                        return employees;
                    })
                    .catch(this.handleError);
    }
    
    private extractData(response: Response) {
        let body = response.json();
        return body.data || {};
    }

    private handleError(error: Response): Observable<any> {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}