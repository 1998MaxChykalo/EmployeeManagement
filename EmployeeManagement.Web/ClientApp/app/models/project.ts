import { IEmployeeProject } from "./employeeProject";
import { IProjectSkill } from "./projectSkill";

export interface IProject {
    id: number,
    name: string,
    description: string,
    startDateUtc: Date,
    isInDevelopment: boolean,
    employeeProjects: IEmployeeProject[],
    projectSkills: IProjectSkill[]
}