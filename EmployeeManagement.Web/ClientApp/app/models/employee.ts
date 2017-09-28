import { IEmployeeProject } from "./employeeProject";
import { IEmployeeSkill } from "./employeeSkill";

export interface IEmployee {
    id: number,
    name: string,
    photo: File,
    isAvailable: boolean,
    rank: number,
    employeeProjects: IEmployeeProject[],
    employeeSkills: IEmployeeSkill[]
}