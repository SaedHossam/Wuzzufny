import { Employee } from "./employee";
import { Language } from "./language";

export class UserLanguage {

  constructor(id?: number, languageId?: number, language?: Language,
    employeeId?: number, employee?: Employee, level?: number,) {

    this.id = id;
    this.languageId = languageId;
    this.language = language;
    this.employeeId = employeeId;
    this.employee = employee;
    this.level = level;

  }
  public id: number;
  public languageId: number;
  public language: Language;
  public employeeId: number;
  public employee: Employee;
  public level: number;



}
