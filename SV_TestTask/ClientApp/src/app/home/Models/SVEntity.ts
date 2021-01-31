import { SVEntityType } from "./SVEntityType.enum";

export class SVEntity {
  entityType: SVEntityType;

  constructor() {
  }

  type: string;
  id: string;
  name: string;
  description: string;

  test(): void {};
}
