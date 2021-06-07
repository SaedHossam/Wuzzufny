import { Employee } from "./employee";

export class EmployeeLinks {

  constructor(employeeId?: number, employee?: Employee)
  {

    this.employeeId = employeeId;
    this.employee = employee;
    

  }
  public employeeId: number;
  public employee: Employee;
}
