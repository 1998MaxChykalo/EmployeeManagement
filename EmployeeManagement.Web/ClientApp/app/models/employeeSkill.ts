import { ISkill } from "./skill";
import { IEmployee } from "./employee";

export interface IEmployeeSkill {
    id: number,
    employeeId: number,
    skillId: number,
    rank: number,
    employee: IEmployee,
    skill: ISkill
}