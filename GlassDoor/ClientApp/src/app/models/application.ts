export class Application {
  constructor(employeeId?: number, jobId?: number) {
    this.employeeId = employeeId;
    this.jobId = jobId;
  }
  public employeeId: number;
  public jobId: number;

}
