import { IProject } from "./project";
import { ISkill } from "./skill";

export interface IProjectSkill {
    id: number,
    projectId: number,
    skillId: number,
    project: IProject,
    skill: ISkill,
    rank: number
}