import { SVEntityType } from "./SVEntityType.enum";

export class SVEntity {
    constructor() {
    }
    public type:SVEntityType;
    public id:string;
    public name:string;
    public description:string;
    public test():void{};
}
