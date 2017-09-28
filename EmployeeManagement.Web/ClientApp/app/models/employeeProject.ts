import { IProject } from "./project";
import { IEmployee } from "./employee";

export interface IEmployeeProject {
    id: number,
    projectId: number,
    employeeId: number,
    project: IProject,
    employee: IEmployee
}